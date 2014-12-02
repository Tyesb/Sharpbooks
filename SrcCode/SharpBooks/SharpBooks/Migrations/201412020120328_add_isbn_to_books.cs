namespace SharpBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_isbn_to_books : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ISBN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ISBN");
        }
    }
}
