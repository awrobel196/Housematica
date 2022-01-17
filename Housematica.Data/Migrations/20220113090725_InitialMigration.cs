using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Housematica.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseType",
                columns: table => new
                {
                    IdLicenseType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectAmount = table.Column<int>(type: "int", nullable: false),
                    UserAmount = table.Column<int>(type: "int", nullable: false),
                    VariantAmount = table.Column<int>(type: "int", nullable: false),
                    SettingsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDemo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseType", x => x.IdLicenseType);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    IdNotifcation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.IdNotifcation);
                });

            migrationBuilder.CreateTable(
                name: "ProjectType",
                columns: table => new
                {
                    IdProjectType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfiguratorType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.IdProjectType);
                });

            migrationBuilder.CreateTable(
                name: "SavedConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SavedConfigurationKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfigurationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfigurationValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    IdLicense = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLicenseType = table.Column<int>(type: "int", nullable: false),
                    Expire = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.IdLicense);
                    table.ForeignKey(
                        name: "FK_License_LicenseType_IdLicenseType",
                        column: x => x.IdLicenseType,
                        principalTable: "LicenseType",
                        principalColumn: "IdLicenseType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    IdProject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectAdress1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectAdress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPostcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProjectType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsValidate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.IdProject);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectType_IdProjectType",
                        column: x => x.IdProjectType,
                        principalTable: "ProjectType",
                        principalColumn: "IdProjectType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLicense = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_License_IdLicense",
                        column: x => x.IdLicense,
                        principalTable: "License",
                        principalColumn: "IdLicense",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    IdApartment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<float>(type: "real", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProjects = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.IdApartment);
                    table.ForeignKey(
                        name: "FK_Apartment_Projects_IdProjects",
                        column: x => x.IdProjects,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    IdHouse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfFloor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProjects = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.IdHouse);
                    table.ForeignKey(
                        name: "FK_House_Projects_IdProjects",
                        column: x => x.IdProjects,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsContacts",
                columns: table => new
                {
                    IdProjectsContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProjects = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsContacts", x => x.IdProjectsContact);
                    table.ForeignKey(
                        name: "FK_ProjectsContacts_Projects_IdProjects",
                        column: x => x.IdProjects,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsLicense",
                columns: table => new
                {
                    IdProjectsLicens = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLicense = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProject = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsLicense", x => x.IdProjectsLicens);
                    table.ForeignKey(
                        name: "FK_ProjectsLicense_License_IdLicense",
                        column: x => x.IdLicense,
                        principalTable: "License",
                        principalColumn: "IdLicense",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsLicense_Projects_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Single",
                columns: table => new
                {
                    SingleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfFloor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaBuild = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProjects = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Single", x => x.SingleGuid);
                    table.ForeignKey(
                        name: "FK_Single_Projects_IdProjects",
                        column: x => x.IdProjects,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TotalConfiguration",
                columns: table => new
                {
                    idTotalConfiguration = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjects = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    January = table.Column<int>(type: "int", nullable: false),
                    February = table.Column<int>(type: "int", nullable: false),
                    March = table.Column<int>(type: "int", nullable: false),
                    April = table.Column<int>(type: "int", nullable: false),
                    May = table.Column<int>(type: "int", nullable: false),
                    June = table.Column<int>(type: "int", nullable: false),
                    July = table.Column<int>(type: "int", nullable: false),
                    August = table.Column<int>(type: "int", nullable: false),
                    September = table.Column<int>(type: "int", nullable: false),
                    October = table.Column<int>(type: "int", nullable: false),
                    November = table.Column<int>(type: "int", nullable: false),
                    December = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalConfiguration", x => x.idTotalConfiguration);
                    table.ForeignKey(
                        name: "FK_TotalConfiguration_Projects_IdProjects",
                        column: x => x.IdProjects,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UViews",
                columns: table => new
                {
                    IdViews = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjects = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    January = table.Column<int>(type: "int", nullable: false),
                    February = table.Column<int>(type: "int", nullable: false),
                    March = table.Column<int>(type: "int", nullable: false),
                    April = table.Column<int>(type: "int", nullable: false),
                    May = table.Column<int>(type: "int", nullable: false),
                    June = table.Column<int>(type: "int", nullable: false),
                    July = table.Column<int>(type: "int", nullable: false),
                    August = table.Column<int>(type: "int", nullable: false),
                    September = table.Column<int>(type: "int", nullable: false),
                    October = table.Column<int>(type: "int", nullable: false),
                    November = table.Column<int>(type: "int", nullable: false),
                    December = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UViews", x => x.IdViews);
                    table.ForeignKey(
                        name: "FK_UViews_Projects_IdProjects",
                        column: x => x.IdProjects,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    IdViews = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjects = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    January = table.Column<int>(type: "int", nullable: false),
                    February = table.Column<int>(type: "int", nullable: false),
                    March = table.Column<int>(type: "int", nullable: false),
                    April = table.Column<int>(type: "int", nullable: false),
                    May = table.Column<int>(type: "int", nullable: false),
                    June = table.Column<int>(type: "int", nullable: false),
                    July = table.Column<int>(type: "int", nullable: false),
                    August = table.Column<int>(type: "int", nullable: false),
                    September = table.Column<int>(type: "int", nullable: false),
                    October = table.Column<int>(type: "int", nullable: false),
                    November = table.Column<int>(type: "int", nullable: false),
                    December = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.IdViews);
                    table.ForeignKey(
                        name: "FK_Views_Projects_IdProjects",
                        column: x => x.IdProjects,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsUser",
                columns: table => new
                {
                    IdProjectsUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProject = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsUser", x => x.IdProjectsUser);
                    table.ForeignKey(
                        name: "FK_ProjectsUser_Projects_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsUser_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentOption",
                columns: table => new
                {
                    IdApartmentOption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IdApartment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentOption", x => x.IdApartmentOption);
                    table.ForeignKey(
                        name: "FK_ApartmentOption_Apartment_IdApartment",
                        column: x => x.IdApartment,
                        principalTable: "Apartment",
                        principalColumn: "IdApartment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentVariants",
                columns: table => new
                {
                    IdApartmentVariants = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentArea = table.Column<float>(type: "real", nullable: false),
                    BalconyArea = table.Column<float>(type: "real", nullable: false),
                    NumberOfLivingRoom = table.Column<int>(type: "int", nullable: false),
                    ApartmentPrice = table.Column<float>(type: "real", nullable: false),
                    ApartmentModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdApartment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentVariants", x => x.IdApartmentVariants);
                    table.ForeignKey(
                        name: "FK_ApartmentVariants_Apartment_IdApartment",
                        column: x => x.IdApartment,
                        principalTable: "Apartment",
                        principalColumn: "IdApartment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseOption",
                columns: table => new
                {
                    IdHouseOption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IdHouse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseOption", x => x.IdHouseOption);
                    table.ForeignKey(
                        name: "FK_HouseOption_House_IdHouse",
                        column: x => x.IdHouse,
                        principalTable: "House",
                        principalColumn: "IdHouse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseVariants",
                columns: table => new
                {
                    IdHouseVariant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseArea = table.Column<float>(type: "real", nullable: false),
                    BalconyArea = table.Column<float>(type: "real", nullable: false),
                    TerraceArea = table.Column<float>(type: "real", nullable: false),
                    NumberOfLivingRoom = table.Column<int>(type: "int", nullable: false),
                    HousePrice = table.Column<float>(type: "real", nullable: false),
                    HouseModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHouse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseVariants", x => x.IdHouseVariant);
                    table.ForeignKey(
                        name: "FK_HouseVariants_House_IdHouse",
                        column: x => x.IdHouse,
                        principalTable: "House",
                        principalColumn: "IdHouse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingleFloor",
                columns: table => new
                {
                    IdSingleFloor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorType = table.Column<bool>(type: "bit", nullable: false),
                    FloorArea = table.Column<float>(type: "real", nullable: false),
                    BalconyArea = table.Column<float>(type: "real", nullable: false),
                    TerraceArea = table.Column<float>(type: "real", nullable: false),
                    NumberOfLivingRoom = table.Column<int>(type: "int", nullable: false),
                    FloorModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSingle = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleFloor", x => x.IdSingleFloor);
                    table.ForeignKey(
                        name: "FK_SingleFloor_Single_IdSingle",
                        column: x => x.IdSingle,
                        principalTable: "Single",
                        principalColumn: "SingleGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    IdRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomArea = table.Column<float>(type: "real", nullable: false),
                    IdApartmentVariants = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.IdRoom);
                    table.ForeignKey(
                        name: "FK_Rooms_ApartmentVariants_IdApartmentVariants",
                        column: x => x.IdApartmentVariants,
                        principalTable: "ApartmentVariants",
                        principalColumn: "IdApartmentVariants",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseRooms",
                columns: table => new
                {
                    IdHouseRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomArea = table.Column<float>(type: "real", nullable: false),
                    IdHouseVariants = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseRooms", x => x.IdHouseRoom);
                    table.ForeignKey(
                        name: "FK_HouseRooms_HouseVariants_IdHouseVariants",
                        column: x => x.IdHouseVariants,
                        principalTable: "HouseVariants",
                        principalColumn: "IdHouseVariant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingleRooms",
                columns: table => new
                {
                    IdSingleRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomArea = table.Column<float>(type: "real", nullable: false),
                    IdSingleFloors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleRooms", x => x.IdSingleRoom);
                    table.ForeignKey(
                        name: "FK_SingleRooms_SingleFloor_IdSingleFloors",
                        column: x => x.IdSingleFloors,
                        principalTable: "SingleFloor",
                        principalColumn: "IdSingleFloor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_IdProjects",
                table: "Apartment",
                column: "IdProjects");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentOption_IdApartment",
                table: "ApartmentOption",
                column: "IdApartment");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentVariants_IdApartment",
                table: "ApartmentVariants",
                column: "IdApartment");

            migrationBuilder.CreateIndex(
                name: "IX_House_IdProjects",
                table: "House",
                column: "IdProjects");

            migrationBuilder.CreateIndex(
                name: "IX_HouseOption_IdHouse",
                table: "HouseOption",
                column: "IdHouse");

            migrationBuilder.CreateIndex(
                name: "IX_HouseRooms_IdHouseVariants",
                table: "HouseRooms",
                column: "IdHouseVariants");

            migrationBuilder.CreateIndex(
                name: "IX_HouseVariants_IdHouse",
                table: "HouseVariants",
                column: "IdHouse");

            migrationBuilder.CreateIndex(
                name: "IX_License_IdLicenseType",
                table: "License",
                column: "IdLicenseType");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IdProjectType",
                table: "Projects",
                column: "IdProjectType");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsContacts_IdProjects",
                table: "ProjectsContacts",
                column: "IdProjects",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsLicense_IdLicense",
                table: "ProjectsLicense",
                column: "IdLicense");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsLicense_IdProject",
                table: "ProjectsLicense",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsUser_IdProject",
                table: "ProjectsUser",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsUser_IdUser",
                table: "ProjectsUser",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IdApartmentVariants",
                table: "Rooms",
                column: "IdApartmentVariants");

            migrationBuilder.CreateIndex(
                name: "IX_Single_IdProjects",
                table: "Single",
                column: "IdProjects");

            migrationBuilder.CreateIndex(
                name: "IX_SingleFloor_IdSingle",
                table: "SingleFloor",
                column: "IdSingle");

            migrationBuilder.CreateIndex(
                name: "IX_SingleRooms_IdSingleFloors",
                table: "SingleRooms",
                column: "IdSingleFloors");

            migrationBuilder.CreateIndex(
                name: "IX_TotalConfiguration_IdProjects",
                table: "TotalConfiguration",
                column: "IdProjects",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdLicense",
                table: "User",
                column: "IdLicense");

            migrationBuilder.CreateIndex(
                name: "IX_UViews_IdProjects",
                table: "UViews",
                column: "IdProjects",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Views_IdProjects",
                table: "Views",
                column: "IdProjects",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentOption");

            migrationBuilder.DropTable(
                name: "HouseOption");

            migrationBuilder.DropTable(
                name: "HouseRooms");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProjectsContacts");

            migrationBuilder.DropTable(
                name: "ProjectsLicense");

            migrationBuilder.DropTable(
                name: "ProjectsUser");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "SavedConfiguration");

            migrationBuilder.DropTable(
                name: "SingleRooms");

            migrationBuilder.DropTable(
                name: "TotalConfiguration");

            migrationBuilder.DropTable(
                name: "UViews");

            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.DropTable(
                name: "HouseVariants");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ApartmentVariants");

            migrationBuilder.DropTable(
                name: "SingleFloor");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Single");

            migrationBuilder.DropTable(
                name: "LicenseType");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectType");
        }
    }
}
