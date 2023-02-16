using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAOSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProducerImplName = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Games_Producers_ProducerImplName",
                        column: x => x.ProducerImplName,
                        principalTable: "Producers",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_ProducerImplName",
                table: "Games",
                column: "ProducerImplName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
