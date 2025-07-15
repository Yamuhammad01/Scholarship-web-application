using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Scholarship.Application.DTOs.ParentInfoDTO;
using Scholarship.Domain.Entities.ParentInfo;

namespace Scholarship.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FathersDTO, FathersInfo>();
            CreateMap<FathersInfo, FathersInfo>();
            CreateMap<MothersDTO, MothersInfo>();
            CreateMap<NextOfKinDTO, NextOfKinInfo>();
        }
    }
}
