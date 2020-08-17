using AutoMapper;
using NetworkMarketing.BL.Dtos.SalesOrderDtos;
using NetworkMarketing.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkMarketing.AutoMapperProfiles
{
    public class SalesOrderProfile : Profile
    {
        public SalesOrderProfile()
        {
            CreateMap<CreateSalesOrderDto, SalesOrder>();
            //.ForMember(x=>x.TotalPrice, opt=>opt
            //.MapFrom(src=>src.Rows.Sum(x=>x.))
            CreateMap<CreateSalesOrderRowDto, SalesOrderRow>();
                
        }
    }
}
