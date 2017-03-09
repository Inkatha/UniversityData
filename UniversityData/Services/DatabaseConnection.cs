using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace UniversityData.Services
{
    public class DatabaseConnection
    {
        public IConfigurationRoot Configuration {get; set;}

        public DatabaseConnection() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("./appsettings.json");

                Configuration = builder.Build();
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