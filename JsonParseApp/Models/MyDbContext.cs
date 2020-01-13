using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace JsonParseApp.Models
{
    public class MyDbContext: DbContext
    {

        public MyDbContext()
        {
        }

        public DbSet<EducationProgramData> EducationProgramData { get; set; }
        public DbSet<StudentlnBorr> StudentlnBorrs { get; set; }
        public DbSet<LoanApplicantProfile> LoanAplApplicantProfiles { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Liability> Liabilities { get; set; }
        public DbSet<GrossAnnualFamilyIncome> GrossAnnualFamilyIncomes { get; set; }
        public DbSet<SelfEmployed> SelfEmployed { get; set; }
        public DbSet<MinorProfile> MinorProfiles { get; set; }
        public DbSet<LoanConfig> LoanConfigs { get; set; }
        public DbSet<Guarantor> Guarantors { get; set; }



    } 
}