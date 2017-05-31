namespace DataAccess.Interface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class work : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumModels",
                c => new
                    {
                        AlbumModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumModelId);
            
            CreateTable(
                "dbo.MusicModels",
                c => new
                    {
                        MusicModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NewPath = c.String(),
                        Extension = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MusicModelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MusicModels");
            DropTable("dbo.AlbumModels");
        }
    }
}
