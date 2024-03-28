using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddressMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Addresses_AddressId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_AddressId",
                table: "Members");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1d0a6add-d684-4bfb-809e-ff86790ecec5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0e63d0fe-d1c2-4d0d-b457-8c030db31a97"));

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "AddressMember",
                columns: table => new
                {
                    AddressesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressMember", x => new { x.AddressesId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_AddressMember_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f6f52612-d6bd-4cbc-a37b-54eb0dddabb0"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 75, 142, 170, 195, 252, 116, 15, 132, 169, 87, 54, 59, 234, 208, 148, 62, 75, 240, 160, 40, 138, 214, 10, 91, 175, 139, 24, 129, 176, 116, 6, 110, 202, 12, 242, 58, 247, 81, 53, 139, 0, 41, 184, 21, 161, 214, 245, 140, 212, 156, 110, 62, 27, 195, 89, 40, 178, 226, 168, 98, 158, 174, 60, 43 }, new byte[] { 49, 156, 239, 127, 141, 112, 188, 205, 50, 157, 3, 234, 197, 154, 107, 236, 253, 127, 138, 174, 25, 32, 247, 254, 134, 126, 111, 32, 207, 89, 222, 73, 110, 75, 229, 151, 35, 95, 165, 0, 139, 253, 96, 223, 0, 96, 67, 250, 157, 252, 194, 5, 131, 66, 135, 20, 182, 202, 245, 134, 247, 87, 76, 226, 78, 9, 30, 178, 49, 43, 50, 46, 52, 9, 94, 100, 186, 186, 205, 90, 14, 223, 66, 179, 142, 125, 86, 181, 8, 34, 64, 211, 237, 194, 145, 59, 121, 135, 213, 12, 165, 32, 35, 30, 169, 170, 34, 93, 108, 30, 65, 93, 239, 171, 186, 230, 185, 118, 207, 74, 81, 115, 205, 113, 162, 62, 121, 150 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("55787242-689a-41d4-8425-48e053d9d1c3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f6f52612-d6bd-4cbc-a37b-54eb0dddabb0") });

            migrationBuilder.CreateIndex(
                name: "IX_AddressMember_MembersId",
                table: "AddressMember",
                column: "MembersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressMember");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("55787242-689a-41d4-8425-48e053d9d1c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f6f52612-d6bd-4cbc-a37b-54eb0dddabb0"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0e63d0fe-d1c2-4d0d-b457-8c030db31a97"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 86, 76, 212, 47, 126, 196, 99, 174, 105, 171, 113, 32, 37, 119, 174, 171, 135, 133, 68, 22, 26, 206, 150, 136, 130, 147, 87, 86, 200, 207, 186, 175, 124, 93, 23, 28, 233, 199, 154, 31, 104, 224, 7, 72, 172, 221, 128, 71, 207, 205, 223, 132, 146, 110, 66, 255, 170, 164, 7, 120, 32, 52, 166, 100 }, new byte[] { 51, 81, 106, 146, 43, 38, 76, 68, 60, 170, 87, 133, 180, 233, 19, 229, 45, 239, 155, 10, 219, 42, 138, 97, 91, 45, 204, 11, 8, 19, 43, 104, 46, 81, 115, 15, 45, 111, 33, 63, 248, 225, 134, 207, 10, 89, 176, 221, 53, 252, 57, 6, 113, 69, 18, 68, 90, 39, 7, 31, 229, 20, 85, 20, 187, 129, 111, 210, 46, 49, 214, 100, 250, 44, 18, 108, 152, 235, 82, 21, 113, 254, 58, 242, 35, 205, 225, 188, 78, 168, 164, 134, 254, 120, 30, 96, 52, 73, 170, 187, 173, 203, 216, 122, 177, 58, 27, 24, 251, 59, 28, 249, 115, 40, 46, 77, 187, 121, 161, 144, 145, 151, 146, 37, 65, 220, 92, 18 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1d0a6add-d684-4bfb-809e-ff86790ecec5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0e63d0fe-d1c2-4d0d-b457-8c030db31a97") });

            migrationBuilder.CreateIndex(
                name: "IX_Members_AddressId",
                table: "Members",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Addresses_AddressId",
                table: "Members",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
