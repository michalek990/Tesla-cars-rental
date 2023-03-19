using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class addrentalcost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rentals_EndRentalPointId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_StartRentalPointId",
                table: "Rentals");

            migrationBuilder.AlterColumn<string>(
                name: "PeselNumber",
                table: "Rentals",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContactNumber",
                table: "Rentals",
                type: "int",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 9);

            migrationBuilder.AddColumn<double>(
                name: "TotalCostOfRent",
                table: "Rentals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CostPerDay",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_EndRentalPointId",
                table: "Rentals",
                column: "EndRentalPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_StartRentalPointId",
                table: "Rentals",
                column: "StartRentalPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rentals_EndRentalPointId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_StartRentalPointId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "TotalCostOfRent",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "CostPerDay",
                table: "Cars");

            migrationBuilder.AlterColumn<decimal>(
                name: "PeselNumber",
                table: "Rentals",
                type: "decimal(18,2)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "Nationality",
                table: "Rentals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Rentals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ContactNumber",
                table: "Rentals",
                type: "decimal(18,2)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 9);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_EndRentalPointId",
                table: "Rentals",
                column: "EndRentalPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_StartRentalPointId",
                table: "Rentals",
                column: "StartRentalPointId",
                unique: true);
        }
    }
}
