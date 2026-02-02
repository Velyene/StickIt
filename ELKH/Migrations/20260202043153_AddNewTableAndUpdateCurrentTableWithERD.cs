using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELKH.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableAndUpdateCurrentTableWithERD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_RegisteredUsers_FkRegisteredUserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Transactions_FkTransactionId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FkTransactionId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_FkRegisteredUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "RegisteredUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "RegisteredUsers");

            migrationBuilder.RenameColumn(
                name: "FkTransactionId",
                table: "Orders",
                newName: "FkContactId");

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailPkContactId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliberyFee",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FkContactId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkOrderId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkWishListId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WishListPkWishListId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailPkContactId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkProductID",
                table: "Carts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductPkProductId",
                table: "Carts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegisteredUserPkRegisteredUserId",
                table: "Carts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    PkContactId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
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
                    table.PrimaryKey("PK_ContactDetails", x => x.PkContactId);
                    table.ForeignKey(
                        name: "FK_ContactDetails_RegisteredUsers_RegisiteredUserPkRegisteredUserId",
                        column: x => x.RegisiteredUserPkRegisteredUserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "PkRegisteredUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatusName = table.Column<string>(type: "TEXT", nullable: false),
                    FkOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
                    table.ForeignKey(
                        name: "FK_OrderStatuses_Orders_FkOrderId",
                        column: x => x.FkOrderId,
                        principalTable: "Orders",
                        principalColumn: "PkOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    PkWishListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.PkWishListId);
                    table.ForeignKey(
                        name: "FK_WishLists_RegisteredUsers_FkUserId",
                        column: x => x.FkUserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "PkRegisteredUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ContactDetailPkContactId",
                table: "Transactions",
                column: "ContactDetailPkContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FkOrderId",
                table: "Transactions",
                column: "FkOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_WishListPkWishListId",
                table: "Products",
                column: "WishListPkWishListId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContactDetailPkContactId",
                table: "Orders",
                column: "ContactDetailPkContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductPkProductId",
                table: "Carts",
                column: "ProductPkProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_RegisteredUserPkRegisteredUserId",
                table: "Carts",
                column: "RegisteredUserPkRegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_RegisiteredUserPkRegisteredUserId",
                table: "ContactDetails",
                column: "RegisiteredUserPkRegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuses_FkOrderId",
                table: "OrderStatuses",
                column: "FkOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_FkUserId",
                table: "WishLists",
                column: "FkUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductPkProductId",
                table: "Carts",
                column: "ProductPkProductId",
                principalTable: "Products",
                principalColumn: "PkProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_RegisteredUsers_RegisteredUserPkRegisteredUserId",
                table: "Carts",
                column: "RegisteredUserPkRegisteredUserId",
                principalTable: "RegisteredUsers",
                principalColumn: "PkRegisteredUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ContactDetails_ContactDetailPkContactId",
                table: "Orders",
                column: "ContactDetailPkContactId",
                principalTable: "ContactDetails",
                principalColumn: "PkContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WishLists_WishListPkWishListId",
                table: "Products",
                column: "WishListPkWishListId",
                principalTable: "WishLists",
                principalColumn: "PkWishListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ContactDetails_ContactDetailPkContactId",
                table: "Transactions",
                column: "ContactDetailPkContactId",
                principalTable: "ContactDetails",
                principalColumn: "PkContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Orders_FkOrderId",
                table: "Transactions",
                column: "FkOrderId",
                principalTable: "Orders",
                principalColumn: "PkOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductPkProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_RegisteredUsers_RegisteredUserPkRegisteredUserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ContactDetails_ContactDetailPkContactId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_WishLists_WishListPkWishListId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ContactDetails_ContactDetailPkContactId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Orders_FkOrderId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ContactDetailPkContactId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_FkOrderId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Products_WishListPkWishListId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ContactDetailPkContactId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProductPkProductId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_RegisteredUserPkRegisteredUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ContactDetailPkContactId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeliberyFee",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FkContactId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FkOrderId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FkWishListId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WishListPkWishListId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContactDetailPkContactId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FkProductID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ProductPkProductId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "RegisteredUserPkRegisteredUserId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "FkContactId",
                table: "Orders",
                newName: "FkTransactionId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "RegisteredUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "RegisteredUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    PkAddressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegisiteredUserPkRegisteredUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    FkRegisteredUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false),
                    Province = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "CartItems",
                columns: table => new
                {
                    PkCartItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartPkCartId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductPkProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    FkCartId = table.Column<int>(type: "INTEGER", nullable: false),
                    FkProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantities = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressPkAddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    FkOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryStatus = table.Column<string>(type: "TEXT", nullable: false),
                    FkAddressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryId);
                    table.ForeignKey(
                        name: "FK_Deliveries_Addresses_AddressPkAddressId",
                        column: x => x.AddressPkAddressId,
                        principalTable: "Addresses",
                        principalColumn: "PkAddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Orders_FkOrderId",
                        column: x => x.FkOrderId,
                        principalTable: "Orders",
                        principalColumn: "PkOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FkTransactionId",
                table: "Orders",
                column: "FkTransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_FkRegisteredUserId",
                table: "Carts",
                column: "FkRegisteredUserId",
                unique: true);

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
                name: "IX_Deliveries_AddressPkAddressId",
                table: "Deliveries",
                column: "AddressPkAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_FkOrderId",
                table: "Deliveries",
                column: "FkOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_RegisteredUsers_FkRegisteredUserId",
                table: "Carts",
                column: "FkRegisteredUserId",
                principalTable: "RegisteredUsers",
                principalColumn: "PkRegisteredUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Transactions_FkTransactionId",
                table: "Orders",
                column: "FkTransactionId",
                principalTable: "Transactions",
                principalColumn: "PkTransactionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
