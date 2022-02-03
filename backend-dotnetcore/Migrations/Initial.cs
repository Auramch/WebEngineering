using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RUG.WebEng.Properties.Migrations
{
    public partial class Initial : Migration{
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Location_City= table.Column<string>(type:"longtext",nullable:false),
                    Location_Longitude= table.Column<string>(type:"longtext",nullable:false),
                    Location_Latitude= table.Column<string>(type:"longtext",nullable:false),
                    Location_PostalCode= table.Column<string>(type:"longtext",nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");    

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostedAgo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Roommates = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsRoomActive = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Availability = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),               
                    Costs_Rent = table.Column<int>(type: "int", nullable: false),
                    Costs_AdditionalCosts = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Costs_Deposit = table.Column<int>(type: "int", nullable: true),
                    RoomInfo_AreaSqm= table.Column<int>(type:"int",nullable:false),
                    RoomInfo_Furnish= table.Column<string>(type:"longtext",nullable:false),
                    RoomInfo_PropertyType= table.Column<string>(type:"longtext",nullable:false),
                    RoomInfo_EnergyLabel= table.Column<string>(type:"longtext",nullable:false),
                    Description_NonTranslatedDescription= table.Column<string>(type:"longtext",nullable:false),
                    Description_TranslatedDescription= table.Column<string>(type:"longtext",nullable:false),
                    Allowances_Pets= table.Column<string>(type:"longtext",nullable:false),
                    Allowances_SmokingInside= table.Column<string>(type:"longtext",nullable:false),
                    Commodities_Internet= table.Column<string>(type:"longtext",nullable:false),
                    Commodities_Kitchen= table.Column<string>(type:"longtext",nullable:false),
                    Commodities_Living= table.Column<string>(type:"longtext",nullable:false),
                    Commodities_Shower= table.Column<string>(type:"longtext",nullable:false),
                    Commodities_Toilet= table.Column<string>(type:"longtext",nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LocationProperty",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationProperty", x => new { x.LocationId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_LocationProperty_Location_LocationsId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationProperty_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4"); 

            migrationBuilder.CreateIndex(
                name: "IX_LocationProperty_PropertiesId",
                table: "LocationProperty",
                column: "PropertiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationProperty");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}