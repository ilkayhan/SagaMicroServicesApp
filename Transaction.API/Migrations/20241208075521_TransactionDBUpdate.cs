using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction.API.Migrations
{
    /// <inheritdoc />
    public partial class TransactionDBUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "TransactionRequests");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "TransactionRequests");

            migrationBuilder.DropColumn(
                name: "ReceiverAccountId",
                table: "TransactionRequests");

            migrationBuilder.DropColumn(
                name: "SenderAccountId",
                table: "TransactionRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "TransactionRequests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "TransactionRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ReceiverAccountId",
                table: "TransactionRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SenderAccountId",
                table: "TransactionRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
