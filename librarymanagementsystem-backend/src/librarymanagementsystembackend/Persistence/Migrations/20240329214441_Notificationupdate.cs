using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Notificationupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c154c58f-a023-4a39-8870-eccb9c6c89e2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a781eab9-0b48-4ea1-96bd-8bd4a56e4763"));

            migrationBuilder.DropColumn(
                name: "Penalty",
                table: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "PenaltyId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Penalty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountPenalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DayDelay = table.Column<int>(type: "int", nullable: false),
                    FirstDayPunishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPenalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalty", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Admin", null },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Read", null },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Write", null },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Create", null },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Update", null },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0d229e20-4940-4e38-81af-b2c5902ae00f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 63, 74, 244, 54, 122, 218, 237, 192, 16, 54, 95, 247, 103, 167, 248, 168, 211, 29, 30, 164, 192, 173, 138, 116, 179, 155, 152, 125, 180, 216, 39, 6, 98, 253, 49, 145, 209, 79, 9, 122, 212, 128, 174, 190, 138, 211, 237, 204, 253, 48, 231, 59, 230, 134, 31, 239, 197, 57, 227, 100, 63, 210, 125, 212 }, new byte[] { 187, 72, 41, 235, 137, 172, 80, 77, 144, 11, 137, 62, 219, 241, 67, 166, 117, 220, 71, 192, 62, 49, 139, 124, 249, 165, 232, 110, 107, 43, 121, 68, 104, 234, 23, 111, 53, 150, 42, 172, 126, 45, 168, 202, 157, 127, 93, 127, 205, 48, 70, 185, 128, 158, 2, 201, 153, 97, 129, 174, 3, 160, 174, 231, 133, 66, 237, 104, 73, 95, 108, 23, 235, 213, 31, 132, 197, 12, 196, 43, 79, 111, 79, 43, 45, 217, 160, 252, 48, 124, 237, 4, 85, 88, 12, 182, 47, 172, 51, 120, 89, 180, 117, 195, 232, 0, 25, 109, 185, 175, 118, 2, 193, 153, 198, 71, 207, 122, 24, 24, 137, 132, 79, 9, 67, 12, 210, 223 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9ec486f6-4b82-410a-b03b-619f3dd301ec"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0d229e20-4940-4e38-81af-b2c5902ae00f") });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PenaltyId",
                table: "Notifications",
                column: "PenaltyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Penalty_PenaltyId",
                table: "Notifications",
                column: "PenaltyId",
                principalTable: "Penalty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Penalty_PenaltyId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "Penalty");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_PenaltyId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9ec486f6-4b82-410a-b03b-619f3dd301ec"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0d229e20-4940-4e38-81af-b2c5902ae00f"));

            migrationBuilder.DropColumn(
                name: "PenaltyId",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "Penalty",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("a781eab9-0b48-4ea1-96bd-8bd4a56e4763"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 223, 128, 156, 143, 152, 134, 238, 233, 172, 249, 33, 225, 223, 227, 17, 195, 115, 23, 140, 32, 248, 168, 103, 135, 39, 237, 85, 17, 183, 201, 175, 86, 51, 88, 29, 246, 76, 120, 179, 208, 10, 119, 52, 166, 30, 4, 76, 187, 60, 158, 29, 82, 237, 185, 143, 69, 114, 49, 61, 197, 6, 204, 218, 110 }, new byte[] { 247, 226, 81, 96, 193, 124, 7, 13, 193, 179, 86, 54, 46, 233, 6, 1, 179, 236, 206, 92, 204, 81, 205, 34, 88, 54, 180, 73, 232, 178, 10, 146, 204, 126, 193, 243, 30, 37, 7, 113, 110, 190, 40, 69, 110, 19, 218, 232, 208, 130, 133, 100, 31, 161, 35, 150, 151, 213, 222, 79, 6, 97, 244, 181, 49, 252, 211, 156, 34, 118, 247, 111, 82, 255, 229, 225, 222, 249, 164, 32, 95, 218, 149, 6, 193, 106, 133, 139, 192, 221, 191, 222, 6, 78, 15, 165, 243, 14, 249, 227, 35, 203, 100, 0, 183, 62, 117, 12, 3, 119, 255, 116, 153, 42, 92, 177, 99, 54, 242, 59, 108, 166, 252, 206, 194, 136, 218, 33 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c154c58f-a023-4a39-8870-eccb9c6c89e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a781eab9-0b48-4ea1-96bd-8bd4a56e4763") });
        }
    }
}
