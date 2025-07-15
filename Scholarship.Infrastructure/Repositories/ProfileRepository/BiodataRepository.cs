using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scholarship.Domain.Entities;
using Scholarship.Domain.Interfaces;
using Scholarship.Infrastructure.Persistence;


namespace Scholarship.Infrastructure.Repositories.ProfileRepository
{
    public class BiodataRepository : IBiodataRepository
    {
        private readonly ApplicationDbContext _context;
        public BiodataRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddBiodataAsync(Biodata biodata)
        {
            await _context.Biodata.AddAsync(biodata);
            await _context.SaveChangesAsync();
        }
        public async Task<Biodata> GetBiodataByIdAsync(int id)
        {
            return await _context.Biodata.FindAsync(id);
        }
        public async Task UpdateBiodataAsync(int id, Biodata biodata)
        {
            _context.Biodata.Update(biodata);
            // await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Biodata> GetBiodataaByIdAsync(int id)
        {
            return await _context.Biodata.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Registration> GetUserByEmailAsync(string email)
        {
            return await _context.Students
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }
        //Academic Information
        public async Task AddAcademicInfo(AcademicLevel academicLevel)
        {
            await _context.AcademicInfo.AddAsync(academicLevel);
            await _context.SaveChangesAsync();
        }
        public async Task<AcademicLevel> GetAcademicInfoByIdAsync(int id)
        {
            return await _context.AcademicInfo.FindAsync(id);
        }
        public async Task UpdateAcademicInfoAsync(int id, AcademicLevel academicLevel)
        {
            _context.AcademicInfo.Update(academicLevel);
            // await _context.SaveChangesAsync();
        }
      
    }
}
