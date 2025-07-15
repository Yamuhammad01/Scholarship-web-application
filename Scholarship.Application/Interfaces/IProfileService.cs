using Scholarship.Domain.Entities;
using Scholarship.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.Interfaces
{
    public interface IProfileService
    {
        Task AddStudentBiodataAsync(BiodataDTO biodatadto);
        Task UpdateBiodataAsync(int id, BiodataDTO biodatadto);
        Task<Registration> GetUserByEmailAsync(string email);
        Task<BiodataDTO> GetBiodataaByIdAsync(int id);

        //Academic Information IService
        Task AddAcademicInfoAsync(AcademicLevelDTO academicLevelDTO);
        Task UpdateAcademicInfoAsync(int id, AcademicLevelDTO academicLevelDTO);
       
       // Task<AcademicLevelDTO> GetAcademicInfoByIdAsync(int id);
    }
}
