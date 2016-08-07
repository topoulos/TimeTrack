namespace TimeTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectTasks", new[] { "ProjectId" });
            AlterColumn("dbo.ProjectTasks", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectTasks", "ProjectId");
            AddForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectTasks", new[] { "ProjectId" });
            AlterColumn("dbo.ProjectTasks", "ProjectId", c => c.Int());
            CreateIndex("dbo.ProjectTasks", "ProjectId");
            AddForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects", "Id");
        }
    }
}
