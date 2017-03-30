using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Npgsql;
using UniversityData.Models;
using UniversityData.Services.Interfaces;

namespace UniversityData.Services
{
    public class BasicInfoRepository : IBasicInfoRepository
    {
        private readonly UniversityContext _context;

        public BasicInfoRepository(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BasicInfo>> GetAllBasicInformationAsync()
        {
            var result = await _context.basicinfo.OrderBy(c => c.unitid).ToListAsync();
            return result;
        }

        public async Task<BasicInfo> GetSchoolBasicInformationAsync(int unitId)
        {
            var result = await _context.basicinfo.FirstOrDefaultAsync(c => c.unitid == unitId);
            return result;
        }

        public async Task<string> GetSchoolNameAsync(int unitId)
        {
            var result = await GetSchoolBasicInformationAsync(unitId);
            return result.instnm;
        }

        public async Task<string> GetSchoolUrlAsync(int unitId)
        {
            var result = await GetSchoolBasicInformationAsync(unitId);
            return result.insturl;
        }

        public async Task<bool> SchoolExistsAsync(int unitId)
        {
            var result = await _context.basicinfo.AnyAsync(c => c.unitid == unitId);
            return result;
        }

        public async Task<string> SchoolSearchAsync(string searchTerm) 
        {
            DatabaseConnection connString = new DatabaseConnection();
            NpgsqlConnectionStringBuilder npgsqlConnectionString = new NpgsqlConnectionStringBuilder(connString.GetConnectionString());
            NpgsqlConnection connection = new NpgsqlConnection(npgsqlConnectionString);
            connection.Open();

            string unitId = "";
            string institutionName = "";
            var institutions = new Dictionary<string, string>();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT unitid, instnm FROM \"public\".\"basicinfo\" WHERE LOWER(instnm) LIKE LOWER(@school_name) LIMIT 10", connection);
            cmd.Parameters.AddWithValue("@school_name", "%" + searchTerm + "%");
            
            using (var reader = await cmd.ExecuteReaderAsync()) 
            {
                while (reader.Read())
                {
                    unitId = reader.GetString(reader.GetOrdinal("unitid"));
                    institutionName = reader.GetString(reader.GetOrdinal("instnm"));

                    institutions.Add(unitId, institutionName);
                }
            }

            connection.Close();
            
            return JsonConvert.SerializeObject(institutions);
        }
    }
}