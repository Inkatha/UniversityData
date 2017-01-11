using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using UniversityData.Services;
using UniversityData.Services.Interfaces;
using System;

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
            // Add framework services.
            services.AddMvc();

            var connectionString = GetConnectionString();
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
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseResponseCompression();
            app.UseMvc();
        }

        public string GetConnectionString()
        {
            try {
                var uriString = Environment.GetEnvironmentVariable("ELEPHANT_UNIVERSITY_URL") ?? 
                            Configuration["DbContextSettings:ConnectionString"];
            
                // No need to parse string if ElephantSQL url is not available.
                if (uriString == Configuration["DbContextSettings:ConnectionString"])
                {
                    return uriString;
                }

                var uri = new Uri(uriString);
                var db = uri.AbsolutePath.Trim('/');
                var user = uri.UserInfo.Split(':')[0];
                var passwd = uri.UserInfo.Split(':')[1];
                var port = uri.Port > 0 ? uri.Port : 5432;
                var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}", uri.Host, db, user, passwd, port);

                return connStr;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occured", ex);
                return null;
            }
        }
    }
}
