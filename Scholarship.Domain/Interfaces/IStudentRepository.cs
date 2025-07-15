using Scholarship.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<Registration> GetByIdAsync(int id, string userId);
        Task<IEnumerable<Registration>> GetAllAsync();
        Task AddAsync(Registration student);
       // Task UpdateAsync(Registration student, string userId);
        Task DeleteAsync(int id, string userId);
        Task UpdateAsync(Registration student);
    }
}
