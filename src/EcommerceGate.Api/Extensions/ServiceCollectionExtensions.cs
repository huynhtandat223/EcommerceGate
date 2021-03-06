﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using EcommerceGate.Api.ModelBinders;
using EcommerceGate.Core;
using EcommerceGate.Core.Data;
using EcommerceGate.Core.Entities;
using EcommerceGate.Core.Extensions;
using EcommerceGate.Core.Models;
using EcommerceGate.Infrastructures.Data;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceGate.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadInstalledModules(this IServiceCollection services, string contentRootPath)
        {
            var modules = new List<ModuleInfo>();
            var moduleRootFolder = new DirectoryInfo(Path.Combine(contentRootPath, "Modules"));
            var moduleFolders = moduleRootFolder.GetDirectories();

            foreach (var moduleFolder in moduleFolders)
            {
                Assembly moduleMainAssembly = null;
                var binFolder = new DirectoryInfo(Path.Combine(moduleFolder.FullName, "bin"));
                if (binFolder.Exists) // The module is not bundled with the host, so we have to load it
                {
                    moduleMainAssembly = LoadModule(moduleFolder, binFolder);
                }

                if (moduleMainAssembly == null)
                {
                    moduleMainAssembly = Assembly.Load(new AssemblyName(moduleFolder.Name));
                }

                modules.Add(new ModuleInfo
                {
                    Name = moduleFolder.Name,
                    Assembly = moduleMainAssembly,
                    Path = moduleFolder.FullName
                });
            }
            
            foreach (var module in modules)
            {
                var moduleInitializerType = module.Assembly.GetTypes().FirstOrDefault(x => typeof(IModuleInitializer).IsAssignableFrom(x));
                if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
                {
                    services.AddSingleton(typeof(IModuleInitializer), moduleInitializerType);
                }

                var odataCustomModelBuilderType = module.Assembly.GetTypes().FirstOrDefault(x => typeof(IODataCustomModelBuilder).IsAssignableFrom(x));
                if ((odataCustomModelBuilderType != null) && (odataCustomModelBuilderType != typeof(IODataCustomModelBuilder)))
                {
                    services.AddSingleton(typeof(IODataCustomModelBuilder), odataCustomModelBuilderType);
                }
            }

            GlobalConfiguration.Modules = modules;
            return services;
        }

        private static Assembly LoadModule(DirectoryInfo moduleFolder, DirectoryInfo binFolder)
        {
            Assembly moduleMainAssembly = null;

            foreach (var file in binFolder.GetFileSystemInfos("*.dll", SearchOption.AllDirectories))
            {
                Assembly assembly;
                try
                {
                    assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file.FullName);
                }
                catch (FileLoadException)
                {
                    // Get loaded assembly. This assembly might be loaded
                    assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(file.Name)));

                    if (assembly == null)
                    {
                        throw;
                    }

                    string loadedAssemblyVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                    string tryToLoadAssemblyVersion = FileVersionInfo.GetVersionInfo(file.FullName).FileVersion;

                    // Or log the exception somewhere and don't add the module to list so that it will not be initialized
                    if (tryToLoadAssemblyVersion != loadedAssemblyVersion)
                    {
                        throw new Exception($"Cannot load {file.FullName} {tryToLoadAssemblyVersion} because {assembly.Location} {loadedAssemblyVersion} has been loaded");
                    }
                }

                if (assembly.FullName.Contains(moduleFolder.Name))
                {
                    moduleMainAssembly = assembly;
                }
            }

            return moduleMainAssembly;
        }

        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services, IList<ModuleInfo> modules)
        {
            services.AddOData();
            var mvcBuilder = services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            foreach (var module in modules)
            {
                mvcBuilder.AddApplicationPart(module.Assembly);
            }

            return services;
        }

        public static IServiceCollection AddCustomizedIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddRoleStore<EcommerceGateRoleStore>()
                .AddUserStore<EcommerceGateUserStore>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie()
                .AddFacebook(x =>
                {
                    x.AppId = "1716532045292977";
                    x.AppSecret = "dfece01ae919b7b8af23f962a1f87f95";

                    x.Events = new OAuthEvents
                    {
                        OnRemoteFailure = ctx => HandleRemoteLoginFailure(ctx)
                    };
                })
                .AddGoogle(x =>
                {
                    x.ClientId = "583825788849-8g42lum4trd5g3319go0iqt6pn30gqlq.apps.googleusercontent.com";
                    x.ClientSecret = "X8xIiuNEUjEYfiEfiNrWOfI4";
                    x.Events = new OAuthEvents
                    {
                        OnRemoteFailure = ctx => HandleRemoteLoginFailure(ctx)
                    };
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });
            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = new PathString("/login");
                x.Events.OnRedirectToLogin = context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api") && context.Response.StatusCode == (int)HttpStatusCode.OK)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return Task.CompletedTask;
                    }

                    context.Response.Redirect(context.RedirectUri);
                    return Task.CompletedTask;
                };
                x.Events.OnRedirectToAccessDenied = context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api") && context.Response.StatusCode == (int)HttpStatusCode.OK)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        return Task.CompletedTask;
                    }

                    context.Response.Redirect(context.RedirectUri);
                    return Task.CompletedTask;
                };
            });
            return services;
        }

        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<EcommerceGateDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("EcommerceGate.Api")));
            return services;
        }

        public static IServiceProvider Build(this IServiceCollection services,
            IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(RepositoryWithTypedId<,>)).As(typeof(IRepositoryWithTypedId<,>));

            //builder.RegisterSource(new ContravariantRegistrationSource());
            //builder.RegisterType<SequentialMediator>().As<IMediator>().InstancePerLifetimeScope();
            //builder
            //  .Register<ServiceFactory>(ctx =>
            //  {
            //      var c = ctx.Resolve<IComponentContext>();
            //      return t => { object o; return c.TryResolve(t, out o) ? o : null; };
            //  })
            //  .InstancePerLifetimeScope();

            foreach (var module in GlobalConfiguration.Modules)
            {
                builder.RegisterAssemblyTypes(module.Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
                //builder.RegisterAssemblyTypes(module.Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
                //builder.RegisterAssemblyTypes(module.Assembly).Where(t => t.Name.EndsWith("ServiceProvider")).AsImplementedInterfaces();
                //builder.RegisterAssemblyTypes(module.Assembly).Where(t => t.Name.EndsWith("Handler")).AsImplementedInterfaces();
            }

            builder.RegisterInstance(configuration);
            builder.RegisterInstance(hostingEnvironment);
            builder.Populate(services);
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        private static Task HandleRemoteLoginFailure(RemoteFailureContext ctx)
        {
            ctx.Response.Redirect("/login");
            ctx.HandleResponse();
            return Task.CompletedTask;
        }
    }
}
