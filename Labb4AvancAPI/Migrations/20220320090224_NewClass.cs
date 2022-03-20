using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4AvancAPI.Migrations
{
    public partial class NewClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_Interests_PersonId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Interests");

            migrationBuilder.CreateTable(
                name: "Leisures",
                columns: table => new
                {
                    LeisureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leisures", x => x.LeisureId);
                    table.ForeignKey(
                        name: "FK_Leisures_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leisures_PersonId",
                table: "Leisures",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leisures");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Interests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 1,
                column: "PersonId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 2,
                column: "PersonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 3,
                column: "PersonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 4,
                column: "PersonId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
