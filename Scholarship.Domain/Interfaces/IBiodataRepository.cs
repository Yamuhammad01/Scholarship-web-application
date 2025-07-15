using Scholarship.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Scholarship.Infrastructure.Repositories;

namespace Scholarship.Domain.Interfaces
{
    public interface IBiodataRepository
    {
        Task AddBiodataAsync(Biodata biodata);
        //Task<Biodata> GetByIdAsync(int id);
        Task<Biodata> GetBiodataByIdAsync(int id);
        Task<Biodata> GetBiodataaByIdAsync(int id);
        Task SaveChangesAsync();
        Task UpdateBiodataAsync(int id, Biodata biodata);
        Task<Registration> GetUserByEmailAsync(string email);
      

        //Academic Level Repository
         Task AddAcademicInfo(AcademicLevel academicLevel);
        
        Task<AcademicLevel> GetAcademicInfoByIdAsync(int id);
       
     
        Task UpdateAcademicInfoAsync(int id, AcademicLevel academicLevel);
    }
}
