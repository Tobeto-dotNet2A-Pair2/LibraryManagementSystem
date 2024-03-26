using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6f163d25-f953-450e-990f-f7329f47edc3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("473def74-3b4d-47ed-b8ff-1ce262324f56"));

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("8d74cba0-e8c2-416f-bb8c-dd2fdc63971c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 230, 213, 39, 76, 174, 90, 5, 39, 168, 134, 85, 55, 238, 39, 5, 132, 87, 124, 33, 76, 22, 107, 113, 126, 169, 107, 3, 224, 113, 58, 86, 189, 176, 7, 214, 100, 73, 135, 78, 184, 209, 102, 165, 87, 11, 135, 22, 68, 44, 92, 91, 211, 160, 227, 174, 205, 220, 184, 243, 190, 98, 3, 157, 247 }, new byte[] { 139, 150, 222, 78, 34, 193, 169, 246, 248, 208, 205, 35, 168, 227, 87, 165, 247, 174, 13, 75, 107, 133, 240, 0, 247, 213, 225, 38, 73, 251, 185, 4, 64, 160, 54, 118, 171, 177, 49, 236, 13, 36, 8, 151, 40, 184, 92, 239, 72, 75, 253, 117, 49, 63, 127, 149, 138, 211, 54, 13, 231, 24, 96, 5, 40, 203, 173, 3, 193, 22, 58, 155, 12, 48, 51, 117, 32, 176, 75, 184, 188, 10, 79, 6, 197, 91, 67, 132, 244, 37, 64, 110, 64, 114, 62, 232, 143, 75, 236, 144, 240, 140, 87, 241, 205, 88, 195, 73, 243, 207, 171, 16, 244, 214, 213, 192, 28, 139, 79, 220, 230, 69, 18, 155, 180, 216, 223, 196 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3ba23725-9d96-4679-8da3-15136176db97"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("8d74cba0-e8c2-416f-bb8c-dd2fdc63971c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3ba23725-9d96-4679-8da3-15136176db97"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d74cba0-e8c2-416f-bb8c-dd2fdc63971c"));

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Members");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("473def74-3b4d-47ed-b8ff-1ce262324f56"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 18, 169, 183, 185, 249, 157, 120, 248, 105, 209, 92, 17, 133, 3, 216, 127, 4, 83, 152, 210, 179, 220, 186, 86, 132, 98, 68, 64, 206, 231, 228, 83, 91, 126, 28, 242, 220, 141, 193, 89, 168, 129, 70, 19, 103, 218, 121, 11, 40, 34, 2, 171, 49, 220, 38, 147, 221, 108, 111, 124, 86, 94, 30, 100 }, new byte[] { 108, 255, 71, 151, 33, 93, 29, 93, 203, 139, 72, 37, 245, 112, 87, 253, 97, 27, 81, 167, 93, 82, 1, 45, 6, 196, 107, 81, 173, 216, 116, 9, 209, 241, 137, 12, 129, 143, 163, 139, 194, 131, 25, 180, 206, 209, 117, 49, 54, 25, 244, 121, 121, 103, 51, 63, 203, 146, 46, 100, 150, 219, 200, 110, 187, 174, 221, 160, 224, 140, 146, 131, 69, 192, 114, 153, 179, 224, 148, 252, 158, 118, 43, 30, 147, 6, 149, 124, 196, 98, 122, 81, 128, 209, 57, 52, 94, 30, 154, 208, 32, 174, 108, 197, 135, 80, 171, 240, 209, 244, 43, 26, 212, 219, 255, 15, 86, 50, 159, 129, 42, 179, 181, 157, 178, 140, 71, 91 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6f163d25-f953-450e-990f-f7329f47edc3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("473def74-3b4d-47ed-b8ff-1ce262324f56") });
        }
    }
}
