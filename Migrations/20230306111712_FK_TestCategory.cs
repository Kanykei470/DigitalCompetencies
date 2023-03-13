using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalСompetencies1.Migrations
{
    /// <inheritdoc />
    public partial class FK_TestCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TestCategory",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descriprion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TextsBank",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    text = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    symbols = table.Column<short>(type: "smallint", nullable: false),
                    expectedTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextsBank", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    position = table.Column<short>(type: "smallint", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    image = table.Column<byte[]>(type: "image", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.id);
                    table.ForeignKey(
                        name: "FK_Worker_Positions",
                        column: x => x.position,
                        principalTable: "Positions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TestBank",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    category = table.Column<short>(type: "smallint", nullable: false),
                    question = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    op1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    op2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    op3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    op4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    correctAns = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestBank", x => x.id);
                    table.ForeignKey(
                        name: "FK_TestBank_TestCategory",
                        column: x => x.category,
                        principalTable: "TestCategory",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    idWorker = table.Column<short>(type: "smallint", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    time = table.Column<TimeSpan>(type: "time", nullable: true),
                    result = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.id);
                    table.ForeignKey(
                        name: "FK_Results_Worker",
                        column: x => x.idWorker,
                        principalTable: "Worker",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_idWorker",
                table: "Results",
                column: "idWorker");

            migrationBuilder.CreateIndex(
                name: "IX_TestBank_category",
                table: "TestBank",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_position",
                table: "Worker",
                column: "position");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "TestBank");

            migrationBuilder.DropTable(
                name: "TextsBank");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "TestCategory");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
