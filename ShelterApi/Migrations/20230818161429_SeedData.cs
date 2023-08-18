using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Dogs",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Cats",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "Age", "Gender", "HealthSocialNeeds", "Name", "Personality" },
                values: new object[,]
                {
                    { 1, "3m", "Female", "Need time to adjust to new environment.", "Dinky", "Sensitive, shy, worried around new people and environements" },
                    { 2, "2y 3m", "Male", "None.", "Chester", "Affectionate" },
                    { 3, "8y", "Male", "Deaf. Should be in a home with no other pets.", "Trooper", "Loud and friendly!" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Age", "Gender", "HealthSocialNeeds", "Name", "Personality" },
                values: new object[,]
                {
                    { 1, "1y 8m", "Male", "Would do best in an environment with older children.", "Houdini", "High Energy and Goofy!" },
                    { 2, "2y 4m", "Male", "While not needed, would do better in a home that has another dog for him to play with.", "Jelly Bean", "Very Social" },
                    { 3, "7y", "Female", "Blind. Would do better in an environment with no children", "Farrah", "Shy and Nervous" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailAddress", "Password", "UserName" },
                values: new object[] { 1, "TestUser@gmail.com", "Test", "TestUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Dogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Cats",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
