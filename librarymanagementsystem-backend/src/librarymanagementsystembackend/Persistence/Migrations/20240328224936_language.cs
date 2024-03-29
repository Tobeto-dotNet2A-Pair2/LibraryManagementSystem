using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("cff5c4c9-eda7-4e93-bc78-0e3c1c847d2e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3c4545c0-efe3-4783-b9cb-be97447facbe"));

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageMaterial",
                columns: table => new
                {
                    LanguagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageMaterial", x => new { x.LanguagesId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_LanguageMaterial_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageMaterial_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Admin", null },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Read", null },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Write", null },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Create", null },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Update", null },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Languages.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3e1fd874-c241-478b-8941-e65aed52758f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 198, 146, 206, 230, 239, 66, 249, 115, 8, 53, 28, 121, 68, 123, 67, 28, 253, 193, 41, 73, 8, 216, 182, 0, 191, 27, 122, 147, 120, 95, 124, 206, 61, 40, 45, 190, 171, 197, 244, 232, 72, 254, 185, 14, 62, 16, 97, 224, 197, 170, 62, 80, 20, 20, 81, 70, 151, 208, 215, 69, 195, 249, 68, 202 }, new byte[] { 180, 166, 163, 48, 72, 106, 84, 106, 213, 194, 94, 25, 146, 209, 101, 118, 174, 230, 175, 175, 168, 16, 202, 190, 32, 98, 40, 147, 112, 21, 217, 11, 182, 55, 109, 75, 8, 14, 30, 237, 31, 28, 196, 241, 110, 206, 111, 214, 145, 125, 43, 149, 1, 176, 219, 46, 224, 33, 186, 82, 79, 251, 187, 228, 242, 141, 177, 47, 104, 56, 23, 149, 31, 101, 210, 197, 231, 30, 223, 57, 139, 247, 39, 140, 234, 167, 186, 50, 239, 98, 67, 106, 0, 173, 195, 197, 218, 62, 229, 238, 54, 20, 28, 218, 124, 177, 15, 14, 44, 0, 93, 32, 69, 56, 209, 73, 16, 95, 96, 224, 110, 112, 160, 177, 135, 146, 163, 67 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1899c30b-a1d1-4a11-b19d-dbbf9c4c1fcb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3e1fd874-c241-478b-8941-e65aed52758f") });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageMaterial_MaterialsId",
                table: "LanguageMaterial",
                column: "MaterialsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageMaterial");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1899c30b-a1d1-4a11-b19d-dbbf9c4c1fcb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e1fd874-c241-478b-8941-e65aed52758f"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3c4545c0-efe3-4783-b9cb-be97447facbe"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 29, 14, 162, 124, 239, 73, 61, 164, 158, 65, 16, 254, 209, 62, 201, 237, 182, 4, 196, 103, 101, 169, 165, 183, 96, 135, 230, 210, 64, 116, 159, 252, 193, 171, 89, 214, 143, 183, 230, 41, 201, 218, 21, 169, 128, 126, 57, 232, 7, 53, 16, 58, 13, 70, 3, 17, 100, 110, 227, 156, 131, 24, 92, 17 }, new byte[] { 69, 158, 114, 235, 228, 106, 161, 79, 133, 254, 243, 133, 81, 174, 226, 77, 85, 131, 62, 132, 136, 152, 108, 181, 246, 113, 229, 12, 132, 33, 176, 65, 19, 118, 173, 18, 124, 219, 87, 45, 63, 67, 241, 183, 26, 148, 17, 118, 206, 242, 161, 135, 214, 93, 169, 11, 183, 168, 165, 58, 0, 83, 197, 62, 38, 201, 124, 177, 190, 82, 102, 113, 48, 42, 53, 140, 220, 96, 18, 99, 242, 90, 18, 48, 105, 129, 134, 215, 22, 73, 6, 210, 105, 42, 7, 162, 188, 123, 6, 116, 51, 228, 204, 24, 81, 167, 196, 232, 32, 144, 7, 204, 181, 226, 172, 85, 82, 169, 233, 108, 168, 77, 193, 222, 252, 255, 227, 233 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("cff5c4c9-eda7-4e93-bc78-0e3c1c847d2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3c4545c0-efe3-4783-b9cb-be97447facbe") });
        }
    }
}
