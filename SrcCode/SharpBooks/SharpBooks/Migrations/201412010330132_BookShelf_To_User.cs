namespace SharpBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookShelf_To_User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookshelfItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISBN = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookshelfItems", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BookshelfItems", new[] { "User_Id" });
            DropTable("dbo.BookshelfItems");
        }
    }
}
