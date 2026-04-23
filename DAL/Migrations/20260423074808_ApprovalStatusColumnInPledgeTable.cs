using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChurchPlusAPI_v1._0.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalStatusColumnInPledgeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Pledges",
                newName: "PledgeStatus");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPledged",
                table: "Pledges",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualAmountFulfilled",
                table: "Pledges",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Pledges",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Pledges");

            migrationBuilder.RenameColumn(
                name: "PledgeStatus",
                table: "Pledges",
                newName: "Status");

            migrationBuilder.AlterColumn<double>(
                name: "AmountPledged",
                table: "Pledges",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "ActualAmountFulfilled",
                table: "Pledges",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
