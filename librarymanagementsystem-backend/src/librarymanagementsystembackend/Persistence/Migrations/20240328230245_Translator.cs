using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Translator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2fdfc15e-a35d-452c-aba6-e6668334e676"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ca1e8613-253b-4b36-8fd2-46cb41252201"));

            migrationBuilder.CreateTable(
                name: "Translators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranslatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTranslator",
                columns: table => new
                {
                    MaterialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranslatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTranslator", x => new { x.MaterialsId, x.TranslatorsId });
                    table.ForeignKey(
                        name: "FK_MaterialTranslator_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialTranslator_Translators_TranslatorsId",
                        column: x => x.TranslatorsId,
                        principalTable: "Translators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Translators.Admin", null },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Translators.Read", null },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Translators.Write", null },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Translators.Create", null },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Translators.Update", null },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Translators.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("03f4f691-01cc-49bc-a3e1-9c0d967e7fb5"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 83, 211, 33, 42, 13, 236, 214, 69, 116, 151, 57, 251, 59, 174, 144, 254, 64, 137, 100, 40, 40, 70, 219, 112, 43, 168, 12, 0, 90, 31, 18, 244, 35, 159, 136, 161, 4, 200, 220, 56, 176, 136, 3, 58, 41, 105, 58, 162, 51, 82, 226, 225, 44, 139, 211, 186, 194, 128, 232, 178, 129, 81, 225, 249 }, new byte[] { 55, 143, 89, 171, 248, 99, 17, 129, 154, 93, 98, 135, 199, 222, 139, 242, 41, 251, 248, 139, 26, 129, 37, 206, 145, 191, 224, 31, 77, 226, 120, 114, 95, 12, 249, 171, 128, 112, 73, 114, 89, 21, 43, 19, 12, 221, 237, 110, 222, 202, 18, 163, 42, 79, 48, 63, 223, 171, 176, 94, 3, 152, 124, 8, 63, 207, 199, 64, 219, 224, 135, 7, 234, 74, 249, 86, 36, 40, 108, 73, 122, 140, 213, 5, 128, 250, 80, 146, 223, 26, 68, 38, 47, 10, 231, 175, 71, 172, 219, 250, 206, 177, 247, 130, 155, 9, 164, 142, 227, 116, 69, 138, 35, 227, 164, 200, 174, 241, 98, 58, 126, 75, 108, 193, 28, 246, 146, 59 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d37f0a0a-4be4-4cf4-8d2a-b69914a6745f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("03f4f691-01cc-49bc-a3e1-9c0d967e7fb5") });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTranslator_TranslatorsId",
                table: "MaterialTranslator",
                column: "TranslatorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialTranslator");

            migrationBuilder.DropTable(
                name: "Translators");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d37f0a0a-4be4-4cf4-8d2a-b69914a6745f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("03f4f691-01cc-49bc-a3e1-9c0d967e7fb5"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("ca1e8613-253b-4b36-8fd2-46cb41252201"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 119, 87, 108, 31, 188, 106, 7, 109, 174, 229, 112, 122, 81, 250, 27, 107, 105, 12, 80, 208, 74, 8, 145, 108, 96, 96, 161, 53, 244, 74, 168, 42, 150, 225, 183, 177, 9, 107, 187, 151, 71, 251, 25, 14, 212, 160, 233, 35, 155, 145, 68, 45, 192, 98, 217, 186, 221, 145, 190, 1, 140, 114, 82, 145 }, new byte[] { 175, 122, 96, 37, 46, 23, 125, 134, 76, 188, 219, 250, 181, 63, 102, 66, 161, 5, 72, 19, 17, 37, 205, 142, 169, 212, 148, 176, 145, 73, 182, 178, 201, 138, 42, 15, 12, 82, 225, 207, 138, 226, 222, 126, 82, 106, 175, 193, 255, 159, 187, 131, 240, 10, 252, 97, 74, 35, 10, 91, 172, 110, 43, 23, 59, 130, 70, 73, 20, 254, 184, 179, 218, 160, 39, 111, 95, 237, 190, 11, 146, 49, 176, 118, 120, 50, 133, 12, 193, 180, 38, 162, 173, 233, 46, 103, 107, 148, 69, 236, 132, 196, 141, 140, 12, 172, 235, 124, 105, 89, 147, 176, 143, 79, 126, 226, 226, 217, 11, 205, 177, 245, 98, 56, 213, 5, 63, 17 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("2fdfc15e-a35d-452c-aba6-e6668334e676"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ca1e8613-253b-4b36-8fd2-46cb41252201") });
        }
    }
}
