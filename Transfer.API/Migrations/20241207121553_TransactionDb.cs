using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transfer.API.Migrations
{
    /// <inheritdoc />
    public partial class TransactionDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferRequest_Accounts_ReceiverAccountId",
                table: "TransferRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferRequest_Accounts_SenderAccountId",
                table: "TransferRequest");

            migrationBuilder.DropIndex(
                name: "IX_TransferRequest_ReceiverAccountId",
                table: "TransferRequest");

            migrationBuilder.DropIndex(
                name: "IX_TransferRequest_SenderAccountId",
                table: "TransferRequest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TransferRequest_ReceiverAccountId",
                table: "TransferRequest",
                column: "ReceiverAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequest_SenderAccountId",
                table: "TransferRequest",
                column: "SenderAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRequest_Accounts_ReceiverAccountId",
                table: "TransferRequest",
                column: "ReceiverAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRequest_Accounts_SenderAccountId",
                table: "TransferRequest",
                column: "SenderAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
