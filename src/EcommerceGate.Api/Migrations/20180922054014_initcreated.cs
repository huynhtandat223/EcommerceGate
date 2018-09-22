using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceGate.Api.Migrations
{
    public partial class initcreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Core_AppSetting",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Module = table.Column<string>(nullable: true),
                    IsVisibleInCommonSettingPage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_AppSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models_Country",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code3 = table.Column<string>(nullable: true),
                    IsBillingEnabled = table.Column<bool>(nullable: false),
                    IsShippingEnabled = table.Column<bool>(nullable: false),
                    IsCityEnabled = table.Column<bool>(nullable: false),
                    IsZipCodeEnabled = table.Column<bool>(nullable: false),
                    IsDistrictEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models_CustomerGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models_CustomerGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models_EntityType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsMenuable = table.Column<bool>(nullable: false),
                    RoutingController = table.Column<string>(nullable: true),
                    RoutingAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models_EntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 350, nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    ParentName = table.Column<string>(maxLength: 350, nullable: true),
                    SKUPrefix = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 350, nullable: true),
                    Alt = table.Column<string>(maxLength: 500, nullable: true),
                    Position = table.Column<int>(maxLength: 350, nullable: false),
                    SourceUrl = table.Column<string>(maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    SKU = table.Column<string>(maxLength: 50, nullable: true),
                    RegularPrice = table.Column<double>(nullable: true),
                    CreatedDate = table.Column<DateTime>(maxLength: 1000, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    QtyOnHand = table.Column<int>(nullable: true),
                    OriginalPrice = table.Column<double>(nullable: true),
                    IsInStock = table.Column<bool>(nullable: true),
                    OriginalUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    ProductNote = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    UpdatedUser = table.Column<string>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_ProductOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_ProductOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_RoleClaim_Core_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Core_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models_StateOrProvince",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models_StateOrProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_StateOrProvince_Models_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Models_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Models_Entity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Slug = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    EntityId = table.Column<long>(nullable: false),
                    EntityTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Entity_Models_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "Models_EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products_ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Products_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory_Products_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products_ProductImage",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_ProductImage", x => new { x.ProductId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_Products_ProductImage_Products_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Products_Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductImage_Products_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products_ProductOptionValue",
                columns: table => new
                {
                    OptionId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ProductOptionValudeDefaultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_ProductOptionValue", x => new { x.ProductId, x.OptionId, x.ProductOptionValudeDefaultId });
                    table.ForeignKey(
                        name: "FK_Products_ProductOptionValue_Products_ProductOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Products_ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductOptionValue_Products_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Models_District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateOrProvinceId = table.Column<long>(nullable: false),
                    StateOrProvinceId1 = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_District_Models_StateOrProvince_StateOrProvinceId1",
                        column: x => x.StateOrProvinceId1,
                        principalTable: "Models_StateOrProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Models_Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    DistrictId1 = table.Column<int>(nullable: true),
                    StateOrProvinceId = table.Column<long>(nullable: false),
                    StateOrProvinceId1 = table.Column<int>(nullable: true),
                    CountryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Address_Models_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Models_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Models_Address_Models_District_DistrictId1",
                        column: x => x.DistrictId1,
                        principalTable: "Models_District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Models_Address_Models_StateOrProvince_StateOrProvinceId1",
                        column: x => x.StateOrProvinceId1,
                        principalTable: "Models_StateOrProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Core_UserRole_Core_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Core_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_CustomerGroupUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CustomerGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_CustomerGroupUser", x => new { x.UserId, x.CustomerGroupId });
                    table.ForeignKey(
                        name: "FK_Core_CustomerGroupUser_Models_CustomerGroup_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "Models_CustomerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "Core_UserToken",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Models_UserAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    AddressType = table.Column<int>(nullable: false),
                    LastUsedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models_UserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_UserAddress_Models_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Models_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    VendorId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    DefaultShippingAddressId = table.Column<int>(nullable: true),
                    DefaultBillingAddressId = table.Column<int>(nullable: true),
                    RefreshTokenHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_User_Models_UserAddress_DefaultBillingAddressId",
                        column: x => x.DefaultBillingAddressId,
                        principalTable: "Models_UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_User_Models_UserAddress_DefaultShippingAddressId",
                        column: x => x.DefaultShippingAddressId,
                        principalTable: "Models_UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Core_AppSetting",
                columns: new[] { "Id", "IsVisibleInCommonSettingPage", "Module", "Value" },
                values: new object[,]
                {
                    { "Global.AssetVersion", true, "Core", "1.0" },
                    { "Theme", false, "Core", "Generic" }
                });

            migrationBuilder.InsertData(
                table: "Core_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 4, "71f10604-8c4d-4a7d-ac4a-ffefb11cefeb", "vendor", "VENDOR" },
                    { 2, "00d172be-03a0-4856-8b12-26d63fcf4374", "customer", "CUSTOMER" },
                    { 1, "4776a1b2-dbe4-4056-82ec-8bed211d1454", "admin", "ADMIN" },
                    { 3, "d4754388-8355-4018-b728-218018836817", "guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "Core_User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DefaultBillingAddressId", "DefaultShippingAddressId", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenHash", "SecurityStamp", "TwoFactorEnabled", "UpdatedOn", "UserGuid", "UserName", "VendorId" },
                values: new object[,]
                {
                    { 2, 0, "101cd6ae-a8ef-4a37-97fd-04ac2dd630e4", new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 189, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), null, null, "system@simplcommerce.com", false, "System User", true, false, null, "SYSTEM@SIMPLCOMMERCE.COM", "SYSTEM@SIMPLCOMMERCE.COM", "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", null, false, null, "a9565acb-cee6-425f-9833-419a793f5fba", false, new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 189, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("5f72f83b-7436-4221-869c-1b69b2e23aae"), "system@simplcommerce.com", null },
                    { 10, 0, "c83afcbc-312c-4589-bad7-8686bd4754c0", new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), null, null, "admin@simplcommerce.com", false, "Shop Admin", false, false, null, "ADMIN@SIMPLCOMMERCE.COM", "ADMIN@SIMPLCOMMERCE.COM", "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", null, false, null, "d6847450-47f0-4c7a-9fed-0c66234bf61f", false, new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("ed8210c3-24b0-4823-a744-80078cf12eb4"), "admin@simplcommerce.com", null }
                });

            migrationBuilder.InsertData(
                table: "Models_Country",
                columns: new[] { "Id", "Code3", "IsBillingEnabled", "IsCityEnabled", "IsDistrictEnabled", "IsShippingEnabled", "IsZipCodeEnabled", "Name" },
                values: new object[,]
                {
                    { "US", "USA", true, true, false, true, true, "United States" },
                    { "VN", "VNM", true, false, true, true, false, "Việt Nam" }
                });

            migrationBuilder.InsertData(
                table: "Models_District",
                columns: new[] { "Id", "Location", "Name", "StateOrProvinceId", "StateOrProvinceId1", "Type" },
                values: new object[,]
                {
                    { 1, null, "Quận 1", 1L, null, "Quận" },
                    { 2, null, "Quận 2", 1L, null, "Quận" }
                });

            migrationBuilder.InsertData(
                table: "Models_EntityType",
                columns: new[] { "Id", "IsMenuable", "RoutingAction", "RoutingController" },
                values: new object[] { "Vendor", false, "VendorDetail", "Vendor" });

            migrationBuilder.InsertData(
                table: "Products_Category",
                columns: new[] { "Id", "Name", "ParentId", "ParentName", "SKUPrefix" },
                values: new object[,]
                {
                    { 5, "Category 5", 2, "Category 2", "C5" },
                    { 1, "Category 1", 0, null, "C1" },
                    { 2, "Category 2", 0, null, "C2" },
                    { 3, "Category 3", 1, "Category 1", "C3" },
                    { 4, "Category 4", 1, "Category 1", "C4" },
                    { 6, "Category 6", 3, "Category 3", "C6" }
                });

            migrationBuilder.InsertData(
                table: "Core_UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 10, 1 });

            migrationBuilder.InsertData(
                table: "Models_Address",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "ContactName", "CountryId", "DistrictId", "DistrictId1", "Phone", "StateOrProvinceId", "StateOrProvinceId1", "ZipCode" },
                values: new object[] { 1, "364 Cong Hoa", null, null, "Thien Nguyen", "VN", null, null, null, 1L, null, null });

            migrationBuilder.InsertData(
                table: "Models_StateOrProvince",
                columns: new[] { "Id", "Code", "CountryId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, null, "VN", "Hồ Chí Minh", "Thành Phố" },
                    { 2, "WA", "US", "Washington", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Core_CustomerGroupUser_CustomerGroupId",
                table: "Core_CustomerGroupUser",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Core_Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Core_RoleClaim_RoleId",
                table: "Core_RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_User_DefaultBillingAddressId",
                table: "Core_User",
                column: "DefaultBillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_User_DefaultShippingAddressId",
                table: "Core_User",
                column: "DefaultShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Core_User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Core_User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserClaim_UserId",
                table: "Core_UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserLogin_UserId",
                table: "Core_UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserRole_RoleId",
                table: "Core_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Address_CountryId",
                table: "Models_Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Address_DistrictId1",
                table: "Models_Address",
                column: "DistrictId1");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Address_StateOrProvinceId1",
                table: "Models_Address",
                column: "StateOrProvinceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Models_CustomerGroup_Name",
                table: "Models_CustomerGroup",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Models_District_StateOrProvinceId1",
                table: "Models_District",
                column: "StateOrProvinceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Entity_EntityTypeId",
                table: "Models_Entity",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_StateOrProvince_CountryId",
                table: "Models_StateOrProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_UserAddress_AddressId",
                table: "Models_UserAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_UserAddress_UserId",
                table: "Models_UserAddress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategory_CategoryId",
                table: "Products_ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductImage_ImageId",
                table: "Products_ProductImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductOptionValue_OptionId",
                table: "Products_ProductOptionValue",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserRole_Core_User_UserId",
                table: "Core_UserRole",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_CustomerGroupUser_Core_User_UserId",
                table: "Core_CustomerGroupUser",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserClaim_Core_User_UserId",
                table: "Core_UserClaim",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserLogin_Core_User_UserId",
                table: "Core_UserLogin",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserToken_Core_User_UserId",
                table: "Core_UserToken",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_UserAddress_Core_User_UserId",
                table: "Models_UserAddress",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_UserAddress_Core_User_UserId",
                table: "Models_UserAddress");

            migrationBuilder.DropTable(
                name: "Core_AppSetting");

            migrationBuilder.DropTable(
                name: "Core_CustomerGroupUser");

            migrationBuilder.DropTable(
                name: "Core_RoleClaim");

            migrationBuilder.DropTable(
                name: "Core_UserClaim");

            migrationBuilder.DropTable(
                name: "Core_UserLogin");

            migrationBuilder.DropTable(
                name: "Core_UserRole");

            migrationBuilder.DropTable(
                name: "Core_UserToken");

            migrationBuilder.DropTable(
                name: "Models_Entity");

            migrationBuilder.DropTable(
                name: "Products_ProductCategory");

            migrationBuilder.DropTable(
                name: "Products_ProductImage");

            migrationBuilder.DropTable(
                name: "Products_ProductOptionValue");

            migrationBuilder.DropTable(
                name: "Models_CustomerGroup");

            migrationBuilder.DropTable(
                name: "Core_Role");

            migrationBuilder.DropTable(
                name: "Models_EntityType");

            migrationBuilder.DropTable(
                name: "Products_Category");

            migrationBuilder.DropTable(
                name: "Products_Image");

            migrationBuilder.DropTable(
                name: "Products_ProductOption");

            migrationBuilder.DropTable(
                name: "Products_Product");

            migrationBuilder.DropTable(
                name: "Core_User");

            migrationBuilder.DropTable(
                name: "Models_UserAddress");

            migrationBuilder.DropTable(
                name: "Models_Address");

            migrationBuilder.DropTable(
                name: "Models_District");

            migrationBuilder.DropTable(
                name: "Models_StateOrProvince");

            migrationBuilder.DropTable(
                name: "Models_Country");
        }
    }
}
