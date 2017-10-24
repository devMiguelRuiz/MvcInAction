namespace MvcInAction.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddingCompanies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 200),
                        Address = c.String(maxLength: 200),
                        Email = c.String(false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Companies");
        }
    }
}
