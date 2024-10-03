using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ecommerce.src.Entity;
using static ecommerce.src.DTO.CategoryDTO;
using static ecommerce.src.DTO.OrderDetailDTO;
using static ecommerce.src.DTO.OrderDTO;
using static ecommerce.src.DTO.ProductDTO;
using static ecommerce.src.DTO.UserDTO;

namespace ecommerce.src.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>().
            ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));

            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>()
                       .ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));

            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>().
            ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));

            CreateMap<OrderDetail, OrderDetailReadDto>();
            CreateMap<OrderDetailCreateDto, OrderDetail>().
            ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));

            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>().
            ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));
        }
    }
}