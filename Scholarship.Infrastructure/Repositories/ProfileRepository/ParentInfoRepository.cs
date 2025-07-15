using Microsoft.EntityFrameworkCore;
using Scholarship.Domain.Entities;
using Scholarship.Domain.Entities.ParentInfo;
using Scholarship.Domain.Interfaces;
using Scholarship.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Infrastructure.Repositories.ProfileRepository
{
    public class ParentInfoRepository : IParentInfoRepository
    {
        private readonly ApplicationDbContext _context;
        public ParentInfoRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task AddFathersInfoAsync(FathersInfo fathersinfo)
        {
            _context.FathersInfo.Add(fathersinfo);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateFathersInfoAsync(int id, FathersInfo fathersinfo)
        {
            _context.FathersInfo.Update(fathersinfo);
            await _context.SaveChangesAsync();

        }
        public async Task<FathersInfo> GetFathersInfoByIdAsync(int id)
        {
            return await _context.FathersInfo.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddMothersInfoAsync(MothersInfo mothersInfo)
        {
            _context.MothersInfo.Add(mothersInfo);
            await _context.SaveChangesAsync();
        }
        public async Task<MothersInfo> GetMothersInfoByIdAsync(int id)
        {
            return await _context.MothersInfo.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateMothersInfoAsync(int id, MothersInfo mothersInfo)
        {
            _context.MothersInfo.Update(mothersInfo);
            await _context.SaveChangesAsync();

        }
        public async Task AddNextOfKinInfoAsync(NextOfKinInfo nextOfKinInfo)
        {
            _context.NextOfKinInfo.Add(nextOfKinInfo);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateNextOfKinInfoAsync(int id, NextOfKinInfo nextOfKinInfo)
        {
            _context.NextOfKinInfo.Update(nextOfKinInfo);
            await _context.SaveChangesAsync();

        }
        public async Task<NextOfKinInfo> GetNextOfKinInfoByIdAsync(int id)
        {
            return await _context.NextOfKinInfo.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
