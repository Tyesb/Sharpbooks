namespace SharpBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uriinbook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImgURI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImgURI");
        }
    }
}
