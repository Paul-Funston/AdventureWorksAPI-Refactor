using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureWorksAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOnDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Address_AddressID",
                schema: "SalesLT",
                table: "CustomerAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerID",
                schema: "SalesLT",
                table: "CustomerAddress");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "SalesLT",
                table: "ProductDescription",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDescription_ProductId",
                schema: "SalesLT",
                table: "ProductDescription",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Address_AddressID",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "AddressID",
                principalSchema: "SalesLT",
                principalTable: "Address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerID",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "CustomerID",
                principalSchema: "SalesLT",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDescription_Product_ProductId",
                schema: "SalesLT",
                table: "ProductDescription",
                column: "ProductId",
                principalSchema: "SalesLT",
                principalTable: "Product",
                principalColumn: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Address_AddressID",
                schema: "SalesLT",
                table: "CustomerAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerID",
                schema: "SalesLT",
                table: "CustomerAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDescription_Product_ProductId",
                schema: "SalesLT",
                table: "ProductDescription");

            migrationBuilder.DropIndex(
                name: "IX_ProductDescription_ProductId",
                schema: "SalesLT",
                table: "ProductDescription");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "SalesLT",
                table: "ProductDescription");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Address_AddressID",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "AddressID",
                principalSchema: "SalesLT",
                principalTable: "Address",
                principalColumn: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerID",
                schema: "SalesLT",
                table: "CustomerAddress",
                column: "CustomerID",
                principalSchema: "SalesLT",
                principalTable: "Customer",
                principalColumn: "CustomerID");
        }
    }
}
