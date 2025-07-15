using AutoMapper;
using Scholarship.Application.DTOs;
using Scholarship.Application.DTOs.ParentInfoDTO;
using Scholarship.Application.Interfaces;
using Scholarship.Domain.Entities;
using Scholarship.Domain.Entities.ParentInfo;
using Scholarship.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.Services
{
    public class ParentInfoService : IParentInfoService
    {
        private readonly IParentInfoRepository _parentInfoRepository;
        private readonly IMapper _mapper;
        public ParentInfoService(IParentInfoRepository parentInfoRepository, IMapper mapper)
        {
            _parentInfoRepository = parentInfoRepository;
            _mapper = mapper;
        }
        public async Task AddFathersInfoAsync(FathersDTO fathersDTO)
        {
           var fathersInfo = _mapper.Map<FathersInfo>(fathersDTO);
            await _parentInfoRepository.AddFathersInfoAsync(fathersInfo);
        }
        public async Task<FathersDTO> GetFathersInfoByIdAsync(int id)
        {
            var entity = await _parentInfoRepository.GetFathersInfoByIdAsync(id);
            if (entity == null)
                return null;

            return _mapper.Map<FathersDTO>(entity);
        }
        public async Task UpdateFathersInfoAsync(int id, FathersDTO fathersDTO)
        {
            var fathersinfo = await _parentInfoRepository.GetFathersInfoByIdAsync(id);

            if (fathersinfo == null)
                throw new KeyNotFoundException($"Father's info not found");

            _mapper.Map(fathersDTO, fathersinfo);

            // Update the entity
            await _parentInfoRepository.UpdateFathersInfoAsync(id, fathersinfo);

            // Save changes
            await _parentInfoRepository.SaveChangesAsync();
        }
        public async Task AddMothersInfoAsync(MothersDTO mothersDTO)
        {
            var mothersInfo = _mapper.Map<MothersInfo>(mothersDTO);
            await _parentInfoRepository.AddMothersInfoAsync(mothersInfo);
        }
        public async Task UpdateMothersInfoAsync(int id, MothersDTO mothersDTO)
        {
            var mothersInfo = await _parentInfoRepository.GetMothersInfoByIdAsync(id);

            if (mothersInfo == null)
                throw new KeyNotFoundException($"Not Found");

            _mapper.Map<MothersInfo>(mothersDTO);                                                                       

            // Update the entity
            await _parentInfoRepository.UpdateMothersInfoAsync(id, mothersInfo);

            // Save changes
            await _parentInfoRepository.SaveChangesAsync();
        }
        public async Task AddNextOfKinInfoAsync(NextOfKinDTO nextOfKinDTO)
        {
            var nextOfKinInfo = _mapper.Map<NextOfKinInfo>(nextOfKinDTO);
            await _parentInfoRepository.AddNextOfKinInfoAsync(nextOfKinInfo);
        }
        public async Task UpdateNextOfKinInfoAsync(int id, NextOfKinDTO nextOfKinDTO)
        {
            var nextOfKinInfo = await _parentInfoRepository.GetNextOfKinInfoByIdAsync(id);

            if (nextOfKinInfo == null)
                throw new KeyNotFoundException($"Not Found");

            _mapper.Map<MothersInfo>(nextOfKinDTO);

            // Update the entity
            await _parentInfoRepository.UpdateNextOfKinInfoAsync(id, nextOfKinInfo);

            // Save changes
            await _parentInfoRepository.SaveChangesAsync();
        }
    }
}
