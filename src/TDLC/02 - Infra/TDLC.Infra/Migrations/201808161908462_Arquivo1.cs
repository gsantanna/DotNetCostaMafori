namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arquivo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_publicacao", "ContenAnexo", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_publicacao", "Arquivo", c => c.String(maxLength: 60, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_publicacao", "Arquivo");
            DropColumn("dbo.tb_publicacao", "ContenAnexo");
        }
    }
}
