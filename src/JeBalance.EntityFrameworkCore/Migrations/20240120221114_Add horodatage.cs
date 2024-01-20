using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Migrations
{
    /// <inheritdoc />
    public partial class Addhorodatage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Denonciation_Informateur_InformateurId",
                table: "Denonciation");

            migrationBuilder.DropForeignKey(
                name: "FK_Denonciation_Reponse_ReponseId",
                table: "Denonciation");

            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Adresse_AdresseId",
                table: "Personne");

            migrationBuilder.DropForeignKey(
                name: "FK_Reponse_Confirmation_ConfirmationId",
                table: "Reponse");

            migrationBuilder.DropForeignKey(
                name: "FK_Suspect_Denonciation_Id",
                table: "Suspect");

            migrationBuilder.DropForeignKey(
                name: "FK_Suspect_Personne_AccuseId",
                table: "Suspect");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suspect",
                table: "Suspect");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reponse",
                table: "Reponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personne",
                table: "Personne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Informateur",
                table: "Informateur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Denonciation",
                table: "Denonciation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Confirmation",
                table: "Confirmation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse");

            migrationBuilder.RenameTable(
                name: "Suspect",
                newName: "Suspects");

            migrationBuilder.RenameTable(
                name: "Reponse",
                newName: "Reponses");

            migrationBuilder.RenameTable(
                name: "Personne",
                newName: "Personnes");

            migrationBuilder.RenameTable(
                name: "Informateur",
                newName: "Informateurs");

            migrationBuilder.RenameTable(
                name: "Denonciation",
                newName: "Denonciations");

            migrationBuilder.RenameTable(
                name: "Confirmation",
                newName: "Confirmations");

            migrationBuilder.RenameTable(
                name: "Adresse",
                newName: "Adresses");

            migrationBuilder.RenameIndex(
                name: "IX_Suspect_AccuseId",
                table: "Suspects",
                newName: "IX_Suspects_AccuseId");

            migrationBuilder.RenameIndex(
                name: "IX_Reponse_ConfirmationId",
                table: "Reponses",
                newName: "IX_Reponses_ConfirmationId");

            migrationBuilder.RenameIndex(
                name: "IX_Personne_AdresseId",
                table: "Personnes",
                newName: "IX_Personnes_AdresseId");

            migrationBuilder.RenameIndex(
                name: "IX_Denonciation_ReponseId",
                table: "Denonciations",
                newName: "IX_Denonciations_ReponseId");

            migrationBuilder.RenameIndex(
                name: "IX_Denonciation_InformateurId",
                table: "Denonciations",
                newName: "IX_Denonciations_InformateurId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Reponses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Reponses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Rejected",
                table: "Reponses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Denonciations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Denonciations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suspects",
                table: "Suspects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reponses",
                table: "Reponses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personnes",
                table: "Personnes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Informateurs",
                table: "Informateurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Denonciations",
                table: "Denonciations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Confirmations",
                table: "Confirmations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Denonciations_Informateurs_InformateurId",
                table: "Denonciations",
                column: "InformateurId",
                principalTable: "Informateurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Denonciations_Reponses_ReponseId",
                table: "Denonciations",
                column: "ReponseId",
                principalTable: "Reponses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnes_Adresses_AdresseId",
                table: "Personnes",
                column: "AdresseId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reponses_Confirmations_ConfirmationId",
                table: "Reponses",
                column: "ConfirmationId",
                principalTable: "Confirmations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suspects_Denonciations_Id",
                table: "Suspects",
                column: "Id",
                principalTable: "Denonciations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suspects_Personnes_AccuseId",
                table: "Suspects",
                column: "AccuseId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Denonciations_Informateurs_InformateurId",
                table: "Denonciations");

            migrationBuilder.DropForeignKey(
                name: "FK_Denonciations_Reponses_ReponseId",
                table: "Denonciations");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnes_Adresses_AdresseId",
                table: "Personnes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reponses_Confirmations_ConfirmationId",
                table: "Reponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Suspects_Denonciations_Id",
                table: "Suspects");

            migrationBuilder.DropForeignKey(
                name: "FK_Suspects_Personnes_AccuseId",
                table: "Suspects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suspects",
                table: "Suspects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reponses",
                table: "Reponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personnes",
                table: "Personnes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Informateurs",
                table: "Informateurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Denonciations",
                table: "Denonciations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Confirmations",
                table: "Confirmations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Reponses");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Reponses");

            migrationBuilder.DropColumn(
                name: "Rejected",
                table: "Reponses");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Denonciations");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Denonciations");

            migrationBuilder.RenameTable(
                name: "Suspects",
                newName: "Suspect");

            migrationBuilder.RenameTable(
                name: "Reponses",
                newName: "Reponse");

            migrationBuilder.RenameTable(
                name: "Personnes",
                newName: "Personne");

            migrationBuilder.RenameTable(
                name: "Informateurs",
                newName: "Informateur");

            migrationBuilder.RenameTable(
                name: "Denonciations",
                newName: "Denonciation");

            migrationBuilder.RenameTable(
                name: "Confirmations",
                newName: "Confirmation");

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "Adresse");

            migrationBuilder.RenameIndex(
                name: "IX_Suspects_AccuseId",
                table: "Suspect",
                newName: "IX_Suspect_AccuseId");

            migrationBuilder.RenameIndex(
                name: "IX_Reponses_ConfirmationId",
                table: "Reponse",
                newName: "IX_Reponse_ConfirmationId");

            migrationBuilder.RenameIndex(
                name: "IX_Personnes_AdresseId",
                table: "Personne",
                newName: "IX_Personne_AdresseId");

            migrationBuilder.RenameIndex(
                name: "IX_Denonciations_ReponseId",
                table: "Denonciation",
                newName: "IX_Denonciation_ReponseId");

            migrationBuilder.RenameIndex(
                name: "IX_Denonciations_InformateurId",
                table: "Denonciation",
                newName: "IX_Denonciation_InformateurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suspect",
                table: "Suspect",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reponse",
                table: "Reponse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personne",
                table: "Personne",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Informateur",
                table: "Informateur",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Denonciation",
                table: "Denonciation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Confirmation",
                table: "Confirmation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Denonciation_Informateur_InformateurId",
                table: "Denonciation",
                column: "InformateurId",
                principalTable: "Informateur",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Denonciation_Reponse_ReponseId",
                table: "Denonciation",
                column: "ReponseId",
                principalTable: "Reponse",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Adresse_AdresseId",
                table: "Personne",
                column: "AdresseId",
                principalTable: "Adresse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reponse_Confirmation_ConfirmationId",
                table: "Reponse",
                column: "ConfirmationId",
                principalTable: "Confirmation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suspect_Denonciation_Id",
                table: "Suspect",
                column: "Id",
                principalTable: "Denonciation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suspect_Personne_AccuseId",
                table: "Suspect",
                column: "AccuseId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
