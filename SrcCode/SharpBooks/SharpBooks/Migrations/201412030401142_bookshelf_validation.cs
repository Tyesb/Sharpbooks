namespace SharpBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookshelf_validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookshelfItems", "ISBN", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookshelfItems", "ISBN", c => c.String());
        }
    }
}
