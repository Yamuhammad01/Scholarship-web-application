using Microsoft.EntityFrameworkCore;
using Scholarship.Domain.Entities;
using Scholarship.Domain.Interfaces;
using Scholarship.Infrastructure.Persistence;

namespace Scholarship.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Registration student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);
            if (student == null)
                throw new UnauthorizedAccessException("Access denied");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Registration>> GetAllAsync() => await _context.Students.ToListAsync();

        public async Task<Registration> GetByIdAsync(int id, string userId)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }

        public async Task UpdateAsync(Registration student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
