using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAcess.Datatables.Migrations
{
    [DbContext(typeof(DBShopContext))]
    [Migration("202208131911_init")]
    public class _20220813_init : Migration
    {
        private void CreateItemsTable(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Items",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Id_provider = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Expiration_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Id_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_Items",
                        column: x => x.Id_provider,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.Cascade
                    );
                }
            );
        }

        private void CreateOrdersTable(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Orders",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Id_customer = table.Column<Guid>(nullable: false),
                    Id_item = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Id_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Orders",
                        column: x => x.Id_item,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Customers_Orders",
                        column: x => x.Id_customer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.Cascade
                    );
                }
            );
        }
        private void CreateProvidersTable(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Providers",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Id_Provider", x => x.Id);
                }
           );
        }

        private void CreateCustomersTable(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Customers",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surename = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Id_Customer", x => x.Id);
                }
           );
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CreateProvidersTable(migrationBuilder);
            CreateCustomersTable(migrationBuilder);
            CreateItemsTable(migrationBuilder);
            CreateOrdersTable(migrationBuilder);
        }
    }
}