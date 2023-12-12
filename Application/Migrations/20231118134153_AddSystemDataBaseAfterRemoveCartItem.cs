using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class AddSystemDataBaseAfterRemoveCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AuthenticatedUsers_UserId1",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_CartItem_CartItemId1",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CartItemId1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserId1",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CartItemId1",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "CartItemId",
                table: "CartItem",
                newName: "ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "CartItem",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CartItem",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "CartItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                columns: new[] { "UserId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                columns: new[] { "UserId", "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Order_UserId_OrderId",
                table: "CartItem",
                columns: new[] { "UserId", "OrderId" },
                principalTable: "Order",
                principalColumns: new[] { "UserId", "OrderId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AuthenticatedUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AuthenticatedUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Order_UserId_OrderId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AuthenticatedUsers_UserId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItem",
                newName: "CartItemId");

            migrationBuilder.AddColumn<string>(
                name: "CartItemId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CartItemId1",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "CartItem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CartItemId1",
                table: "Order",
                column: "CartItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId1",
                table: "Order",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AuthenticatedUsers_UserId1",
                table: "Order",
                column: "UserId1",
                principalTable: "AuthenticatedUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_CartItem_CartItemId1",
                table: "Order",
                column: "CartItemId1",
                principalTable: "CartItem",
                principalColumn: "CartItemId");
        }
    }
}
