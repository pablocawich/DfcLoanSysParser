namespace JsonParseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanApplicantProfileId = c.Int(),
                        GuarantorFinancialId = c.Int(),
                        IndividualFinancialsCode = c.String(),
                        IndividualFinancialsAmount = c.String(),
                        IndividualFinancialsDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuarantorFinancials", t => t.GuarantorFinancialId)
                .ForeignKey("dbo.LoanApplicantProfiles", t => t.LoanApplicantProfileId)
                .Index(t => t.LoanApplicantProfileId)
                .Index(t => t.GuarantorFinancialId);
            
            CreateTable(
                "dbo.GuarantorFinancials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomersIndusgrp = c.String(),
                        CustomersDepends = c.String(),
                        CustomersEmpstatus = c.String(),
                        CustomersHomeStatus = c.String(),
                        CustomersNumInhouse = c.String(),
                        CustomersYearsaddr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrossAnnualFamilyIncomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanApplicantProfileId = c.Int(),
                        GuarantorFinancialId = c.Int(),
                        CustomersFinancialIncome4 = c.String(),
                        CustomerSecondoccupation = c.String(),
                        CustomersFinancialIncome2 = c.String(),
                        CustomersFinancialIncome3 = c.String(),
                        CustomersFinancialIncome1 = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuarantorFinancials", t => t.GuarantorFinancialId)
                .ForeignKey("dbo.LoanApplicantProfiles", t => t.LoanApplicantProfileId)
                .Index(t => t.LoanApplicantProfileId)
                .Index(t => t.GuarantorFinancialId);
            
            CreateTable(
                "dbo.LoanApplicantProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomersSex = c.String(),
                        CustomersMailingAddress2 = c.String(),
                        CustomersTypeofid = c.String(),
                        CustomersMailingAddress1 = c.String(),
                        CustomersMailingcountry = c.String(),
                        CustomersIdnumber = c.String(),
                        CustomersLastname = c.String(),
                        CustomersFirstname = c.String(),
                        CustomersMiddlename = c.String(),
                        CustomersNationality = c.String(),
                        CustomersBusinessplace = c.String(),
                        CustomersEmployfrom = c.String(),
                        CustomersOccupation = c.String(),
                        CustomersFinancialIncome1 = c.String(),
                        CustomersDepends = c.String(),
                        CustomersEmpstatus = c.String(),
                        CustomersHomeStatus = c.String(),
                        CustomersNumInhouse = c.String(),
                        CustomersYearsaddr = c.String(),
                        CustomersNextKin = c.String(),
                        CustomersEmailname = c.String(),
                        CustomersHomephone = c.String(),
                        CustomersRelationshipkin = c.String(),
                        CustomersOtherphone = c.String(),
                        CustomersWorkphone = c.String(),
                        CustomersMobilphone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Liabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanApplicantProfileId = c.Int(),
                        GuarantorFinancialId = c.Int(),
                        IndividualFinancialsAmount = c.String(),
                        IndividualFinancialsDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuarantorFinancials", t => t.GuarantorFinancialId)
                .ForeignKey("dbo.LoanApplicantProfiles", t => t.LoanApplicantProfileId)
                .Index(t => t.LoanApplicantProfileId)
                .Index(t => t.GuarantorFinancialId);
            
            CreateTable(
                "dbo.SelfEmployeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuarantorFinancialId = c.Int(),
                        IndividualFinancialsAmount = c.String(),
                        IndividualFinancialsCode = c.String(),
                        IndividualFinancialsDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuarantorFinancials", t => t.GuarantorFinancialId)
                .Index(t => t.GuarantorFinancialId);
            
            CreateTable(
                "dbo.Guarantors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuarantorPersonalId = c.Int(nullable: false),
                        GuarantorFinancialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuarantorFinancials", t => t.GuarantorFinancialId, cascadeDelete: true)
                .ForeignKey("dbo.GuarantorPersonals", t => t.GuarantorPersonalId, cascadeDelete: true)
                .Index(t => t.GuarantorPersonalId)
                .Index(t => t.GuarantorFinancialId);
            
            CreateTable(
                "dbo.GuarantorPersonals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomersSex = c.String(),
                        CustomersMailingAddress1 = c.String(),
                        CustomersMailingtown = c.String(),
                        CustomersTypeofid = c.String(),
                        CustomersMailingAddress2 = c.String(),
                        CustomersMailingcountry = c.String(),
                        CustomersIdnumber = c.String(),
                        CustomersLastname = c.String(),
                        CustomersBirthdate = c.String(),
                        CustomersFirstname = c.String(),
                        CustomersMiddlename = c.String(),
                        CustomersMarriedstatus = c.String(),
                        CustomersNationality = c.String(),
                        CustomersNextKin = c.String(),
                        CustomersEmailname = c.String(),
                        CustomersRelationshipkin = c.String(),
                        CustomersHomephone = c.String(),
                        CustomersOtherphone = c.String(),
                        CustomersWorkphone = c.String(),
                        CustomersMobilphone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoansAppType = c.String(),
                        LoansAppldate = c.String(),
                        LoansBranchid = c.String(),
                        LoansFladescr = c.String(),
                        LoansFlaesins = c.String(),
                        LoansFlafxins = c.String(),
                        LoansFlagptmt = c.String(),
                        LoansFlagpval = c.String(),
                        LoansFlaicmet = c.String(),
                        LoansFlaicrat = c.String(),
                        LoansFlainsud = c.String(),
                        LoansFlainsup = c.String(),
                        LoansFlalocat = c.String(),
                        LoansFlalpmet = c.String(),
                        LoansFlaltype = c.String(),
                        LoansFlaptype = c.String(),
                        LoansFlarpmet = c.String(),
                        LoansFlasecto = c.String(),
                        LoansFlasubsc = c.String(),
                        LoansFlatloan = c.String(),
                        LoansFlattermm = c.String(),
                        LoansFlacurrncy = c.String(),
                        LoansInquirydate = c.String(),
                        LoansRepayCycle = c.String(),
                        LoansYearLength = c.String(),
                        LoansRefinanceamt = c.String(),
                        LoansConsolidateamt = c.String(),
                        LoansConsolNewamtreq = c.String(),
                        LoansPrincipalInterest = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MinorProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomersSex = c.String(),
                        CustomersArea = c.String(),
                        CustomersIdtype = c.String(),
                        CustomersStreet = c.String(),
                        CustomersCountry = c.String(),
                        CustomersIdnumber = c.String(),
                        CustomersLastname = c.String(),
                        CustomersFirstname = c.String(),
                        CustomersMiddlename = c.String(),
                        CustomersUploadidimage = c.String(),
                        CustomersBelizeanresident = c.String(),
                        CustomersEmail = c.String(),
                        CustomersFullName = c.String(),
                        CustomersHomephone = c.String(),
                        CustomersRelationborrower = c.String(),
                        CustomersBirthdate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guarantors", "GuarantorPersonalId", "dbo.GuarantorPersonals");
            DropForeignKey("dbo.Guarantors", "GuarantorFinancialId", "dbo.GuarantorFinancials");
            DropForeignKey("dbo.SelfEmployeds", "GuarantorFinancialId", "dbo.GuarantorFinancials");
            DropForeignKey("dbo.Liabilities", "LoanApplicantProfileId", "dbo.LoanApplicantProfiles");
            DropForeignKey("dbo.Liabilities", "GuarantorFinancialId", "dbo.GuarantorFinancials");
            DropForeignKey("dbo.GrossAnnualFamilyIncomes", "LoanApplicantProfileId", "dbo.LoanApplicantProfiles");
            DropForeignKey("dbo.Assets", "LoanApplicantProfileId", "dbo.LoanApplicantProfiles");
            DropForeignKey("dbo.GrossAnnualFamilyIncomes", "GuarantorFinancialId", "dbo.GuarantorFinancials");
            DropForeignKey("dbo.Assets", "GuarantorFinancialId", "dbo.GuarantorFinancials");
            DropIndex("dbo.Guarantors", new[] { "GuarantorFinancialId" });
            DropIndex("dbo.Guarantors", new[] { "GuarantorPersonalId" });
            DropIndex("dbo.SelfEmployeds", new[] { "GuarantorFinancialId" });
            DropIndex("dbo.Liabilities", new[] { "GuarantorFinancialId" });
            DropIndex("dbo.Liabilities", new[] { "LoanApplicantProfileId" });
            DropIndex("dbo.GrossAnnualFamilyIncomes", new[] { "GuarantorFinancialId" });
            DropIndex("dbo.GrossAnnualFamilyIncomes", new[] { "LoanApplicantProfileId" });
            DropIndex("dbo.Assets", new[] { "GuarantorFinancialId" });
            DropIndex("dbo.Assets", new[] { "LoanApplicantProfileId" });
            DropTable("dbo.MinorProfiles");
            DropTable("dbo.LoanConfigs");
            DropTable("dbo.GuarantorPersonals");
            DropTable("dbo.Guarantors");
            DropTable("dbo.SelfEmployeds");
            DropTable("dbo.Liabilities");
            DropTable("dbo.LoanApplicantProfiles");
            DropTable("dbo.GrossAnnualFamilyIncomes");
            DropTable("dbo.GuarantorFinancials");
            DropTable("dbo.Assets");
        }
    }
}
