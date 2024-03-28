using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCopy_Branches_BranchId",
                table: "MaterialCopy");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCopy_Location_LocationId",
                table: "MaterialCopy");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCopy_Material_MaterialId",
                table: "MaterialCopy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCopy",
                table: "MaterialCopy");

            migrationBuilder.DropIndex(
                name: "IX_MaterialCopy_LocationId",
                table: "MaterialCopy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("91687d4d-025a-402a-b4d0-35f1567fe106"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("88fd462c-c409-4a62-91ac-61c5f8e509ee"));

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "MaterialCopy");

            migrationBuilder.RenameTable(
                name: "MaterialCopy",
                newName: "MaterialCopies");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCopy_MaterialId",
                table: "MaterialCopies",
                newName: "IX_MaterialCopies_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCopy_BranchId",
                table: "MaterialCopies",
                newName: "IX_MaterialCopies_BranchId");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialCopyId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCopies",
                table: "MaterialCopies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Admin", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Read", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Write", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Create", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Update", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MaterialCopies.Delete", null },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Admin", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Read", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Write", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Create", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Update", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0e63d0fe-d1c2-4d0d-b457-8c030db31a97"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 86, 76, 212, 47, 126, 196, 99, 174, 105, 171, 113, 32, 37, 119, 174, 171, 135, 133, 68, 22, 26, 206, 150, 136, 130, 147, 87, 86, 200, 207, 186, 175, 124, 93, 23, 28, 233, 199, 154, 31, 104, 224, 7, 72, 172, 221, 128, 71, 207, 205, 223, 132, 146, 110, 66, 255, 170, 164, 7, 120, 32, 52, 166, 100 }, new byte[] { 51, 81, 106, 146, 43, 38, 76, 68, 60, 170, 87, 133, 180, 233, 19, 229, 45, 239, 155, 10, 219, 42, 138, 97, 91, 45, 204, 11, 8, 19, 43, 104, 46, 81, 115, 15, 45, 111, 33, 63, 248, 225, 134, 207, 10, 89, 176, 221, 53, 252, 57, 6, 113, 69, 18, 68, 90, 39, 7, 31, 229, 20, 85, 20, 187, 129, 111, 210, 46, 49, 214, 100, 250, 44, 18, 108, 152, 235, 82, 21, 113, 254, 58, 242, 35, 205, 225, 188, 78, 168, 164, 134, 254, 120, 30, 96, 52, 73, 170, 187, 173, 203, 216, 122, 177, 58, 27, 24, 251, 59, 28, 249, 115, 40, 46, 77, 187, 121, 161, 144, 145, 151, 146, 37, 65, 220, 92, 18 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1d0a6add-d684-4bfb-809e-ff86790ecec5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0e63d0fe-d1c2-4d0d-b457-8c030db31a97") });

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
                name: "FK_MaterialCopies_Branches_BranchId",
                table: "MaterialCopies",
                column: "BranchId",
                principalTable: "Branches",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MaterialCopies_MaterialCopyId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCopies_Branches_BranchId",
                table: "MaterialCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCopies_Material_MaterialId",
                table: "MaterialCopies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCopies",
                table: "MaterialCopies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MaterialCopyId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1d0a6add-d684-4bfb-809e-ff86790ecec5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0e63d0fe-d1c2-4d0d-b457-8c030db31a97"));

            migrationBuilder.DropColumn(
                name: "MaterialCopyId",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "MaterialCopies",
                newName: "MaterialCopy");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCopies_MaterialId",
                table: "MaterialCopy",
                newName: "IX_MaterialCopy_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCopies_BranchId",
                table: "MaterialCopy",
                newName: "IX_MaterialCopy_BranchId");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "MaterialCopy",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCopy",
                table: "MaterialCopy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("88fd462c-c409-4a62-91ac-61c5f8e509ee"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 98, 150, 168, 203, 137, 136, 135, 116, 107, 159, 134, 25, 11, 254, 4, 3, 253, 154, 229, 120, 169, 13, 98, 71, 140, 218, 118, 217, 55, 197, 62, 159, 3, 176, 87, 69, 93, 171, 131, 133, 61, 226, 57, 195, 58, 201, 24, 54, 37, 158, 141, 193, 60, 92, 158, 101, 23, 178, 141, 215, 47, 52, 233, 128 }, new byte[] { 188, 77, 173, 62, 57, 250, 113, 11, 12, 235, 176, 68, 127, 29, 94, 50, 16, 228, 63, 228, 235, 139, 94, 74, 112, 14, 227, 248, 72, 79, 148, 74, 111, 32, 5, 32, 30, 38, 121, 20, 53, 46, 241, 245, 157, 49, 249, 135, 55, 29, 23, 88, 109, 28, 214, 98, 26, 174, 178, 102, 65, 52, 198, 45, 238, 12, 107, 215, 117, 69, 245, 13, 208, 188, 19, 168, 31, 43, 121, 236, 65, 206, 49, 28, 215, 178, 101, 39, 217, 189, 157, 189, 10, 217, 118, 92, 243, 15, 85, 186, 47, 132, 46, 70, 222, 231, 41, 21, 86, 7, 220, 128, 91, 72, 98, 152, 237, 53, 157, 34, 247, 169, 195, 79, 127, 30, 166, 94 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("91687d4d-025a-402a-b4d0-35f1567fe106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("88fd462c-c409-4a62-91ac-61c5f8e509ee") });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialCopy_LocationId",
                table: "MaterialCopy",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialCopy_Branches_BranchId",
                table: "MaterialCopy",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialCopy_Location_LocationId",
                table: "MaterialCopy",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialCopy_Material_MaterialId",
                table: "MaterialCopy",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
