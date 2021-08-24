using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gestion_des_formations_final.Data.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilisateurId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Entreprise",
                columns: table => new
                {
                    EntrepriseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: true),
                    Raisonsociale = table.Column<string>(nullable: true),
                    Boitepostale = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise", x => x.EntrepriseId);
                });

            migrationBuilder.CreateTable(
                name: "Formateur",
                columns: table => new
                {
                    FormateurId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formateur", x => x.FormateurId);
                });

            migrationBuilder.CreateTable(
                name: "Formation",
                columns: table => new
                {
                    FormationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(nullable: true),
                    Prix = table.Column<float>(nullable: false),
                    Duree = table.Column<int>(nullable: false),
                    FormationCertifiee = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formation", x => x.FormationId);
                });

            migrationBuilder.CreateTable(
                name: "Lieux",
                columns: table => new
                {
                    LieuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lieux", x => x.LieuId);
                });

            migrationBuilder.CreateTable(
                name: "Organisme",
                columns: table => new
                {
                    OrganismeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisme", x => x.OrganismeId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: true),
                    UtilisateurId = table.Column<int>(nullable: false),
                    UtilisateurId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Role_AspNetUsers_UtilisateurId1",
                        column: x => x.UtilisateurId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeDocument",
                columns: table => new
                {
                    TypeDocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDocument", x => x.TypeDocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    Adresse = table.Column<string>(nullable: true),
                    Statut = table.Column<string>(nullable: true),
                    ACertif = table.Column<string>(nullable: true),
                    EntrepriseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participant_Entreprise_EntrepriseId",
                        column: x => x.EntrepriseId,
                        principalTable: "Entreprise",
                        principalColumn: "EntrepriseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    SalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: true),
                    LieuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.SalleId);
                    table.ForeignKey(
                        name: "FK_Salle_Lieux_LieuId",
                        column: x => x.LieuId,
                        principalTable: "Lieux",
                        principalColumn: "LieuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certification",
                columns: table => new
                {
                    CertificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: true),
                    OrganismeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certification", x => x.CertificationId);
                    table.ForeignKey(
                        name: "FK_Certification_Organisme_OrganismeId",
                        column: x => x.OrganismeId,
                        principalTable: "Organisme",
                        principalColumn: "OrganismeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Privilege",
                columns: table => new
                {
                    PrivilegeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilege", x => x.PrivilegeId);
                    table.ForeignKey(
                        name: "FK_Privilege_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(nullable: true),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false),
                    Statut = table.Column<string>(nullable: true),
                    Evaluation = table.Column<int>(nullable: false),
                    Examen = table.Column<string>(nullable: true),
                    SalleId = table.Column<int>(nullable: false),
                    FormationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Session_Formation_FormationId",
                        column: x => x.FormationId,
                        principalTable: "Formation",
                        principalColumn: "FormationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Session_Salle_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salle",
                        principalColumn: "SalleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assister",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assister", x => new { x.ParticipantId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_Assister_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assister_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Contenu = table.Column<string>(nullable: true),
                    TypeDocumentId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Document_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_TypeDocument_TypeDocumentId",
                        column: x => x.TypeDocumentId,
                        principalTable: "TypeDocument",
                        principalColumn: "TypeDocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prester",
                columns: table => new
                {
                    FormateurId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prester", x => new { x.FormateurId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_Prester_Formateur_FormateurId",
                        column: x => x.FormateurId,
                        principalTable: "Formateur",
                        principalColumn: "FormateurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prester_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assister_SessionId",
                table: "Assister",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_OrganismeId",
                table: "Certification",
                column: "OrganismeId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_SessionId",
                table: "Document",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_TypeDocumentId",
                table: "Document",
                column: "TypeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_EntrepriseId",
                table: "Participant",
                column: "EntrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Prester_SessionId",
                table: "Prester",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Privilege_RoleId",
                table: "Privilege",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UtilisateurId1",
                table: "Role",
                column: "UtilisateurId1");

            migrationBuilder.CreateIndex(
                name: "IX_Salle_LieuId",
                table: "Salle",
                column: "LieuId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_FormationId",
                table: "Session",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_SalleId",
                table: "Session",
                column: "SalleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assister");

            migrationBuilder.DropTable(
                name: "Certification");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Prester");

            migrationBuilder.DropTable(
                name: "Privilege");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Organisme");

            migrationBuilder.DropTable(
                name: "TypeDocument");

            migrationBuilder.DropTable(
                name: "Formateur");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Entreprise");

            migrationBuilder.DropTable(
                name: "Formation");

            migrationBuilder.DropTable(
                name: "Salle");

            migrationBuilder.DropTable(
                name: "Lieux");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
