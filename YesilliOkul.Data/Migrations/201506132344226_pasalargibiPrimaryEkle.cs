namespace YesilliOkul.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pasalargibiPrimaryEkle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Yoklamas", "Dersi_ID", "dbo.Ders");
            DropForeignKey("dbo.Yoklamas", "Ogrencisi_TC", "dbo.Ogrenciler");
            DropIndex("dbo.Yoklamas", new[] { "Dersi_ID" });
            DropIndex("dbo.Yoklamas", new[] { "Ogrencisi_TC" });
            RenameColumn(table: "dbo.Yoklamas", name: "Dersi_ID", newName: "Ders_ID");
            RenameColumn(table: "dbo.Yoklamas", name: "Ogrencisi_TC", newName: "Ogrenci_TC");
            DropPrimaryKey("dbo.Yoklamas");
            AlterColumn("dbo.Yoklamas", "Tarih", c => c.Int(nullable: false));
            AlterColumn("dbo.Yoklamas", "Ders_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Yoklamas", "Ogrenci_TC", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Yoklamas", new[] { "Tarih", "Ogrenci_TC", "Ders_ID" });
            CreateIndex("dbo.Yoklamas", "Ogrenci_TC");
            CreateIndex("dbo.Yoklamas", "Ders_ID");
            AddForeignKey("dbo.Yoklamas", "Ders_ID", "dbo.Ders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Yoklamas", "Ogrenci_TC", "dbo.Ogrenciler", "TC", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yoklamas", "Ogrenci_TC", "dbo.Ogrenciler");
            DropForeignKey("dbo.Yoklamas", "Ders_ID", "dbo.Ders");
            DropIndex("dbo.Yoklamas", new[] { "Ders_ID" });
            DropIndex("dbo.Yoklamas", new[] { "Ogrenci_TC" });
            DropPrimaryKey("dbo.Yoklamas");
            AlterColumn("dbo.Yoklamas", "Ogrenci_TC", c => c.Long());
            AlterColumn("dbo.Yoklamas", "Ders_ID", c => c.Int());
            AlterColumn("dbo.Yoklamas", "Tarih", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Yoklamas", "Tarih");
            RenameColumn(table: "dbo.Yoklamas", name: "Ogrenci_TC", newName: "Ogrencisi_TC");
            RenameColumn(table: "dbo.Yoklamas", name: "Ders_ID", newName: "Dersi_ID");
            CreateIndex("dbo.Yoklamas", "Ogrencisi_TC");
            CreateIndex("dbo.Yoklamas", "Dersi_ID");
            AddForeignKey("dbo.Yoklamas", "Ogrencisi_TC", "dbo.Ogrenciler", "TC");
            AddForeignKey("dbo.Yoklamas", "Dersi_ID", "dbo.Ders", "ID");
        }
    }
}
