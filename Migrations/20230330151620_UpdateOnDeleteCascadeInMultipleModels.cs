using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureWorksAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOnDeleteCascadeInMultipleModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID",
                schema: "SalesLT",
                table: "ProductModelProductDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModelProductDescription_ProductModel_ProductModelID",
                schema: "SalesLT",
                table: "ProductModelProductDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetail_Product_ProductID",
                schema: "SalesLT",
                table: "SalesOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderHeader_Customer_CustomerID",
                schema: "SalesLT",
                table: "SalesOrderHeader");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID",
                schema: "SalesLT",
                table: "ProductModelProductDescription",
                column: "ProductDescriptionID",
                principalSchema: "SalesLT",
                principalTable: "ProductDescription",
                principalColumn: "ProductDescriptionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModelProductDescription_ProductModel_ProductModelID",
                schema: "SalesLT",
                table: "ProductModelProductDescription",
                column: "ProductModelID",
                principalSchema: "SalesLT",
                principalTable: "ProductModel",
                principalColumn: "ProductModelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetail_Product_ProductID",
                schema: "SalesLT",
                table: "SalesOrderDetail",
                column: "ProductID",
                principalSchema: "SalesLT",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderHeader_Customer_CustomerID",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                column: "CustomerID",
                principalSchema: "SalesLT",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID",
                schema: "SalesLT",
                table: "ProductModelProductDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModelProductDescription_ProductModel_ProductModelID",
                schema: "SalesLT",
                table: "ProductModelProductDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetail_Product_ProductID",
                schema: "SalesLT",
                table: "SalesOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderHeader_Customer_CustomerID",
                schema: "SalesLT",
                table: "SalesOrderHeader");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID",
                schema: "SalesLT",
                table: "ProductModelProductDescription",
                column: "ProductDescriptionID",
                principalSchema: "SalesLT",
                principalTable: "ProductDescription",
                principalColumn: "ProductDescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModelProductDescription_ProductModel_ProductModelID",
                schema: "SalesLT",
                table: "ProductModelProductDescription",
                column: "ProductModelID",
                principalSchema: "SalesLT",
                principalTable: "ProductModel",
                principalColumn: "ProductModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetail_Product_ProductID",
                schema: "SalesLT",
                table: "SalesOrderDetail",
                column: "ProductID",
                principalSchema: "SalesLT",
                principalTable: "Product",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderHeader_Customer_CustomerID",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                column: "CustomerID",
                principalSchema: "SalesLT",
                principalTable: "Customer",
                principalColumn: "CustomerID");
        }
    }
}
