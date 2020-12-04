using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazy_Danych.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kod_pocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_domu = table.Column<int>(type: "int", nullable: false),
                    Nr_mieszkania = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Leki",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_leku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dawkowanie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leki", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RodzajeZabiegow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajeZabiegow", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lekarze",
                columns: table => new
                {
                    PESEL = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specjalizacja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekarze", x => x.PESEL);
                    table.ForeignKey(
                        name: "FK_Lekarze_Adresy_adresID",
                        column: x => x.adresID,
                        principalTable: "Adresy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacjeci",
                columns: table => new
                {
                    PESEL = table.Column<long>(type: "bigint", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjeci", x => x.PESEL);
                    table.ForeignKey(
                        name: "FK_Pacjeci_Adresy_adresID",
                        column: x => x.adresID,
                        principalTable: "Adresy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pielegniarki",
                columns: table => new
                {
                    PESEL = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pielegniarki", x => x.PESEL);
                    table.ForeignKey(
                        name: "FK_Pielegniarki_Adresy_adresID",
                        column: x => x.adresID,
                        principalTable: "Adresy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recepty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pacjentPESEL = table.Column<long>(type: "bigint", nullable: false),
                    lekarzPESEL = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recepty_Lekarze_lekarzPESEL",
                        column: x => x.lekarzPESEL,
                        principalTable: "Lekarze",
                        principalColumn: "PESEL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recepty_Pacjeci_pacjentPESEL",
                        column: x => x.pacjentPESEL,
                        principalTable: "Pacjeci",
                        principalColumn: "PESEL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skierowania",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_zabiegu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_wygasniecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pacjentPESEL = table.Column<long>(type: "bigint", nullable: false),
                    lekarzPESEL = table.Column<long>(type: "bigint", nullable: false),
                    adresID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skierowania", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Skierowania_Adresy_adresID",
                        column: x => x.adresID,
                        principalTable: "Adresy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skierowania_Lekarze_lekarzPESEL",
                        column: x => x.lekarzPESEL,
                        principalTable: "Lekarze",
                        principalColumn: "PESEL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skierowania_Pacjeci_pacjentPESEL",
                        column: x => x.pacjentPESEL,
                        principalTable: "Pacjeci",
                        principalColumn: "PESEL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wizyty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lekarzPESEL = table.Column<long>(type: "bigint", nullable: false),
                    pacjentPESEL = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wizyty_Lekarze_lekarzPESEL",
                        column: x => x.lekarzPESEL,
                        principalTable: "Lekarze",
                        principalColumn: "PESEL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyty_Pacjeci_pacjentPESEL",
                        column: x => x.pacjentPESEL,
                        principalTable: "Pacjeci",
                        principalColumn: "PESEL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zabiegi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lekarzPESEL = table.Column<long>(type: "bigint", nullable: false),
                    pielegniarkaPESEL = table.Column<long>(type: "bigint", nullable: false),
                    pacjentPESEL = table.Column<long>(type: "bigint", nullable: false),
                    rodzajZabieguID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zabiegi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zabiegi_Lekarze_lekarzPESEL",
                        column: x => x.lekarzPESEL,
                        principalTable: "Lekarze",
                        principalColumn: "PESEL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zabiegi_Pacjeci_pacjentPESEL",
                        column: x => x.pacjentPESEL,
                        principalTable: "Pacjeci",
                        principalColumn: "PESEL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zabiegi_Pielegniarki_pielegniarkaPESEL",
                        column: x => x.pielegniarkaPESEL,
                        principalTable: "Pielegniarki",
                        principalColumn: "PESEL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zabiegi_RodzajeZabiegow_rodzajZabieguID",
                        column: x => x.rodzajZabieguID,
                        principalTable: "RodzajeZabiegow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LekRecepta",
                columns: table => new
                {
                    lekiID = table.Column<int>(type: "int", nullable: false),
                    receptyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LekRecepta", x => new { x.lekiID, x.receptyID });
                    table.ForeignKey(
                        name: "FK_LekRecepta_Leki_lekiID",
                        column: x => x.lekiID,
                        principalTable: "Leki",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LekRecepta_Recepty_receptyID",
                        column: x => x.receptyID,
                        principalTable: "Recepty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lekarze_adresID",
                table: "Lekarze",
                column: "adresID");

            migrationBuilder.CreateIndex(
                name: "IX_LekRecepta_receptyID",
                table: "LekRecepta",
                column: "receptyID");

            migrationBuilder.CreateIndex(
                name: "IX_Pacjeci_adresID",
                table: "Pacjeci",
                column: "adresID");

            migrationBuilder.CreateIndex(
                name: "IX_Pielegniarki_adresID",
                table: "Pielegniarki",
                column: "adresID");

            migrationBuilder.CreateIndex(
                name: "IX_Recepty_lekarzPESEL",
                table: "Recepty",
                column: "lekarzPESEL");

            migrationBuilder.CreateIndex(
                name: "IX_Recepty_pacjentPESEL",
                table: "Recepty",
                column: "pacjentPESEL");

            migrationBuilder.CreateIndex(
                name: "IX_Skierowania_adresID",
                table: "Skierowania",
                column: "adresID");

            migrationBuilder.CreateIndex(
                name: "IX_Skierowania_lekarzPESEL",
                table: "Skierowania",
                column: "lekarzPESEL");

            migrationBuilder.CreateIndex(
                name: "IX_Skierowania_pacjentPESEL",
                table: "Skierowania",
                column: "pacjentPESEL");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_lekarzPESEL",
                table: "Wizyty",
                column: "lekarzPESEL");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_pacjentPESEL",
                table: "Wizyty",
                column: "pacjentPESEL");

            migrationBuilder.CreateIndex(
                name: "IX_Zabiegi_lekarzPESEL",
                table: "Zabiegi",
                column: "lekarzPESEL");

            migrationBuilder.CreateIndex(
                name: "IX_Zabiegi_pacjentPESEL",
                table: "Zabiegi",
                column: "pacjentPESEL");

            migrationBuilder.CreateIndex(
                name: "IX_Zabiegi_pielegniarkaPESEL",
                table: "Zabiegi",
                column: "pielegniarkaPESEL");

            migrationBuilder.CreateIndex(
                name: "IX_Zabiegi_rodzajZabieguID",
                table: "Zabiegi",
                column: "rodzajZabieguID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LekRecepta");

            migrationBuilder.DropTable(
                name: "Skierowania");

            migrationBuilder.DropTable(
                name: "Wizyty");

            migrationBuilder.DropTable(
                name: "Zabiegi");

            migrationBuilder.DropTable(
                name: "Leki");

            migrationBuilder.DropTable(
                name: "Recepty");

            migrationBuilder.DropTable(
                name: "Pielegniarki");

            migrationBuilder.DropTable(
                name: "RodzajeZabiegow");

            migrationBuilder.DropTable(
                name: "Lekarze");

            migrationBuilder.DropTable(
                name: "Pacjeci");

            migrationBuilder.DropTable(
                name: "Adresy");
        }
    }
}
