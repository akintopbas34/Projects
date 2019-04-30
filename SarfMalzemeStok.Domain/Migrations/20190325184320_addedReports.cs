using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SarfMalzemeStok.Domain.Migrations
{
    public partial class addedReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenchStandbyReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: false),
                    WorkCenter = table.Column<string>(nullable: true),
                    MasrafYeri = table.Column<string>(nullable: true),
                    Parca = table.Column<string>(nullable: true),
                    Operation = table.Column<string>(nullable: true),
                    YakaNo = table.Column<string>(nullable: true),
                    TalepNumarasi = table.Column<string>(nullable: true),
                    BeklemeSuresi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenchStandbyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenchStandbyReport_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryInformationReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: false),
                    Process = table.Column<string>(nullable: true),
                    PartNumber = table.Column<string>(nullable: true),
                    DescPart = table.Column<string>(nullable: true),
                    Operation = table.Column<string>(nullable: true),
                    WorkStation = table.Column<string>(nullable: true),
                    Consumable = table.Column<string>(nullable: true),
                    OlcuBirimi = table.Column<string>(nullable: true),
                    UPP = table.Column<string>(nullable: true),
                    UPPDegisiklik = table.Column<string>(nullable: true),
                    DegisiklikYapan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryInformationReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryInformationReport_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessingTimeReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: false),
                    Tanim = table.Column<string>(nullable: true),
                    SiparisNo = table.Column<string>(nullable: true),
                    Termin = table.Column<int>(nullable: false),
                    TeslimatTarih = table.Column<DateTime>(nullable: false),
                    KaliteKontrolTarihi = table.Column<DateTime>(nullable: false),
                    Durum = table.Column<string>(nullable: true),
                    Inspector = table.Column<string>(nullable: true),
                    TahditsizTarih = table.Column<DateTime>(nullable: false),
                    InspectionSuresi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingTimeReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingTimeReport_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroupConsumptionReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: false),
                    Kod = table.Column<string>(nullable: true),
                    Tanim = table.Column<string>(nullable: true),
                    SiparisNo = table.Column<string>(nullable: true),
                    TerminTarihi = table.Column<DateTime>(nullable: false),
                    TerminMiktari = table.Column<int>(nullable: false),
                    BatchNo = table.Column<string>(nullable: true),
                    AsgariKalanSure = table.Column<int>(nullable: false),
                    TeslimatTarihi = table.Column<DateTime>(nullable: false),
                    KaliteKontrolTarihi = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true),
                    Durum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroupConsumptionReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGroupConsumptionReport_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenchStandbyReport_MaterialId",
                table: "BenchStandbyReport",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryInformationReport_MaterialId",
                table: "HistoryInformationReport",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingTimeReport_MaterialId",
                table: "ProcessingTimeReport",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroupConsumptionReport_MaterialId",
                table: "ProductGroupConsumptionReport",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenchStandbyReport");

            migrationBuilder.DropTable(
                name: "HistoryInformationReport");

            migrationBuilder.DropTable(
                name: "ProcessingTimeReport");

            migrationBuilder.DropTable(
                name: "ProductGroupConsumptionReport");
        }
    }
}
