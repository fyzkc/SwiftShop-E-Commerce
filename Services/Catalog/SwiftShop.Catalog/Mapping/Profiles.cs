using AutoMapper;
using SwiftShop.Catalog.Dtos.CategoryDtos;
using SwiftShop.Catalog.Dtos.ProductDetailDtos;
using SwiftShop.Catalog.Dtos.ProductDtos;
using SwiftShop.Catalog.Dtos.ProductImageDtos;
using SwiftShop.Catalog.Entities;

namespace SwiftShop.Catalog.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();            

            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        }
    }
}
