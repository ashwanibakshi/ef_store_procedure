namespace dept.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.department",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(maxLength: 100, unicode: false),
                })
                .PrimaryKey(t => t.id);

            CreateStoredProcedure(
                "dbo.department_Insert",
                p => new
                    {
                        name = p.String(maxLength: 100, unicode: false),
                    },
                body:
                    @"INSERT [dbo].[department]([name])
                      VALUES (@name)
                      
                      DECLARE @id int
                      SELECT @id = [id]
                      FROM [dbo].[department]
                      WHERE @@ROWCOUNT > 0 AND [id] = scope_identity()
                      
                      SELECT t0.[id]
                      FROM [dbo].[department] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[id] = @id"
            );
            
            CreateStoredProcedure(
                "dbo.department_Update",
                p => new
                    {
                        id = p.Int(),
                        name = p.String(maxLength: 100, unicode: false),
                    },
                body:
                    @"UPDATE [dbo].[department]
                      SET [name] = @name
                      WHERE ([id] = @id)"
            );
            
            CreateStoredProcedure(
                "dbo.department_Delete",
                p => new
                    {
                        id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[department]
                      WHERE ([id] = @id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.department_Delete");
            DropStoredProcedure("dbo.department_Update");
            DropStoredProcedure("dbo.department_Insert");
            DropTable("dbo.department");
        }
    }
}
