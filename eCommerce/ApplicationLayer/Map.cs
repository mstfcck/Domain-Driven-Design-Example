using AutoMapper;
using eCommerce.ApplicationLayer.Carts;
using eCommerce.ApplicationLayer.Carts.Dtos;
using eCommerce.ApplicationLayer.Customers;
using eCommerce.ApplicationLayer.Customers.Dtos;
using eCommerce.ApplicationLayer.History;
using eCommerce.ApplicationLayer.History.Dtos;
using eCommerce.ApplicationLayer.Products;
using eCommerce.ApplicationLayer.Products.Dtos;
using eCommerce.DomainModelLayer.Carts;
using eCommerce.DomainModelLayer.Customers;
using eCommerce.DomainModelLayer.Customers.ReadModels;
using eCommerce.DomainModelLayer.Products;
using eCommerce.DomainModelLayer.Purchases;
using eCommerce.Helpers.Domain;

namespace eCommerce.ApplicationLayer
{
    public class Map : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Cart, CartDto>();
            Mapper.CreateMap<CartProduct, CartProductDto>();

            Mapper.CreateMap<Purchase, CheckOutResultDto>().ForMember(x => x.PurchaseId, options => options.MapFrom(x => x.Id));

            Mapper.CreateMap<CreditCard, CreditCardDto>();
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<CustomerPurchaseHistoryReadModel, CustomerPurchaseHistoryDto>();
            Mapper.CreateMap<DomainEventRecord, EventDto>();
        }
    }
}