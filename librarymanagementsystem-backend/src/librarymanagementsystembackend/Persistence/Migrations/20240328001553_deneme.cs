using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Addresses_Id",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Addresses_Id",
                table: "Members");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b2d87683-6cf5-44a4-a867-bdd79cf2ee06"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5adf9bf-b05c-4604-a889-e740675db9f1"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Branches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("88fd462c-c409-4a62-91ac-61c5f8e509ee"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 98, 150, 168, 203, 137, 136, 135, 116, 107, 159, 134, 25, 11, 254, 4, 3, 253, 154, 229, 120, 169, 13, 98, 71, 140, 218, 118, 217, 55, 197, 62, 159, 3, 176, 87, 69, 93, 171, 131, 133, 61, 226, 57, 195, 58, 201, 24, 54, 37, 158, 141, 193, 60, 92, 158, 101, 23, 178, 141, 215, 47, 52, 233, 128 }, new byte[] { 188, 77, 173, 62, 57, 250, 113, 11, 12, 235, 176, 68, 127, 29, 94, 50, 16, 228, 63, 228, 235, 139, 94, 74, 112, 14, 227, 248, 72, 79, 148, 74, 111, 32, 5, 32, 30, 38, 121, 20, 53, 46, 241, 245, 157, 49, 249, 135, 55, 29, 23, 88, 109, 28, 214, 98, 26, 174, 178, 102, 65, 52, 198, 45, 238, 12, 107, 215, 117, 69, 245, 13, 208, 188, 19, 168, 31, 43, 121, 236, 65, 206, 49, 28, 215, 178, 101, 39, 217, 189, 157, 189, 10, 217, 118, 92, 243, 15, 85, 186, 47, 132, 46, 70, 222, 231, 41, 21, 86, 7, 220, 128, 91, 72, 98, 152, 237, 53, 157, 34, 247, 169, 195, 79, 127, 30, 166, 94 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("91687d4d-025a-402a-b4d0-35f1567fe106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("88fd462c-c409-4a62-91ac-61c5f8e509ee") });

            migrationBuilder.CreateIndex(
                name: "IX_Members_AddressId",
                table: "Members",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_AddressId",
                table: "Branches",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Addresses_AddressId",
                table: "Branches",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Addresses_AddressId",
                table: "Members",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Addresses_AddressId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Addresses_AddressId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_AddressId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Branches_AddressId",
                table: "Branches");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("91687d4d-025a-402a-b4d0-35f1567fe106"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("88fd462c-c409-4a62-91ac-61c5f8e509ee"));

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Branches");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f5adf9bf-b05c-4604-a889-e740675db9f1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 253, 149, 230, 213, 5, 153, 113, 33, 112, 246, 91, 63, 73, 204, 159, 192, 119, 228, 63, 62, 228, 224, 174, 236, 63, 140, 157, 255, 29, 204, 186, 24, 246, 251, 157, 104, 208, 179, 103, 140, 123, 8, 175, 56, 120, 250, 18, 191, 222, 138, 221, 221, 146, 250, 86, 197, 47, 33, 133, 195, 26, 93, 202, 110 }, new byte[] { 37, 66, 127, 131, 129, 63, 203, 172, 28, 3, 88, 53, 189, 67, 129, 211, 30, 161, 172, 109, 174, 53, 66, 30, 127, 48, 25, 10, 252, 126, 87, 64, 25, 40, 44, 151, 14, 238, 159, 145, 102, 54, 114, 12, 198, 46, 208, 115, 126, 65, 102, 237, 65, 43, 135, 85, 239, 87, 219, 123, 27, 231, 3, 16, 117, 82, 98, 3, 207, 27, 157, 1, 105, 129, 71, 203, 43, 199, 135, 146, 78, 125, 53, 230, 24, 61, 109, 80, 152, 254, 76, 114, 194, 212, 14, 116, 141, 33, 171, 11, 250, 136, 144, 108, 117, 87, 28, 204, 105, 53, 214, 49, 60, 197, 39, 41, 108, 38, 27, 117, 172, 65, 198, 25, 189, 97, 234, 1 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("b2d87683-6cf5-44a4-a867-bdd79cf2ee06"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f5adf9bf-b05c-4604-a889-e740675db9f1") });

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Addresses_Id",
                table: "Branches",
                column: "Id",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Addresses_Id",
                table: "Members",
                column: "Id",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
