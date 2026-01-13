using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELKH.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    PkCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.PkCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredUsers",
                columns: table => new
                {
                    PkRegisteredUserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUsers", x => x.PkRegisteredUserId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    PkTransactionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionStatus = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.PkTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PkProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    FkCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriePkCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PkProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoriePkCategoryId",
                        column: x => x.CategoriePkCategoryId,
                        principalTable: "Categories",
                        principalColumn: "PkCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    PkAddressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Province = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    FkRegisteredUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisiteredUserPkRegisteredUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.PkAddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_RegisteredUsers_RegisiteredUserPkRegisteredUserId",
                        column: x => x.RegisiteredUserPkRegisteredUserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "PkRegisteredUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    PkCartId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkRegisteredUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.PkCartId);
                    table.ForeignKey(
                        name: "FK_Carts_RegisteredUsers_FkRegisteredUserId",
                        column: x => x.FkRegisteredUserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "PkRegisteredUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    PkOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderStatus = table.Column<string>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FkRegisteredUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisteredUserPkRegisteredUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    FkTransactionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.PkOrderId);
                    table.ForeignKey(
                        name: "FK_Orders_RegisteredUsers_RegisteredUserPkRegisteredUserId",
                        column: x => x.RegisteredUserPkRegisteredUserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "PkRegisteredUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Transactions_FkTransactionId",
                        column: x => x.FkTransactionId,
                        principalTable: "Transactions",
                        principalColumn: "PkTransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    PkProductImageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    FkProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductPkProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.PkProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductPkProductId",
                        column: x => x.ProductPkProductId,
                        principalTable: "Products",
                        principalColumn: "PkProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    PkCartItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantities = table.Column<int>(type: "INTEGER", nullable: false),
                    FkCartId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartPkCartId = table.Column<int>(type: "INTEGER", nullable: false),
                    FkProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductPkProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.PkCartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartPkCartId",
                        column: x => x.CartPkCartId,
                        principalTable: "Carts",
                        principalColumn: "PkCartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductPkProductId",
                        column: x => x.ProductPkProductId,
                        principalTable: "Products",
                        principalColumn: "PkProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    PkOrderItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    FkOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdersPkOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.PkOrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrdersPkOrderId",
                        column: x => x.OrdersPkOrderId,
                        principalTable: "Orders",
                        principalColumn: "PkOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_RegisiteredUserPkRegisteredUserId",
                table: "Addresses",
                column: "RegisiteredUserPkRegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartPkCartId",
                table: "CartItems",
                column: "CartPkCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductPkProductId",
                table: "CartItems",
                column: "ProductPkProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_FkRegisteredUserId",
                table: "Carts",
                column: "FkRegisteredUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrdersPkOrderId",
                table: "OrderItems",
                column: "OrdersPkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FkTransactionId",
                table: "Orders",
                column: "FkTransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RegisteredUserPkRegisteredUserId",
                table: "Orders",
                column: "RegisteredUserPkRegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductPkProductId",
                table: "ProductImages",
                column: "ProductPkProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriePkCategoryId",
                table: "Products",
                column: "CategoriePkCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
