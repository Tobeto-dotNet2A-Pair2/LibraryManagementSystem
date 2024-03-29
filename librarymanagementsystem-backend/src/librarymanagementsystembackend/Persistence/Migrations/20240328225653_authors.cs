using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class authors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1899c30b-a1d1-4a11-b19d-dbbf9c4c1fcb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e1fd874-c241-478b-8941-e65aed52758f"));

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorMaterial",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorMaterial", x => new { x.AuthorsId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_AuthorMaterial_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorMaterial_Materials_MaterialsId",
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
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Admin", null },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Read", null },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Write", null },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Create", null },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Update", null },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Authors.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("ca1e8613-253b-4b36-8fd2-46cb41252201"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 119, 87, 108, 31, 188, 106, 7, 109, 174, 229, 112, 122, 81, 250, 27, 107, 105, 12, 80, 208, 74, 8, 145, 108, 96, 96, 161, 53, 244, 74, 168, 42, 150, 225, 183, 177, 9, 107, 187, 151, 71, 251, 25, 14, 212, 160, 233, 35, 155, 145, 68, 45, 192, 98, 217, 186, 221, 145, 190, 1, 140, 114, 82, 145 }, new byte[] { 175, 122, 96, 37, 46, 23, 125, 134, 76, 188, 219, 250, 181, 63, 102, 66, 161, 5, 72, 19, 17, 37, 205, 142, 169, 212, 148, 176, 145, 73, 182, 178, 201, 138, 42, 15, 12, 82, 225, 207, 138, 226, 222, 126, 82, 106, 175, 193, 255, 159, 187, 131, 240, 10, 252, 97, 74, 35, 10, 91, 172, 110, 43, 23, 59, 130, 70, 73, 20, 254, 184, 179, 218, 160, 39, 111, 95, 237, 190, 11, 146, 49, 176, 118, 120, 50, 133, 12, 193, 180, 38, 162, 173, 233, 46, 103, 107, 148, 69, 236, 132, 196, 141, 140, 12, 172, 235, 124, 105, 89, 147, 176, 143, 79, 126, 226, 226, 217, 11, 205, 177, 245, 98, 56, 213, 5, 63, 17 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("2fdfc15e-a35d-452c-aba6-e6668334e676"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ca1e8613-253b-4b36-8fd2-46cb41252201") });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorMaterial_MaterialsId",
                table: "AuthorMaterial",
                column: "MaterialsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorMaterial");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2fdfc15e-a35d-452c-aba6-e6668334e676"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ca1e8613-253b-4b36-8fd2-46cb41252201"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3e1fd874-c241-478b-8941-e65aed52758f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 198, 146, 206, 230, 239, 66, 249, 115, 8, 53, 28, 121, 68, 123, 67, 28, 253, 193, 41, 73, 8, 216, 182, 0, 191, 27, 122, 147, 120, 95, 124, 206, 61, 40, 45, 190, 171, 197, 244, 232, 72, 254, 185, 14, 62, 16, 97, 224, 197, 170, 62, 80, 20, 20, 81, 70, 151, 208, 215, 69, 195, 249, 68, 202 }, new byte[] { 180, 166, 163, 48, 72, 106, 84, 106, 213, 194, 94, 25, 146, 209, 101, 118, 174, 230, 175, 175, 168, 16, 202, 190, 32, 98, 40, 147, 112, 21, 217, 11, 182, 55, 109, 75, 8, 14, 30, 237, 31, 28, 196, 241, 110, 206, 111, 214, 145, 125, 43, 149, 1, 176, 219, 46, 224, 33, 186, 82, 79, 251, 187, 228, 242, 141, 177, 47, 104, 56, 23, 149, 31, 101, 210, 197, 231, 30, 223, 57, 139, 247, 39, 140, 234, 167, 186, 50, 239, 98, 67, 106, 0, 173, 195, 197, 218, 62, 229, 238, 54, 20, 28, 218, 124, 177, 15, 14, 44, 0, 93, 32, 69, 56, 209, 73, 16, 95, 96, 224, 110, 112, 160, 177, 135, 146, 163, 67 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1899c30b-a1d1-4a11-b19d-dbbf9c4c1fcb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3e1fd874-c241-478b-8941-e65aed52758f") });
        }
    }
}
