using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SarfMalzemeStok.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirmaKodu = table.Column<string>(nullable: true),
                    FirmaAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MalzemeKodu = table.Column<string>(nullable: true),
                    MalzemeAdi = table.Column<string>(nullable: true),
                    MaliyetSiniflandirmasi = table.Column<string>(nullable: true),
                    MalzemeninKullanimOmru = table.Column<int>(nullable: false),
                    EmniyetStok = table.Column<double>(nullable: false),
                    YenidenSiparisSeviyesi = table.Column<double>(nullable: false),
                    SabitPartiBuyuklugu = table.Column<string>(nullable: true),
                    YillikTasmaOrani = table.Column<double>(nullable: false),
                    MalzemeHakkindaNotlar = table.Column<string>(nullable: true),
                    TeknikResim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlternativeMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Material1Id = table.Column<int>(nullable: true),
                    Material2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeMaterial_Material_Material1Id",
                        column: x => x.Material1Id,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlternativeMaterial_Material_Material2Id",
                        column: x => x.Material2Id,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    BirimMaliyet = table.Column<double>(nullable: false),
                    TedarikSuresi = table.Column<int>(nullable: false),
                    AsgariPartiBuyuklugu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyMaterial_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMaterial_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: false),
                    KullanimTarihi = table.Column<DateTime>(nullable: false),
                    TuketimMiktari = table.Column<int>(nullable: false),
                    Birim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumption_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialStock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: false),
                    DepodakiMiktar = table.Column<double>(nullable: false),
                    AtolyedekiMiktar = table.Column<double>(nullable: false),
                    TedarikAsamasindakiMiktar = table.Column<double>(nullable: false),
                    StokMiktari = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialStock_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: false),
                    MalGirisiIslemeSuresi = table.Column<int>(nullable: false),
                    ToplamAcikSiparisMiktari = table.Column<double>(nullable: false),
                    AcikSATMiktari = table.Column<double>(nullable: false),
                    ImalataSonVerilisTarihi = table.Column<DateTime>(nullable: false),
                    DahiliUretimSuresi = table.Column<int>(nullable: false),
                    ToplamAcikSiparisTutari = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInformation_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: false),
                    TezgahAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wip_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyMaterialId = table.Column<int>(nullable: false),
                    SiparisVerilmeZamani = table.Column<DateTime>(nullable: false),
                    SiparisinGerceklesmeDurumu = table.Column<bool>(nullable: false),
                    SiparisTamamlanmaZamani = table.Column<DateTime>(nullable: false),
                    SiparisVermeMaliyeti = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_CompanyMaterial_CompanyMaterialId",
                        column: x => x.CompanyMaterialId,
                        principalTable: "CompanyMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefusalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    IadeNedeni = table.Column<string>(nullable: true),
                    IadeTarihi = table.Column<DateTime>(nullable: false),
                    IadeMiktari = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefusalInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefusalInformation_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "FirmaAdi", "FirmaKodu" },
                values: new object[,]
                {
                    { 1, "Firma1", "F1" },
                    { 2, "Firma2", "F2" }
                });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "Id", "EmniyetStok", "MaliyetSiniflandirmasi", "MalzemeAdi", "MalzemeHakkindaNotlar", "MalzemeKodu", "MalzemeninKullanimOmru", "SabitPartiBuyuklugu", "TeknikResim", "YenidenSiparisSeviyesi", "YillikTasmaOrani" },
                values: new object[,]
                {
                    { 1, 50.0, "A", "TK1745", "Malzeme Kaliteli", "1745", 0, "1 Adet", null, 75.0, 0.05 },
                    { 2, 1.0, "B", "TKY60336", "Malzeme kalitesiz", "60336", 0, "3 Adet", null, 1.0, 0.05 },
                    { 3, 75.0, "C", "TKY30198", "Malzeme orta kalitede", "30198", 0, "100 Adet", null, 100.0, 0.05 }
                });

            migrationBuilder.InsertData(
                table: "AlternativeMaterial",
                columns: new[] { "Id", "Material1Id", "Material2Id" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "CompanyMaterial",
                columns: new[] { "Id", "AsgariPartiBuyuklugu", "BirimMaliyet", "CompanyId", "MaterialId", "TedarikSuresi" },
                values: new object[,]
                {
                    { 1, 0, 340.0, 1, 1, 60 },
                    { 2, 3, 1340.0, 2, 2, 42 },
                    { 3, 3, 1340.0, 1, 2, 42 },
                    { 4, 3, 1340.0, 1, 2, 42 },
                    { 5, 100, 1340.0, 1, 3, 30 }
                });

            migrationBuilder.InsertData(
                table: "MaterialStock",
                columns: new[] { "Id", "AtolyedekiMiktar", "DepodakiMiktar", "MaterialId", "StokMiktari", "TedarikAsamasindakiMiktar" },
                values: new object[,]
                {
                    { 1, 0.0, 0.0, 1, 624.017, 0.0 },
                    { 2, 0.0, 0.0, 2, 1.0, 0.0 },
                    { 3, 0.0, 0.0, 3, 1580.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductInformation",
                columns: new[] { "Id", "AcikSATMiktari", "DahiliUretimSuresi", "ImalataSonVerilisTarihi", "MalGirisiIslemeSuresi", "MaterialId", "ToplamAcikSiparisMiktari", "ToplamAcikSiparisTutari" },
                values: new object[,]
                {
                    { 1, 50.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 0.0, 0.0 },
                    { 2, 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 270, 2, 15.0, 30.0 },
                    { 3, 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3, 12000.0, 5000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeMaterial_Material1Id",
                table: "AlternativeMaterial",
                column: "Material1Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativeMaterial_Material2Id",
                table: "AlternativeMaterial",
                column: "Material2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaterial_CompanyId",
                table: "CompanyMaterial",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMaterial_MaterialId",
                table: "CompanyMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumption_MaterialId",
                table: "Consumption",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialStock_MaterialId",
                table: "MaterialStock",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CompanyMaterialId",
                table: "Order",
                column: "CompanyMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInformation_MaterialId",
                table: "ProductInformation",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RefusalInformation_OrderId",
                table: "RefusalInformation",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Wip_MaterialId",
                table: "Wip",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlternativeMaterial");

            migrationBuilder.DropTable(
                name: "Consumption");

            migrationBuilder.DropTable(
                name: "MaterialStock");

            migrationBuilder.DropTable(
                name: "ProductInformation");

            migrationBuilder.DropTable(
                name: "RefusalInformation");

            migrationBuilder.DropTable(
                name: "Wip");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "CompanyMaterial");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
