using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using UniversityData;
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

        public async Task<DbDataReader> SchoolSearchAsync(string searchTerm) 
        {
            DatabaseConnection connString = new DatabaseConnection();
            NpgsqlConnectionStringBuilder npgsqlConnectionString = new NpgsqlConnectionStringBuilder(connString.GetConnectionString());
            NpgsqlConnection connection = new NpgsqlConnection(npgsqlConnectionString);
            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM \"public\".\"basicinfo\" WHERE instm LIKE @school_name LIMIT 25", connection);
            cmd.Parameters.AddWithValue("@school_name", "%" + searchTerm + "%");

            var result = await cmd.ExecuteReaderAsync();

            connection.Close();

            return result;
        }
    }
}