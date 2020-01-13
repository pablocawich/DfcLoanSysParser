namespace JsonParseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationProgramDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentlnQual1 = c.String(),
                        StudentlnDuration = c.String(),
                        StudentlnLevel = c.String(),
                        StudentlnCourse = c.String(),
                        StudentlnPastschool1 = c.String(),
                        StudentlnPastqual1 = c.String(),
                        StudentlnSchool = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentlnBorrs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EducationProgramDataId = c.Int(nullable: false),
                        StudentlnBorrItemval = c.String(),
                        StudentlnBorrAiditem = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationProgramDatas", t => t.EducationProgramDataId, cascadeDelete: true)
                .Index(t => t.EducationProgramDataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentlnBorrs", "EducationProgramDataId", "dbo.EducationProgramDatas");
            DropIndex("dbo.StudentlnBorrs", new[] { "EducationProgramDataId" });
            DropTable("dbo.StudentlnBorrs");
            DropTable("dbo.EducationProgramDatas");
        }
    }
}
