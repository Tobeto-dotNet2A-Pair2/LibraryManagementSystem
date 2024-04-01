using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("73124fe0-3e9c-4086-ba8d-dcf8c9197e8a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("451f4ea4-91a1-49ff-a584-d4fe5e2ebda9"));

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Penalty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberNotification",
                columns: table => new
                {
                    MembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberNotification", x => new { x.MembersId, x.NotificationsId });
                    table.ForeignKey(
                        name: "FK_MemberNotification_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberNotification_Notifications_NotificationsId",
                        column: x => x.NotificationsId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Admin", null },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Read", null },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Write", null },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Create", null },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Update", null },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Notifications.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("a781eab9-0b48-4ea1-96bd-8bd4a56e4763"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 223, 128, 156, 143, 152, 134, 238, 233, 172, 249, 33, 225, 223, 227, 17, 195, 115, 23, 140, 32, 248, 168, 103, 135, 39, 237, 85, 17, 183, 201, 175, 86, 51, 88, 29, 246, 76, 120, 179, 208, 10, 119, 52, 166, 30, 4, 76, 187, 60, 158, 29, 82, 237, 185, 143, 69, 114, 49, 61, 197, 6, 204, 218, 110 }, new byte[] { 247, 226, 81, 96, 193, 124, 7, 13, 193, 179, 86, 54, 46, 233, 6, 1, 179, 236, 206, 92, 204, 81, 205, 34, 88, 54, 180, 73, 232, 178, 10, 146, 204, 126, 193, 243, 30, 37, 7, 113, 110, 190, 40, 69, 110, 19, 218, 232, 208, 130, 133, 100, 31, 161, 35, 150, 151, 213, 222, 79, 6, 97, 244, 181, 49, 252, 211, 156, 34, 118, 247, 111, 82, 255, 229, 225, 222, 249, 164, 32, 95, 218, 149, 6, 193, 106, 133, 139, 192, 221, 191, 222, 6, 78, 15, 165, 243, 14, 249, 227, 35, 203, 100, 0, 183, 62, 117, 12, 3, 119, 255, 116, 153, 42, 92, 177, 99, 54, 242, 59, 108, 166, 252, 206, 194, 136, 218, 33 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c154c58f-a023-4a39-8870-eccb9c6c89e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a781eab9-0b48-4ea1-96bd-8bd4a56e4763") });

            migrationBuilder.CreateIndex(
                name: "IX_MemberNotification_NotificationsId",
                table: "MemberNotification",
                column: "NotificationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberNotification");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c154c58f-a023-4a39-8870-eccb9c6c89e2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a781eab9-0b48-4ea1-96bd-8bd4a56e4763"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("451f4ea4-91a1-49ff-a584-d4fe5e2ebda9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 32, 254, 239, 85, 18, 170, 228, 160, 162, 57, 138, 82, 210, 225, 54, 149, 154, 6, 46, 40, 104, 48, 174, 129, 175, 39, 130, 76, 135, 158, 145, 241, 117, 146, 243, 216, 139, 254, 176, 134, 225, 210, 55, 232, 94, 32, 196, 205, 204, 102, 213, 187, 10, 157, 136, 246, 0, 82, 56, 184, 155, 102, 169, 30 }, new byte[] { 69, 55, 101, 93, 7, 118, 82, 211, 1, 147, 108, 79, 11, 86, 250, 106, 73, 182, 229, 176, 70, 146, 95, 114, 210, 205, 204, 95, 130, 144, 21, 232, 186, 64, 129, 107, 252, 242, 126, 74, 213, 53, 27, 124, 47, 169, 16, 252, 222, 214, 185, 166, 170, 43, 206, 40, 114, 64, 203, 172, 148, 177, 16, 43, 95, 226, 34, 53, 21, 106, 39, 129, 220, 92, 5, 50, 245, 235, 123, 192, 198, 174, 130, 253, 143, 37, 60, 218, 237, 106, 21, 129, 104, 130, 61, 245, 49, 233, 27, 20, 42, 167, 214, 153, 55, 178, 1, 139, 105, 109, 187, 157, 237, 159, 148, 204, 100, 216, 111, 151, 114, 122, 103, 17, 120, 105, 215, 113 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("73124fe0-3e9c-4086-ba8d-dcf8c9197e8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("451f4ea4-91a1-49ff-a584-d4fe5e2ebda9") });
        }
    }
}
