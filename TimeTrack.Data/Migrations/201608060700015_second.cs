namespace TimeTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProjectTasks", name: "Project_Id", newName: "ProjectId");
            RenameIndex(table: "dbo.ProjectTasks", name: "IX_Project_Id", newName: "IX_ProjectId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProjectTasks", name: "IX_ProjectId", newName: "IX_Project_Id");
            RenameColumn(table: "dbo.ProjectTasks", name: "ProjectId", newName: "Project_Id");
        }
    }
}
