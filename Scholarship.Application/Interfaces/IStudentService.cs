using Scholarship.Application.DTOs;
using Scholarship.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<RegistrationDTO>> GetAllStudentsAsync();
        Task<GetStudentDto> GetStudentByIdAsync(int id, string userId);
       // Task AddStudentAsync(RegistrationDTO student);
        Task UpdateStudentAsync(int id, RegistrationDTO student, string userId);
        Task DeleteStudentAsync(int id, string userId);
        Task AddStudentAsync(Registration registration);
    }
}
