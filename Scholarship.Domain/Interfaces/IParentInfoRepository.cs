using Scholarship.Domain.Entities;
using Scholarship.Domain.Entities.ParentInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Domain.Interfaces
{
    public interface IParentInfoRepository
    {
        Task AddFathersInfoAsync(FathersInfo fathersinfo);
        Task UpdateFathersInfoAsync(int id, FathersInfo fathersinfo);
        Task<FathersInfo> GetFathersInfoByIdAsync(int id);
        Task<MothersInfo> GetMothersInfoByIdAsync(int id);
        Task AddMothersInfoAsync(MothersInfo mothersInfo);
        Task UpdateMothersInfoAsync(int id, MothersInfo mothersInfo);
        
        Task AddNextOfKinInfoAsync(NextOfKinInfo nextOfKinInfo);
        Task UpdateNextOfKinInfoAsync(int id, NextOfKinInfo nextOfKinInfo);
        Task<NextOfKinInfo> GetNextOfKinInfoByIdAsync(int id);
        Task SaveChangesAsync();
        
        // Task AddFathersInfoAsync(Scholarship.Application.DTOs.ParentInfoDTO.FathersDTO fathersinfo);
        //Task<Biodata> GetByIdAsync(int id);
        //Task<Biodata> GetBiodataByIdAsync(int id);
        //Task<Biodata> GetBiodataaByIdAsync(int id);
        //Task SaveChangesAsync();
        //Task UpdateBiodataAsync(int id, Biodata biodata);
    }
}
