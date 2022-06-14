using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    PricePerMonth = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    NumberOfSimultaneousDevices = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberDevicesWithDownloadCapability = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    SubscriptionLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Subscriptions_SubscriptionLevel",
                        column: x => x.SubscriptionLevel,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SubscriptionLevel",
                table: "Customers",
                column: "SubscriptionLevel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
