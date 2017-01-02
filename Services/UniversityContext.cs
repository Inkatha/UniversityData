using Microsoft.EntityFrameworkCore;
using UniversityData.Models;

namespace UniversityData.Service
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        
        }
        public DbSet<BasicInfo> basicinfo { get; set;}
        public DbSet<CompletionRates> completionrates { get; set;}
        public DbSet<CostToAttend> costtoattend { get; set;}
        public DbSet<DegreesAwarded> degreesawarded { get; set;}
        public DbSet<DiversityStatistics> diversitystatistics { get; set;}
        public DbSet<EarningsAfterGraduation> earningsaftergraduation { get; set;}
        public DbSet<FinancialAidProvided> financialaidprovided { get; set;}
        public DbSet<InstitutionType> institutiontype { get; set;}
        public DbSet<RetentionRates> retentionrates { get; set;}
        public DbSet<StandardizedTestAverages> standardizedtestaverages { get; set;}
        public DbSet<StudentLoanDebts> studentloandebts { get; set;}
    }
}