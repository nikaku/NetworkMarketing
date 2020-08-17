using AutoMapper;
using NetworkMarketing.BL.Dtos.DistributorDtos;
using NetworkMarketing.BL.Dtos.ItemDtos;
using NetworkMarketing.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkMarketing.AutoMapperProfiles
{
    public class DistibutorProfile : Profile
    {
        public DistibutorProfile()
        {
            CreateMap<CreateDistributorDto, Distributor>();
            CreateMap<Distributor, GetDistributorDto>();
        }
    }
}
