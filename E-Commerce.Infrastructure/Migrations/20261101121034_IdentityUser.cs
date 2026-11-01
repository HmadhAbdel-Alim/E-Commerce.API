using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Reviews",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ProductTypes",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Products",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ProductBrands",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Payments",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Orders",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "OrderItems",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "DeliveryMethods",
                newName: "DeleteAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "Reviews",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "ProductTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "Products",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "ProductBrands",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "Payments",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "Orders",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "OrderItems",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "DeliveryMethods",
                newName: "DeletedAt");
        }
    }
}
