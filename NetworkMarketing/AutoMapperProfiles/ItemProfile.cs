using AutoMapper;
using NetworkMarketing.BL.Dtos.ItemDtos;
using NetworkMarketing.BL.Entities;

namespace NetworkMarketing.AutoMapperProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<CreateItemDto, Item>();
            CreateMap<Item, GetItemDto>();
        }
    }
}
