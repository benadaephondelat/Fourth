namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            Sql(Properties.Resources.SeedData_Up.ToString());
        }
        
        public override void Down()
        {
        }
    }
}
