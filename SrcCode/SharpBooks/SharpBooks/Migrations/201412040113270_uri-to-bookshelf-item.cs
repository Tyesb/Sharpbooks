namespace SharpBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uritobookshelfitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookshelfItems", "ImgURI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookshelfItems", "ImgURI");
        }
    }
}
