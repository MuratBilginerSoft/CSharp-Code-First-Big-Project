namespace YesilliOkul.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurulum2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        HaftalikDersSaati = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Egitmen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sinifs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ogrenciler",
                c => new
                    {
                        TC = c.Long(nullable: false),
                        Ad = c.String(maxLength: 50),
                        Soyad = c.String(),
                        DogumTarihi = c.DateTime(nullable: false),
                        Sinifi_ID = c.Int(),
                    })
                .PrimaryKey(t => t.TC)
                .ForeignKey("dbo.Sinifs", t => t.Sinifi_ID)
                .Index(t => t.Sinifi_ID);
            
            CreateTable(
                "dbo.Yoklamas",
                c => new
                    {
                        Tarih = c.Int(nullable: false, identity: true),
                        Dersi_ID = c.Int(),
                        Egitmeni_ID = c.Int(),
                        Ogrencisi_TC = c.Long(),
                    })
                .PrimaryKey(t => t.Tarih)
                .ForeignKey("dbo.Ders", t => t.Dersi_ID)
                .ForeignKey("dbo.Egitmen", t => t.Egitmeni_ID)
                .ForeignKey("dbo.Ogrenciler", t => t.Ogrencisi_TC)
                .Index(t => t.Dersi_ID)
                .Index(t => t.Egitmeni_ID)
                .Index(t => t.Ogrencisi_TC);
            
            CreateTable(
                "dbo.EgitmenDers",
                c => new
                    {
                        Egitmen_ID = c.Int(nullable: false),
                        Ders_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Egitmen_ID, t.Ders_ID })
                .ForeignKey("dbo.Egitmen", t => t.Egitmen_ID, cascadeDelete: true)
                .ForeignKey("dbo.Ders", t => t.Ders_ID, cascadeDelete: true)
                .Index(t => t.Egitmen_ID)
                .Index(t => t.Ders_ID);
            
            CreateTable(
                "dbo.SinifDers",
                c => new
                    {
                        Sinif_ID = c.Int(nullable: false),
                        Ders_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sinif_ID, t.Ders_ID })
                .ForeignKey("dbo.Sinifs", t => t.Sinif_ID, cascadeDelete: true)
                .ForeignKey("dbo.Ders", t => t.Ders_ID, cascadeDelete: true)
                .Index(t => t.Sinif_ID)
                .Index(t => t.Ders_ID);
            
            CreateTable(
                "dbo.SinifEgitmen",
                c => new
                    {
                        Sinif_ID = c.Int(nullable: false),
                        Egitmen_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sinif_ID, t.Egitmen_ID })
                .ForeignKey("dbo.Sinifs", t => t.Sinif_ID, cascadeDelete: true)
                .ForeignKey("dbo.Egitmen", t => t.Egitmen_ID, cascadeDelete: true)
                .Index(t => t.Sinif_ID)
                .Index(t => t.Egitmen_ID);
            
            CreateTable(
                "dbo.OgrenciDers",
                c => new
                    {
                        Ogrenci_TC = c.Long(nullable: false),
                        Ders_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ogrenci_TC, t.Ders_ID })
                .ForeignKey("dbo.Ogrenciler", t => t.Ogrenci_TC, cascadeDelete: true)
                .ForeignKey("dbo.Ders", t => t.Ders_ID, cascadeDelete: true)
                .Index(t => t.Ogrenci_TC)
                .Index(t => t.Ders_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yoklamas", "Ogrencisi_TC", "dbo.Ogrenciler");
            DropForeignKey("dbo.Yoklamas", "Egitmeni_ID", "dbo.Egitmen");
            DropForeignKey("dbo.Yoklamas", "Dersi_ID", "dbo.Ders");
            DropForeignKey("dbo.Ogrenciler", "Sinifi_ID", "dbo.Sinifs");
            DropForeignKey("dbo.OgrenciDers", "Ders_ID", "dbo.Ders");
            DropForeignKey("dbo.OgrenciDers", "Ogrenci_TC", "dbo.Ogrenciler");
            DropForeignKey("dbo.SinifEgitmen", "Egitmen_ID", "dbo.Egitmen");
            DropForeignKey("dbo.SinifEgitmen", "Sinif_ID", "dbo.Sinifs");
            DropForeignKey("dbo.SinifDers", "Ders_ID", "dbo.Ders");
            DropForeignKey("dbo.SinifDers", "Sinif_ID", "dbo.Sinifs");
            DropForeignKey("dbo.EgitmenDers", "Ders_ID", "dbo.Ders");
            DropForeignKey("dbo.EgitmenDers", "Egitmen_ID", "dbo.Egitmen");
            DropIndex("dbo.OgrenciDers", new[] { "Ders_ID" });
            DropIndex("dbo.OgrenciDers", new[] { "Ogrenci_TC" });
            DropIndex("dbo.SinifEgitmen", new[] { "Egitmen_ID" });
            DropIndex("dbo.SinifEgitmen", new[] { "Sinif_ID" });
            DropIndex("dbo.SinifDers", new[] { "Ders_ID" });
            DropIndex("dbo.SinifDers", new[] { "Sinif_ID" });
            DropIndex("dbo.EgitmenDers", new[] { "Ders_ID" });
            DropIndex("dbo.EgitmenDers", new[] { "Egitmen_ID" });
            DropIndex("dbo.Yoklamas", new[] { "Ogrencisi_TC" });
            DropIndex("dbo.Yoklamas", new[] { "Egitmeni_ID" });
            DropIndex("dbo.Yoklamas", new[] { "Dersi_ID" });
            DropIndex("dbo.Ogrenciler", new[] { "Sinifi_ID" });
            DropTable("dbo.OgrenciDers");
            DropTable("dbo.SinifEgitmen");
            DropTable("dbo.SinifDers");
            DropTable("dbo.EgitmenDers");
            DropTable("dbo.Yoklamas");
            DropTable("dbo.Ogrenciler");
            DropTable("dbo.Sinifs");
            DropTable("dbo.Egitmen");
            DropTable("dbo.Ders");
        }
    }
}
