namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class RunSqlScript : DbMigration
    {
        public override void Up()
        {
            //TODO EXECUTE INSERT DATA ONLY SCRIPT, REMOVE CREATE TABLE...
        }
        
        public override void Down()
        {
        }
    }
}
