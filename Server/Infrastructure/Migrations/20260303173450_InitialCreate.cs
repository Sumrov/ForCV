using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EslOnline.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<long>(type: "bigint", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citizen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMissingPerson = table.Column<bool>(type: "bit", nullable: false),
                    Stress = table.Column<float>(type: "real", nullable: false),
                    Health = table.Column<float>(type: "real", nullable: false),
                    Hunger = table.Column<float>(type: "real", nullable: false),
                    BornId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CitizenshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cold = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Injury = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlcoholIntoxication = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DrugsIntoxication = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DrugAddiction = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlcoholAddiction = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location_IsDriver = table.Column<bool>(type: "bit", nullable: false),
                    Location_CitizenMoveMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location_CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location_TargetBuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Location_VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Location_PublicVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Location_StartMoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Job_Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job_SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsBankrupt = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankruptcyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commercial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionZ = table.Column<int>(type: "int", nullable: false),
                    SizeX = table.Column<int>(type: "int", nullable: false),
                    SizeZ = table.Column<int>(type: "int", nullable: false),
                    CellSizeX = table.Column<int>(type: "int", nullable: false),
                    CellSizeY = table.Column<int>(type: "int", nullable: false),
                    CellSizeZ = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstructionUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commercial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrossRoad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionZ = table.Column<int>(type: "int", nullable: false),
                    SizeX = table.Column<int>(type: "int", nullable: false),
                    SizeZ = table.Column<int>(type: "int", nullable: false),
                    CellSizeX = table.Column<int>(type: "int", nullable: false),
                    CellSizeY = table.Column<int>(type: "int", nullable: false),
                    CellSizeZ = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstructionUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossRoad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Government",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeadRegionAppointment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeadGovernmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Codex_ImmunityCivilServants = table.Column<bool>(type: "bit", nullable: false),
                    Codex_IsCanRegionLeaderDissolveLegislative = table.Column<bool>(type: "bit", nullable: false),
                    Codex_IsCanRegionLeaderSetControlledRegionLeader = table.Column<bool>(type: "bit", nullable: false),
                    Codex_EnforcmentDepartmentMaxEmployeers = table.Column<int>(type: "int", nullable: false),
                    Codex_CitizenProfitPercentTax = table.Column<int>(type: "int", nullable: false),
                    Codex_CompanyProfitPercentTax = table.Column<int>(type: "int", nullable: false),
                    Codex_EnforcmentDepartmentEmployeersSalary = table.Column<long>(type: "bigint", nullable: false),
                    Codex_RegistrationCompanyFee = table.Column<long>(type: "bigint", nullable: false),
                    Codex_ElectionRegestrationFee = table.Column<long>(type: "bigint", nullable: false),
                    Codex_RegionHeadSalary = table.Column<long>(type: "bigint", nullable: false),
                    Codex_LegislatorsSalary = table.Column<long>(type: "bigint", nullable: false),
                    Codex_HeadEnforcmentSalary = table.Column<long>(type: "bigint", nullable: false),
                    Codex_HeadFinancialSalary = table.Column<long>(type: "bigint", nullable: false),
                    Codex_HeadUrbanSalary = table.Column<long>(type: "bigint", nullable: false),
                    Codex_HeadForeignRelationsSalary = table.Column<long>(type: "bigint", nullable: false),
                    Codex_HeadJusticeSalary = table.Column<long>(type: "bigint", nullable: false),
                    Codex_LeaderPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codex_LegislatorsCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codex_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codex_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Currency_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Currency_ShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Currency_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBankrupt = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankruptcyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Government", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionZ = table.Column<int>(type: "int", nullable: false),
                    SizeX = table.Column<int>(type: "int", nullable: false),
                    SizeZ = table.Column<int>(type: "int", nullable: false),
                    CellSizeX = table.Column<int>(type: "int", nullable: false),
                    CellSizeY = table.Column<int>(type: "int", nullable: false),
                    CellSizeZ = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstructionUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industrial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionZ = table.Column<int>(type: "int", nullable: false),
                    SizeX = table.Column<int>(type: "int", nullable: false),
                    SizeZ = table.Column<int>(type: "int", nullable: false),
                    CellSizeX = table.Column<int>(type: "int", nullable: false),
                    CellSizeY = table.Column<int>(type: "int", nullable: false),
                    CellSizeZ = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstructionUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industrial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Microbusiness",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Production = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionZ = table.Column<int>(type: "int", nullable: false),
                    SizeX = table.Column<int>(type: "int", nullable: false),
                    SizeZ = table.Column<int>(type: "int", nullable: false),
                    CellSizeX = table.Column<int>(type: "int", nullable: false),
                    CellSizeY = table.Column<int>(type: "int", nullable: false),
                    CellSizeZ = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstructionUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microbusiness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Road",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionZ = table.Column<int>(type: "int", nullable: false),
                    SizeX = table.Column<int>(type: "int", nullable: false),
                    SizeZ = table.Column<int>(type: "int", nullable: false),
                    CellSizeX = table.Column<int>(type: "int", nullable: false),
                    CellSizeY = table.Column<int>(type: "int", nullable: false),
                    CellSizeZ = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstructionUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Road", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCanRent = table.Column<bool>(type: "bit", nullable: false),
                    IsCanSell = table.Column<bool>(type: "bit", nullable: false),
                    IsCanContinueContract = table.Column<bool>(type: "bit", nullable: false),
                    RentPeriod = table.Column<int>(type: "int", nullable: false),
                    RentPayPeriod = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RentPenalty = table.Column<long>(type: "bigint", nullable: false),
                    RentPay = table.Column<long>(type: "bigint", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    GoodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Square",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionZ = table.Column<int>(type: "int", nullable: false),
                    SizeX = table.Column<int>(type: "int", nullable: false),
                    SizeZ = table.Column<int>(type: "int", nullable: false),
                    CellSizeX = table.Column<int>(type: "int", nullable: false),
                    CellSizeY = table.Column<int>(type: "int", nullable: false),
                    CellSizeZ = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstructionUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Square", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StackableGood",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    MovebleGoodLocation_CitizenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MovebleGoodLocation_VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MovebleGoodLocation_RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MovebleGoodLocation_BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MovebleGoodLocation_IsInFridge = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    GoodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StackableGood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tawnhall",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionZ = table.Column<int>(type: "int", nullable: false),
                    SizeX = table.Column<int>(type: "int", nullable: false),
                    SizeZ = table.Column<int>(type: "int", nullable: false),
                    CellSizeX = table.Column<int>(type: "int", nullable: false),
                    CellSizeY = table.Column<int>(type: "int", nullable: false),
                    CellSizeZ = table.Column<int>(type: "int", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConstructionUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tawnhall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    GMail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telegram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CitizenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_GMail",
                table: "User",
                column: "GMail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Citizen");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Commercial");

            migrationBuilder.DropTable(
                name: "CrossRoad");

            migrationBuilder.DropTable(
                name: "Government");

            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropTable(
                name: "Industrial");

            migrationBuilder.DropTable(
                name: "Microbusiness");

            migrationBuilder.DropTable(
                name: "Road");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Square");

            migrationBuilder.DropTable(
                name: "StackableGood");

            migrationBuilder.DropTable(
                name: "Tawnhall");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
