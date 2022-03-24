namespace _1911065701_LeHuuVang_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Courses", name: "Lecturer_Id", newName: "LecturerId");
            RenameIndex(table: "dbo.Courses", name: "IX_Lecturer_Id", newName: "IX_LecturerId");
            AddColumn("dbo.Courses", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Courses", "DataTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "DataTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Courses", "DateTime");
            RenameIndex(table: "dbo.Courses", name: "IX_LecturerId", newName: "IX_Lecturer_Id");
            RenameColumn(table: "dbo.Courses", name: "LecturerId", newName: "Lecturer_Id");
        }
    }
}
