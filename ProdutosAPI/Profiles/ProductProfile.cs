using AutoMapper;
using ProdutosAPI.Dtos;
using ProdutosAPI.Models;

namespace ProdutosAPI.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ReadProductDto>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<Product, UpdateProductDto>();
    }
}
