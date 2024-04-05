using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class memberconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9da90339-f726-417e-a19c-bd3098936bb4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e8448a44-3358-42e4-88d0-91c385d28608"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("333e4d9f-b265-4e89-9d93-9b88dd10c2b0"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 194, 254, 88, 137, 197, 83, 121, 249, 12, 34, 173, 222, 200, 82, 34, 211, 145, 71, 206, 146, 81, 66, 214, 185, 52, 205, 1, 56, 79, 171, 232, 153, 87, 123, 249, 155, 188, 232, 38, 8, 79, 26, 116, 162, 78, 66, 220, 141, 255, 13, 15, 63, 129, 116, 126, 160, 194, 127, 61, 95, 33, 84, 119, 94 }, new byte[] { 55, 212, 85, 204, 140, 88, 246, 210, 25, 98, 174, 49, 55, 162, 82, 112, 209, 78, 14, 128, 192, 210, 1, 118, 250, 54, 83, 134, 202, 165, 239, 56, 237, 53, 176, 2, 219, 213, 110, 132, 87, 92, 216, 210, 73, 184, 33, 185, 225, 241, 213, 106, 132, 12, 241, 65, 58, 194, 54, 197, 109, 107, 168, 71, 81, 147, 72, 98, 35, 45, 37, 217, 80, 238, 79, 2, 37, 157, 7, 61, 96, 97, 132, 216, 11, 19, 122, 96, 3, 77, 124, 5, 2, 91, 198, 210, 243, 246, 72, 193, 146, 177, 208, 158, 25, 182, 44, 141, 18, 193, 93, 120, 249, 121, 68, 59, 2, 209, 182, 220, 220, 122, 5, 221, 33, 44, 147, 177 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("67dc8556-822e-4790-bf5e-341c94967d30"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("333e4d9f-b265-4e89-9d93-9b88dd10c2b0") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("67dc8556-822e-4790-bf5e-341c94967d30"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("333e4d9f-b265-4e89-9d93-9b88dd10c2b0"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("e8448a44-3358-42e4-88d0-91c385d28608"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 157, 162, 96, 139, 141, 84, 224, 244, 6, 133, 177, 243, 127, 99, 233, 130, 226, 86, 224, 108, 105, 105, 98, 50, 95, 120, 190, 195, 138, 110, 46, 36, 18, 49, 245, 245, 38, 97, 42, 3, 101, 207, 211, 108, 64, 214, 174, 247, 104, 230, 31, 122, 23, 134, 123, 151, 54, 203, 100, 156, 201, 235, 69, 42 }, new byte[] { 247, 157, 83, 182, 234, 1, 249, 124, 211, 139, 97, 39, 73, 206, 134, 107, 173, 96, 226, 217, 250, 227, 25, 194, 180, 45, 27, 132, 186, 169, 49, 177, 15, 10, 55, 60, 83, 4, 161, 55, 172, 103, 123, 170, 69, 89, 45, 250, 164, 185, 10, 201, 228, 62, 53, 45, 190, 36, 196, 255, 148, 19, 169, 155, 35, 154, 252, 131, 132, 86, 47, 135, 70, 15, 85, 119, 101, 216, 86, 172, 95, 166, 148, 253, 117, 51, 94, 69, 116, 143, 7, 105, 102, 249, 255, 93, 144, 198, 32, 211, 103, 86, 219, 140, 70, 42, 132, 7, 161, 122, 184, 5, 45, 201, 126, 146, 242, 192, 66, 211, 117, 38, 120, 182, 226, 53, 99, 136 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9da90339-f726-417e-a19c-bd3098936bb4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e8448a44-3358-42e4-88d0-91c385d28608") });
        }
    }
}
