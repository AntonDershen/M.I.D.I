namespace DataAccess.Interface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MusicModels", "ConvertedMusicModel_ConvertedMusicModelId", "dbo.ConvertedMusicModels");
            DropIndex("dbo.MusicModels", new[] { "ConvertedMusicModel_ConvertedMusicModelId" });
            AddColumn("dbo.MusicModels", "NewPath", c => c.String());
            DropColumn("dbo.MusicModels", "Content");
            DropColumn("dbo.MusicModels", "ConvertedMusicModel_ConvertedMusicModelId");
            DropTable("dbo.ConvertedMusicModels");
            DropTable("dbo.NoteModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NoteModels",
                c => new
                    {
                        NoteModelId = c.Int(nullable: false, identity: true),
                        RealTime = c.Double(nullable: false),
                        NoteNumber = c.Int(nullable: false),
                        Channel = c.Int(nullable: false),
                        CommandCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteModelId);
            
            CreateTable(
                "dbo.ConvertedMusicModels",
                c => new
                    {
                        ConvertedMusicModelId = c.Int(nullable: false, identity: true),
                        ConvertedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConvertedMusicModelId);
            
            AddColumn("dbo.MusicModels", "ConvertedMusicModel_ConvertedMusicModelId", c => c.Int());
            AddColumn("dbo.MusicModels", "Content", c => c.Binary());
            DropColumn("dbo.MusicModels", "NewPath");
            CreateIndex("dbo.MusicModels", "ConvertedMusicModel_ConvertedMusicModelId");
            AddForeignKey("dbo.MusicModels", "ConvertedMusicModel_ConvertedMusicModelId", "dbo.ConvertedMusicModels", "ConvertedMusicModelId");
        }
    }
}
