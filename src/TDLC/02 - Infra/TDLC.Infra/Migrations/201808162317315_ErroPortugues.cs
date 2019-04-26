namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErroPortugues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_publicacao", "ContemAnexo", c => c.Boolean(nullable: false));
            DropColumn("dbo.tb_publicacao", "ContenAnexo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_publicacao", "ContenAnexo", c => c.Boolean(nullable: false));
            DropColumn("dbo.tb_publicacao", "ContemAnexo");
        }
    }
}
