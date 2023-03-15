using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class reworkrecordsinrentaltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PeselNumber",
                table: "Rentals",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "ContactNumber",
                table: "Rentals",
                type: "int",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 9);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PeselNumber",
                table: "Rentals",
                type: "decimal(18,2)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<decimal>(
                name: "ContactNumber",
                table: "Rentals",
                type: "decimal(18,2)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 9);
        }
    }
}
