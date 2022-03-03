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
            //From - To
            CreateMap<MenuItemDTO, MenuItem>();
            CreateMap<MenuItem, MenuItemDTO>();
            CreateMap<Task<MenuItem>, MenuItemDTO>();
            CreateMap<Task<MenuItemDTO>, MenuItemDTO>();
            CreateMap<ItemIngredient, IngredientDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Ingredient.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ingredient.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Ingredient.Category));

            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.TableId))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.TimePlaced, opt => opt.MapFrom(src => src.TimePlaced));

            //CreateMap<Order, OrderDTO>();
            
        }
    }
}
