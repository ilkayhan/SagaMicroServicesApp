using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction.API.Migrations
{
    /// <inheritdoc />
    public partial class TransactionDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRequests_Accounts_ReceiverAccountId",
                table: "TransactionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRequests_Accounts_SenderAccountId",
                table: "TransactionRequests");

            migrationBuilder.DropIndex(
                name: "IX_TransactionRequests_ReceiverAccountId",
                table: "TransactionRequests");

            migrationBuilder.DropIndex(
                name: "IX_TransactionRequests_SenderAccountId",
                table: "TransactionRequests");

            migrationBuilder.AddColumn<long>(
                name: "TransferId",
                table: "TransactionRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferId",
                table: "TransactionRequests");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRequests_ReceiverAccountId",
                table: "TransactionRequests",
                column: "ReceiverAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRequests_SenderAccountId",
                table: "TransactionRequests",
                column: "SenderAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRequests_Accounts_ReceiverAccountId",
                table: "TransactionRequests",
                column: "ReceiverAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRequests_Accounts_SenderAccountId",
                table: "TransactionRequests",
                column: "SenderAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
