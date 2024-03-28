using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class relationmaterialcopy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MaterialCopies_MaterialCopyId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCopies_Material_MaterialId",
                table: "MaterialCopies");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MaterialCopyId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("55787242-689a-41d4-8425-48e053d9d1c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f6f52612-d6bd-4cbc-a37b-54eb0dddabb0"));

            migrationBuilder.DropColumn(
                name: "MaterialCopyId",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "MaterialCopies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Materials.Admin", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Materials.Read", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Materials.Write", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Materials.Create", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Materials.Update", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Materials.Delete", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Admin", null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Read", null },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Write", null },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Create", null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Update", null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Delete", null },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Admin", null },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Read", null },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Write", null },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Create", null },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Update", null },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Delete", null },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Admin", null },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Read", null },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Write", null },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Create", null },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Update", null },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9b257c0b-679a-4f48-bab7-397f6ffb2494"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 155, 108, 116, 116, 184, 192, 110, 37, 10, 67, 168, 25, 126, 224, 168, 79, 125, 190, 231, 98, 234, 12, 13, 247, 173, 239, 119, 38, 114, 140, 149, 58, 116, 76, 138, 76, 174, 196, 224, 191, 249, 157, 188, 52, 53, 159, 66, 131, 236, 8, 50, 112, 183, 223, 152, 188, 235, 60, 20, 50, 122, 161, 100, 211 }, new byte[] { 98, 231, 182, 125, 47, 80, 188, 209, 240, 226, 148, 239, 245, 181, 69, 247, 156, 11, 254, 120, 171, 206, 182, 225, 229, 245, 33, 84, 221, 185, 224, 232, 239, 203, 49, 234, 56, 92, 211, 105, 250, 52, 215, 12, 151, 116, 210, 173, 85, 86, 122, 209, 43, 109, 168, 167, 184, 215, 118, 196, 100, 83, 209, 112, 109, 187, 143, 13, 108, 182, 234, 106, 236, 109, 31, 212, 14, 205, 178, 134, 127, 151, 194, 108, 36, 191, 232, 210, 242, 162, 150, 77, 81, 85, 61, 207, 242, 154, 248, 98, 38, 150, 25, 43, 86, 202, 170, 68, 253, 87, 193, 166, 0, 73, 123, 175, 87, 237, 154, 172, 186, 128, 174, 188, 58, 91, 248, 88 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a5fe8ba6-b540-4d21-bfc7-aaaec5ae305b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("9b257c0b-679a-4f48-bab7-397f6ffb2494") });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialCopies_LocationId",
                table: "MaterialCopies",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialCopies_Locations_LocationId",
                table: "MaterialCopies",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialCopies_Materials_MaterialId",
                table: "MaterialCopies",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCopies_Locations_LocationId",
                table: "MaterialCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCopies_Materials_MaterialId",
                table: "MaterialCopies");

            migrationBuilder.DropIndex(
                name: "IX_MaterialCopies_LocationId",
                table: "MaterialCopies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a5fe8ba6-b540-4d21-bfc7-aaaec5ae305b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b257c0b-679a-4f48-bab7-397f6ffb2494"));

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "MaterialCopies");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialCopyId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f6f52612-d6bd-4cbc-a37b-54eb0dddabb0"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 75, 142, 170, 195, 252, 116, 15, 132, 169, 87, 54, 59, 234, 208, 148, 62, 75, 240, 160, 40, 138, 214, 10, 91, 175, 139, 24, 129, 176, 116, 6, 110, 202, 12, 242, 58, 247, 81, 53, 139, 0, 41, 184, 21, 161, 214, 245, 140, 212, 156, 110, 62, 27, 195, 89, 40, 178, 226, 168, 98, 158, 174, 60, 43 }, new byte[] { 49, 156, 239, 127, 141, 112, 188, 205, 50, 157, 3, 234, 197, 154, 107, 236, 253, 127, 138, 174, 25, 32, 247, 254, 134, 126, 111, 32, 207, 89, 222, 73, 110, 75, 229, 151, 35, 95, 165, 0, 139, 253, 96, 223, 0, 96, 67, 250, 157, 252, 194, 5, 131, 66, 135, 20, 182, 202, 245, 134, 247, 87, 76, 226, 78, 9, 30, 178, 49, 43, 50, 46, 52, 9, 94, 100, 186, 186, 205, 90, 14, 223, 66, 179, 142, 125, 86, 181, 8, 34, 64, 211, 237, 194, 145, 59, 121, 135, 213, 12, 165, 32, 35, 30, 169, 170, 34, 93, 108, 30, 65, 93, 239, 171, 186, 230, 185, 118, 207, 74, 81, 115, 205, 113, 162, 62, 121, 150 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("55787242-689a-41d4-8425-48e053d9d1c3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f6f52612-d6bd-4cbc-a37b-54eb0dddabb0") });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MaterialCopyId",
                table: "Locations",
                column: "MaterialCopyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_MaterialCopies_MaterialCopyId",
                table: "Locations",
                column: "MaterialCopyId",
                principalTable: "MaterialCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialCopies_Material_MaterialId",
                table: "MaterialCopies",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
