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
            CreateMap<Sauce, SauceDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<MenuItemDTO, MenuItem>();
            CreateMap<MenuItem, MenuItemDTO>();
            CreateMap<Task<MenuItem>, MenuItemDTO>();
            CreateMap<Task<MenuItemDTO>, MenuItemDTO>();

            CreateMap<ItemIngredient, IngredientDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Ingredient.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ingredient.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Ingredient.Category))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Ingredient.Description))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Ingredient.Image));

            CreateMap<OrderItems, OrderItemsDTO>()
                .ForMember(dest => dest.MenuItem, opt => opt.MapFrom(src => src.MenuItem))
                .ForMember(dest => dest.Sauce, opt => opt.MapFrom(src => src.Sauce))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<OrderItemsDTO, OrderItems>()
                .ForMember(dest => dest.MenuItem, opt => opt.MapFrom(src => src.MenuItem))
                .ForMember(dest => dest.Sauce, opt => opt.MapFrom(src => src.Sauce))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Order,OrderDTO>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.MenuItems))
                .ForMember(dest => dest.OrderItemsEntities, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.TableId))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));

            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItemsEntities))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.TableId))
                .ForMember(dest => dest.TimePlaced, opt => opt.MapFrom(src => src.TimePlaced));

            CreateMap<SauceDTO, Sauce>();

            CreateMap<MenuItemSauce, MenuItemSauceDTO>()
                .ForMember(dest => dest.Sauce, opt => opt.MapFrom(src => src.Sauce))
                .ForMember(dest => dest.MenuItem, opt => opt.MapFrom(src => src.MenuItem));

            //CreateMap<MenuItemSauce, MenuItemSauceDTO>()
            //    .ForMember(dest => dest.MenuItemId, opt => opt.MapFrom(src => src.MenuItemId))
            //    .ForMember(dest => dest.SauceId, opt => opt.MapFrom(src => src.SauceId))
            //    .ForMember(dest => dest.Sauce, opt => opt.MapFrom(src => src.Sauce))
            //    .ForMember(dest => dest.Default, opt => opt.MapFrom(src => src.Default));
            //.ForMember(dest => dest.MenuItem, opt => opt.MapFrom(src => src.MenuItem));


            //CreateMap<OrderDTO, Order>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    //.ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            //    .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.TableId))
            //    .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
            //    .ForMember(dest => dest.TimePlaced, opt => opt.MapFrom(src => src.TimePlaced));

            //CreateMap<Order, OrderDTO>();

        }
    }
}
