namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qsyo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuracion", "DepositoStockId", c => c.Long(nullable: false));
            AddColumn("dbo.Configuracion", "DepositoVentaId", c => c.Long(nullable: false));
            AddColumn("dbo.Configuracion", "ActivarBascula", c => c.Boolean(nullable: false));
            AddColumn("dbo.Configuracion", "CodigoBascula", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Configuracion", "EsImpresionPorPrecio", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Configuracion", "DepositoStockId");
            CreateIndex("dbo.Configuracion", "DepositoVentaId");
            AddForeignKey("dbo.Configuracion", "DepositoStockId", "dbo.Deposito", "Id");
            AddForeignKey("dbo.Configuracion", "DepositoVentaId", "dbo.Deposito", "Id");
            DropColumn("dbo.Configuracion", "DepositoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Configuracion", "DepositoId", c => c.Long(nullable: false));
            DropForeignKey("dbo.Configuracion", "DepositoVentaId", "dbo.Deposito");
            DropForeignKey("dbo.Configuracion", "DepositoStockId", "dbo.Deposito");
            DropIndex("dbo.Configuracion", new[] { "DepositoVentaId" });
            DropIndex("dbo.Configuracion", new[] { "DepositoStockId" });
            DropColumn("dbo.Configuracion", "EsImpresionPorPrecio");
            DropColumn("dbo.Configuracion", "CodigoBascula");
            DropColumn("dbo.Configuracion", "ActivarBascula");
            DropColumn("dbo.Configuracion", "DepositoVentaId");
            DropColumn("dbo.Configuracion", "DepositoStockId");
        }
    }
}
