using Microsoft.EntityFrameworkCore;
using UniversityData.Models;

namespace UniversityData.Service
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        
        }
        public DbSet<BasicInfo> BasicInfo { get; set;}
        public DbSet<CompletionRates> CompletionRates { get; set;}
        public DbSet<CostToAttend> CostToAttend { get; set;}
        public DbSet<DegreesAwarded> DegreesAwarded { get; set;}
        public DbSet<DiversityStatistics> DiversityStatistics { get; set;}
        public DbSet<EarningsAfterGraduation> EarningsAfterGraduation { get; set;}
        public DbSet<FinancialAidProvided> FinancialAidProvided { get; set;}
        public DbSet<InstitutionType> InstitutionType { get; set;}
        public DbSet<RetentionRates> RetentionRates { get; set;}
        public DbSet<StandardizedTestAverages> StandardizedTestAverages { get; set;}
        public DbSet<StudentLoanDebts> StudentLoanDebts { get; set;}
    }
}