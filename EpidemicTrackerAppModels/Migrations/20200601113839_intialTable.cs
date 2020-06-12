using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpidemicTrackerApp.Migrations
{
    public partial class intialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressType = table.Column<string>(maxLength: 25, nullable: false),
                    StreetNumber = table.Column<int>(maxLength: 15, nullable: false),
                    Area = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "varchar", maxLength: 25, nullable: false),
                    State = table.Column<string>(type: "varchar", maxLength: 25, nullable: false),
                    Country = table.Column<string>(type: "varchar", maxLength: 25, nullable: false),
                    PinCode = table.Column<int>(name: "Pin Code", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(name: "Disease Name", type: "varchar", maxLength: 30, nullable: false),
                    DiseaseType = table.Column<string>(type: "varchar", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseaseId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar", maxLength: 15, nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalId);
                    table.ForeignKey(
                        name: "FK_Hospitals_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Age = table.Column<int>(maxLength: 3, nullable: false),
                    Gender = table.Column<string>(maxLength: 6, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    UniquesId = table.Column<string>(maxLength: 25, nullable: false),
                    Contact = table.Column<long>(maxLength: 15, nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginName = table.Column<string>(name: "Login Name", nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_Logins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    OccupationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationName = table.Column<string>(name: "Occupation Name", type: "varchar", maxLength: 30, nullable: false),
                    OccupationType = table.Column<string>(name: "Occupation Type", type: "varchar", maxLength: 20, nullable: false),
                    PatientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.OccupationId);
                    table.ForeignKey(
                        name: "FK_Occupations_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    OrganisationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationName = table.Column<string>(type: "varchar", maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    PatientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.OrganisationId);
                    table.ForeignKey(
                        name: "FK_Organisations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Organisations_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "TreatmentRecords",
                columns: table => new
                {
                    TreatmentRecordsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false),
                    DiseaseId = table.Column<int>(nullable: false),
                    AdmittedDate = table.Column<DateTime>(name: "Admitted Date", type: "date", nullable: false),
                    RelievingDate = table.Column<DateTime>(name: "Relieving Date", type: "date", nullable: false),
                    Prescription = table.Column<string>(nullable: false),
                    CurrentStage = table.Column<int>(name: "Current Stage", nullable: false),
                    IsFatal = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentRecords", x => x.TreatmentRecordsId);
                    table.ForeignKey(
                        name: "FK_TreatmentRecords_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentRecords_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentRecords_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AddressId",
                table: "Hospitals",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_RoleId",
                table: "Logins",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_PatientID",
                table: "Occupations",
                column: "PatientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_AddressId",
                table: "Organisations",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_PatientID",
                table: "Organisations",
                column: "PatientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_DiseaseId",
                table: "TreatmentRecords",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_HospitalId",
                table: "TreatmentRecords",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentRecords_PatientID",
                table: "TreatmentRecords",
                column: "PatientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropTable(
                name: "TreatmentRecords");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
