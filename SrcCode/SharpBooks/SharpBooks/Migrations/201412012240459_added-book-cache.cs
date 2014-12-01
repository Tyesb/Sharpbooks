namespace SharpBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbookcache : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SearchQuery = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Cache_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Cache_Id");
            AddForeignKey("dbo.Books", "Cache_Id", "dbo.BookCaches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Cache_Id", "dbo.BookCaches");
            DropIndex("dbo.Books", new[] { "Cache_Id" });
            DropColumn("dbo.Books", "Cache_Id");
            DropTable("dbo.BookCaches");
        }
    }
}
