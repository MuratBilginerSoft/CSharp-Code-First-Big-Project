namespace YesilliOkul.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Yoklamas", name: "Ogrenci_TC", newName: "Ogrenci_ID");
            RenameIndex(table: "dbo.Yoklamas", name: "IX_Ogrenci_TC", newName: "IX_Ogrenci_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Yoklamas", name: "IX_Ogrenci_ID", newName: "IX_Ogrenci_TC");
            RenameColumn(table: "dbo.Yoklamas", name: "Ogrenci_ID", newName: "Ogrenci_TC");
        }
    }
}
