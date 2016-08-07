namespace TimeTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.TimeEntries", new[] { "ProjectTaskId" });
            DropIndex("dbo.TimeEntries", new[] { "ProjectId" });
            DropTable("dbo.TimeEntries");
        }
    }
}
