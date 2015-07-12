namespace SpectroWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ntextToVarcharChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String(storeType: "ntext"));
        }
    }
}
