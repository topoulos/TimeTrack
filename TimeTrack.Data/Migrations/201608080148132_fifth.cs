namespace TimeTrack.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.TimeEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        ProjectId = c.Int(),
                        ProjectTaskId = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.ProjectTasks", t => t.ProjectTaskId)
                .Index(t => t.ProjectId)
                .Index(t => t.ProjectTaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeEntries", "ProjectTaskId", "dbo.ProjectTasks");
            DropForeignKey("dbo.TimeEntries", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.TimeEntries", new[] { "ProjectTaskId" });
            DropIndex("dbo.TimeEntries", new[] { "ProjectId" });
            DropIndex("dbo.ProjectTasks", new[] { "ProjectId" });
            DropTable("dbo.TimeEntries");
            DropTable("dbo.ProjectTasks");
            DropTable("dbo.Projects");
        }
    }
}
