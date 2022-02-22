using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MenuItemDTO, MenuItem>();
            CreateMap<MenuItem, MenuItemDTO>();
            CreateMap<Task<MenuItem>, MenuItemDTO>();
            CreateMap<Task<MenuItemDTO>, MenuItemDTO>();
            CreateMap<ItemIngredient, IngredientDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Ingredient.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ingredient.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Ingredient.Category));
        }
    }
}
