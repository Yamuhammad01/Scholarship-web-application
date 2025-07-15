using Scholarship.Domain.Entities.ParentInfo;
using Scholarship.Application.DTOs.ParentInfoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholarship.Application.DTOs;

namespace Scholarship.Application.Interfaces
{
    public interface IParentInfoService
    {
        Task<FathersDTO> GetFathersInfoByIdAsync(int id);
        Task AddFathersInfoAsync(FathersDTO fathersDTO);
        Task UpdateFathersInfoAsync(int id, FathersDTO fathersDTO);

        Task AddMothersInfoAsync(MothersDTO mothersDTO);
        Task UpdateMothersInfoAsync(int id, MothersDTO mothersDTO);

        Task AddNextOfKinInfoAsync(NextOfKinDTO nextOfKinDTO);
        Task UpdateNextOfKinInfoAsync(int id, NextOfKinDTO nextOfKinDTO);
    }
}
