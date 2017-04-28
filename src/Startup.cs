using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using UniversityData.BindingModels.CostToAttend;
using UniversityData.BindingModels.StandardizedTesting;
using UniversityData.Models;
using UniversityData.Services;
using UniversityData.Services.Interfaces;
using NLog.Extensions.Logging;

namespace UniversityData
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DatabaseConnection connection = new DatabaseConnection();
            // Add framework services.
            services.AddMvc();
            var connectionString = connection.GetConnectionString();
            services.AddDbContext<UniversityContext>(
                opts => opts.UseNpgsql(connectionString)
            );

            services.AddScoped<IBasicInfoRepository, BasicInfoRepository>();
            services.AddScoped<ICompletionRatesRepository, CompletionRatesRepository>();
            services.AddScoped<ICostToAttendRepository, CostToAttendRepository>();
            services.AddScoped<IDegreesAwardedRepository, DegreesAwardedRepository>();
            services.AddScoped<IDiversityStatisticsRepository, DiversityStatisticsRepository>();
            services.AddScoped<IEarningsAfterGraduationRepository, EarningsAfterGraduationRepository>();
            services.AddScoped<IFinancialAidProvidedRepository, FinancialAidProvidedRepository>();
            services.AddScoped<IInstitutionTypeRepository, InstitutionTypeRepository>();
            services.AddScoped<IRetentionRatesRepository, RetentionRatesRepository>();
            services.AddScoped<IStandardizedTestAveragesRepository, StandardizedTestAveragesRepository>();
            services.AddScoped<IStudentLoanDebtsRepository, StudentLoanDebtsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<StandardizedTestAverages, SatTestAverages>();
                config.CreateMap<StandardizedTestAverages, ActTestAverages>();
                config.CreateMap<CostToAttend, CostToAttendPrivate>();
                config.CreateMap<CostToAttend, CostToAttendPublic>();
            });

            app.UseMvc();
        }
    }
}
