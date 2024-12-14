using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transfer.API.Migrations
{
    /// <inheritdoc />
    public partial class initialTransfer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRequests_Accounts_ReceiverAccountId",
                table: "TransactionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRequests_Accounts_ReceiverId",
                table: "TransactionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionRequests_Accounts_SenderAccountId",
                table: "TransactionRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionRequests",
                table: "TransactionRequests");

            migrationBuilder.RenameTable(
                name: "TransactionRequests",
                newName: "TransferRequest");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionRequests_SenderAccountId",
                table: "TransferRequest",
                newName: "IX_TransferRequest_SenderAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionRequests_ReceiverId",
                table: "TransferRequest",
                newName: "IX_TransferRequest_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionRequests_ReceiverAccountId",
                table: "TransferRequest",
                newName: "IX_TransferRequest_ReceiverAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransferRequest",
                table: "TransferRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRequest_Accounts_ReceiverAccountId",
                table: "TransferRequest",
                column: "ReceiverAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRequest_Accounts_ReceiverId",
                table: "TransferRequest",
                column: "ReceiverId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRequest_Accounts_SenderAccountId",
                table: "TransferRequest",
                column: "SenderAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferRequest_Accounts_ReceiverAccountId",
                table: "TransferRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferRequest_Accounts_ReceiverId",
                table: "TransferRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferRequest_Accounts_SenderAccountId",
                table: "TransferRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransferRequest",
                table: "TransferRequest");

            migrationBuilder.RenameTable(
                name: "TransferRequest",
                newName: "TransactionRequests");

            migrationBuilder.RenameIndex(
                name: "IX_TransferRequest_SenderAccountId",
                table: "TransactionRequests",
                newName: "IX_TransactionRequests_SenderAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferRequest_ReceiverId",
                table: "TransactionRequests",
                newName: "IX_TransactionRequests_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferRequest_ReceiverAccountId",
                table: "TransactionRequests",
                newName: "IX_TransactionRequests_ReceiverAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionRequests",
                table: "TransactionRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRequests_Accounts_ReceiverAccountId",
                table: "TransactionRequests",
                column: "ReceiverAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionRequests_Accounts_ReceiverId",
                table: "TransactionRequests",
                column: "ReceiverId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
