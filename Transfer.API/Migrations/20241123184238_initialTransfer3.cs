using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transfer.API.Migrations
{
    /// <inheritdoc />
    public partial class initialTransfer3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferRequest_Accounts_ReceiverId",
                table: "TransferRequest");

            migrationBuilder.DropIndex(
                name: "IX_TransferRequest_ReceiverId",
                table: "TransferRequest");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "TransferRequest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReceiverId",
                table: "TransferRequest",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequest_ReceiverId",
                table: "TransferRequest",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRequest_Accounts_ReceiverId",
                table: "TransferRequest",
                column: "ReceiverId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
