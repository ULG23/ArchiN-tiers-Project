using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrateur",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    NomdeVoie = table.Column<string>(type: "TEXT", nullable: false),
                    CodePostal = table.Column<int>(type: "INTEGER", nullable: false),
                    NomdeCommune = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Confirmation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Retribution = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Informateur",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    AdresseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Calominateur = table.Column<bool>(type: "INTEGER", nullable: false),
                    VIP = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personne_Adresse_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reponse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConfirmationId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reponse_Confirmation_ConfirmationId",
                        column: x => x.ConfirmationId,
                        principalTable: "Confirmation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Denonciation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Informateur = table.Column<Guid>(type: "TEXT", nullable: true),
                    Delit = table.Column<int>(type: "INTEGER", nullable: false),
                    PaysEvasion = table.Column<string>(type: "TEXT", nullable: true),
                    ReponseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    InformateurId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denonciation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Denonciation_Informateur_InformateurId",
                        column: x => x.InformateurId,
                        principalTable: "Informateur",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Denonciation_Reponse_ReponseId",
                        column: x => x.ReponseId,
                        principalTable: "Reponse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suspect",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccuseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suspect_Denonciation_Id",
                        column: x => x.Id,
                        principalTable: "Denonciation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suspect_Personne_AccuseId",
                        column: x => x.AccuseId,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Denonciation_InformateurId",
                table: "Denonciation",
                column: "InformateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Denonciation_ReponseId",
                table: "Denonciation",
                column: "ReponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_AdresseId",
                table: "Personne",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reponse_ConfirmationId",
                table: "Reponse",
                column: "ConfirmationId");

            migrationBuilder.CreateIndex(
                name: "IX_Suspect_AccuseId",
                table: "Suspect",
                column: "AccuseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrateur");

            migrationBuilder.DropTable(
                name: "Suspect");

            migrationBuilder.DropTable(
                name: "Denonciation");

            migrationBuilder.DropTable(
                name: "Personne");

            migrationBuilder.DropTable(
                name: "Informateur");

            migrationBuilder.DropTable(
                name: "Reponse");

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropTable(
                name: "Confirmation");
        }
    }
}
