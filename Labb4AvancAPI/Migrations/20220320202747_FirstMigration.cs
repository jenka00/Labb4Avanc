using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4AvancAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestTitle = table.Column<string>(nullable: false),
                    InterestDescription = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Tommy", "Andersson", null },
                    { 2, "Annicka", "Andersson", null },
                    { 3, "Anna", "Lundgren", null },
                    { 4, "Johannes", "Storm", null }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "InterestDescription", "InterestTitle", "PersonId" },
                values: new object[,]
                {
                    { 2, "Lagsport med två lag där varje lag med fötterna ska försöka göra mål i motståndarnas lag.", "Fotboll", 1 },
                    { 4, "En typ av segling på vattnet på en bräda där man drivs fram av vinden med hjälp av en drake som man håller i.", "Kitesurfing", 1 },
                    { 1, "Rida på ryggen av en häst.", "Ridning", 2 },
                    { 3, "Betrakta och tolka bokstäver eller annan nedskriven information i t ex böcker och tidningar.", "Läsa", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
