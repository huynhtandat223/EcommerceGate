﻿// <auto-generated />
using System;
using EcommerceGate.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcommerceGate.Api.Migrations
{
    [DbContext(typeof(EcommerceGateDbContext))]
    partial class EcommerceGateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcommerceGate.Core.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<string>("ContactName");

                    b.Property<string>("CountryId")
                        .IsRequired();

                    b.Property<long?>("DistrictId");

                    b.Property<int?>("DistrictId1");

                    b.Property<string>("Phone");

                    b.Property<long>("StateOrProvinceId");

                    b.Property<int?>("StateOrProvinceId1");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("DistrictId1");

                    b.HasIndex("StateOrProvinceId1");

                    b.ToTable("Models_Address");

                    b.HasData(
                        new { Id = 1, AddressLine1 = "364 Cong Hoa", ContactName = "Thien Nguyen", CountryId = "VN", StateOrProvinceId = 1L }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.AppSetting", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsVisibleInCommonSettingPage");

                    b.Property<string>("Module");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Core_AppSetting");

                    b.HasData(
                        new { Id = "Global.AssetVersion", IsVisibleInCommonSettingPage = true, Module = "Core", Value = "1.0" },
                        new { Id = "Theme", IsVisibleInCommonSettingPage = false, Module = "Core", Value = "Generic" }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code3");

                    b.Property<bool>("IsBillingEnabled");

                    b.Property<bool>("IsCityEnabled");

                    b.Property<bool>("IsDistrictEnabled");

                    b.Property<bool>("IsShippingEnabled");

                    b.Property<bool>("IsZipCodeEnabled");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Models_Country");

                    b.HasData(
                        new { Id = "VN", Code3 = "VNM", IsBillingEnabled = true, IsCityEnabled = false, IsDistrictEnabled = true, IsShippingEnabled = true, IsZipCodeEnabled = false, Name = "Việt Nam" },
                        new { Id = "US", Code3 = "USA", IsBillingEnabled = true, IsCityEnabled = true, IsDistrictEnabled = false, IsShippingEnabled = true, IsZipCodeEnabled = true, Name = "United States" }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.CustomerGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Models_CustomerGroup");
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.CustomerGroupUser", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("CustomerGroupId");

                    b.HasKey("UserId", "CustomerGroupId");

                    b.HasIndex("CustomerGroupId");

                    b.ToTable("Core_CustomerGroupUser");
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<long>("StateOrProvinceId");

                    b.Property<int?>("StateOrProvinceId1");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("StateOrProvinceId1");

                    b.ToTable("Models_District");

                    b.HasData(
                        new { Id = 1, Name = "Quận 1", StateOrProvinceId = 1L, Type = "Quận" },
                        new { Id = 2, Name = "Quận 2", StateOrProvinceId = 1L, Type = "Quận" }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EntityId");

                    b.Property<string>("EntityTypeId");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.HasIndex("EntityTypeId");

                    b.ToTable("Models_Entity");
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.EntityType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsMenuable");

                    b.Property<string>("RoutingAction");

                    b.Property<string>("RoutingController");

                    b.HasKey("Id");

                    b.ToTable("Models_EntityType");

                    b.HasData(
                        new { Id = "Vendor", IsMenuable = false, RoutingAction = "VendorDetail", RoutingController = "Vendor" }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Core_Role");

                    b.HasData(
                        new { Id = 1, ConcurrencyStamp = "4776a1b2-dbe4-4056-82ec-8bed211d1454", Name = "admin", NormalizedName = "ADMIN" },
                        new { Id = 2, ConcurrencyStamp = "00d172be-03a0-4856-8b12-26d63fcf4374", Name = "customer", NormalizedName = "CUSTOMER" },
                        new { Id = 3, ConcurrencyStamp = "d4754388-8355-4018-b728-218018836817", Name = "guest", NormalizedName = "GUEST" },
                        new { Id = 4, ConcurrencyStamp = "71f10604-8c4d-4a7d-ac4a-ffefb11cefeb", Name = "vendor", NormalizedName = "VENDOR" }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.StateOrProvince", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("CountryId");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Models_StateOrProvince");

                    b.HasData(
                        new { Id = 1, CountryId = "VN", Name = "Hồ Chí Minh", Type = "Thành Phố" },
                        new { Id = 2, Code = "WA", CountryId = "US", Name = "Washington" }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTimeOffset>("CreatedOn");

                    b.Property<int?>("DefaultBillingAddressId");

                    b.Property<int?>("DefaultShippingAddressId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RefreshTokenHash");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTimeOffset>("UpdatedOn");

                    b.Property<Guid>("UserGuid");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int?>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("DefaultBillingAddressId");

                    b.HasIndex("DefaultShippingAddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Core_User");

                    b.HasData(
                        new { Id = 2, AccessFailedCount = 0, ConcurrencyStamp = "101cd6ae-a8ef-4a37-97fd-04ac2dd630e4", CreatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 189, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), Email = "system@simplcommerce.com", EmailConfirmed = false, FullName = "System User", IsDeleted = true, LockoutEnabled = false, NormalizedEmail = "SYSTEM@SIMPLCOMMERCE.COM", NormalizedUserName = "SYSTEM@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", PhoneNumberConfirmed = false, SecurityStamp = "a9565acb-cee6-425f-9833-419a793f5fba", TwoFactorEnabled = false, UpdatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 189, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), UserGuid = new Guid("5f72f83b-7436-4221-869c-1b69b2e23aae"), UserName = "system@simplcommerce.com" },
                        new { Id = 10, AccessFailedCount = 0, ConcurrencyStamp = "c83afcbc-312c-4589-bad7-8686bd4754c0", CreatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), Email = "admin@simplcommerce.com", EmailConfirmed = false, FullName = "Shop Admin", IsDeleted = false, LockoutEnabled = false, NormalizedEmail = "ADMIN@SIMPLCOMMERCE.COM", NormalizedUserName = "ADMIN@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", PhoneNumberConfirmed = false, SecurityStamp = "d6847450-47f0-4c7a-9fed-0c66234bf61f", TwoFactorEnabled = false, UpdatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), UserGuid = new Guid("ed8210c3-24b0-4823-a744-80078cf12eb4"), UserName = "admin@simplcommerce.com" }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<int>("AddressType");

                    b.Property<DateTimeOffset?>("LastUsedOn");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Models_UserAddress");
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("Core_UserRole");

                    b.HasData(
                        new { UserId = 10, RoleId = 1 }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(350);

                    b.Property<int>("ParentId");

                    b.Property<string>("SKUPrefix")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Products_Category");

                    b.HasData(
                        new { Id = 1, Name = "Category 1", ParentId = 0, SKUPrefix = "C1" },
                        new { Id = 2, Name = "Category 2", ParentId = 0, SKUPrefix = "C2" },
                        new { Id = 3, Name = "Category 3", ParentId = 1, SKUPrefix = "C3" },
                        new { Id = 4, Name = "Category 4", ParentId = 1, SKUPrefix = "C4" },
                        new { Id = 5, Name = "Category 5", ParentId = 2, SKUPrefix = "C5" },
                        new { Id = 6, Name = "Category 6", ParentId = 3, SKUPrefix = "C6" }
                    );
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(350);

                    b.Property<int>("Position")
                        .HasMaxLength(350);

                    b.Property<string>("SourceUrl")
                        .HasMaxLength(350);

                    b.HasKey("Id");

                    b.ToTable("Products_Image");
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate")
                        .HasMaxLength(1000);

                    b.Property<string>("CreatedUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool?>("IsInStock");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<double?>("OriginalPrice");

                    b.Property<string>("OriginalUrl")
                        .HasMaxLength(1000);

                    b.Property<string>("ProductNote");

                    b.Property<int?>("QtyOnHand");

                    b.Property<double?>("RegularPrice");

                    b.Property<string>("SKU")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UpdatedUser");

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Products_Product");
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products_ProductCategory");
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.ProductImage", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("ImageId");

                    b.HasKey("ProductId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("Products_ProductImage");
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.ProductOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Products_ProductOption");
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.ProductOptionValue", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("OptionId");

                    b.Property<int>("ProductOptionValudeDefaultId");

                    b.Property<string>("Value");

                    b.HasKey("ProductId", "OptionId", "ProductOptionValudeDefaultId");

                    b.HasIndex("OptionId");

                    b.ToTable("Products_ProductOptionValue");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Core_RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Core_UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("Core_UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("Core_UserToken");
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.Address", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcommerceGate.Core.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcommerceGate.Core.Models.StateOrProvince", "StateOrProvince")
                        .WithMany()
                        .HasForeignKey("StateOrProvinceId1")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.CustomerGroupUser", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.CustomerGroup", "CustomerGroup")
                        .WithMany("Users")
                        .HasForeignKey("CustomerGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EcommerceGate.Core.Models.User", "User")
                        .WithMany("CustomerGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.District", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.StateOrProvince", "StateOrProvince")
                        .WithMany()
                        .HasForeignKey("StateOrProvinceId1")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.Entity", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.EntityType", "EntityType")
                        .WithMany()
                        .HasForeignKey("EntityTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.StateOrProvince", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.Country", "Country")
                        .WithMany("StatesOrProvinces")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.User", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.UserAddress", "DefaultBillingAddress")
                        .WithMany()
                        .HasForeignKey("DefaultBillingAddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcommerceGate.Core.Models.UserAddress", "DefaultShippingAddress")
                        .WithMany()
                        .HasForeignKey("DefaultShippingAddressId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.UserAddress", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.Address", "Address")
                        .WithMany("UserAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcommerceGate.Core.Models.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EcommerceGate.Core.Models.UserRole", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcommerceGate.Core.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.ProductCategory", b =>
                {
                    b.HasOne("EcommerceGate.Module.Products.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcommerceGate.Module.Products.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.ProductImage", b =>
                {
                    b.HasOne("EcommerceGate.Module.Products.Models.Image", "Image")
                        .WithMany("ProductImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcommerceGate.Module.Products.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EcommerceGate.Module.Products.Models.ProductOptionValue", b =>
                {
                    b.HasOne("EcommerceGate.Module.Products.Models.ProductOption", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EcommerceGate.Module.Products.Models.Product", "Product")
                        .WithMany("ProductOptionValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("EcommerceGate.Core.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
