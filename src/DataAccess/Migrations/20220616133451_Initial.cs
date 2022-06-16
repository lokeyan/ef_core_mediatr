using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscription",
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
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
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
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Subscription_SubscriptionLevel",
                        column: x => x.SubscriptionLevel,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SubscriptionLevel",
                table: "Customer",
                column: "SubscriptionLevel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Subscription");
        }
    }
}
