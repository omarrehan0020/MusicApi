namespace MusicApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Songs", "Album_Id", c => c.Int());
            AddColumn("dbo.Songs", "Artist_Id", c => c.Int());
            CreateIndex("dbo.Songs", "Album_Id");
            CreateIndex("dbo.Songs", "Artist_Id");
            AddForeignKey("dbo.Songs", "Album_Id", "dbo.Albums", "Id");
            AddForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists", "Id");
            DropColumn("dbo.Songs", "ImageUrl");
            DropColumn("dbo.Songs", "AudioUrl");
            DropColumn("dbo.Songs", "ArtistId");
            DropColumn("dbo.Songs", "AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.Songs", "ArtistId", c => c.Int(nullable: false));
            AddColumn("dbo.Songs", "AudioUrl", c => c.String());
            AddColumn("dbo.Songs", "ImageUrl", c => c.String());
            DropForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "Artist_Id" });
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropColumn("dbo.Songs", "Artist_Id");
            DropColumn("dbo.Songs", "Album_Id");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
