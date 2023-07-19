using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allegory.Module.Migrations
{
    /// <inheritdoc />
    public partial class CustomersDomainAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuleCustomerGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleCustomerGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CustomerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "nvarchar(max)", nullable: true),
                    AddressCity = table.Column<string>(name: "Address_City", type: "nvarchar(max)", nullable: true),
                    AddressTown = table.Column<string>(name: "Address_Town", type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(name: "Address_Line1", type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(name: "Address_Line2", type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleCustomers_ModuleCustomerGroups_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "ModuleCustomerGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModuleContactInformations",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleContactInformations", x => new { x.CustomerId, x.Name });
                    table.ForeignKey(
                        name: "FK_ModuleContactInformations_ModuleCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "ModuleCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleCustomers_CustomerGroupId",
                table: "ModuleCustomers",
                column: "CustomerGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleContactInformations");

            migrationBuilder.DropTable(
                name: "ModuleCustomers");

            migrationBuilder.DropTable(
                name: "ModuleCustomerGroups");
        }
    }
}
