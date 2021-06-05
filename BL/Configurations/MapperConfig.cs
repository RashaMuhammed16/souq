using AutoMapper;
using BL.ViewModel;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BL.Configurations
{
    public static class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        static MapperConfig()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, UserViewModel>().ReverseMap();
                    cfg.CreateMap<OrderDetails, OrderDetailsViewModel>().ReverseMap();
                    cfg.CreateMap<Shipper, ShipperViewModel>().ReverseMap();
                    cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
                    cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                    cfg.CreateMap<Sub_Catogery, Sub_CategoryViewModel>().ReverseMap();
                    cfg.CreateMap<ProductWishList, ProductWishListViewModel>().ReverseMap();
                    cfg.CreateMap<Payment, PaymentViewModel>().ReverseMap();
                    cfg.CreateMap<Brand, BrandViewModel>().ReverseMap();
                    cfg.CreateMap<Model, ModelViewModel>().ReverseMap();
                    cfg.CreateMap<BillingAddress,BillingAddressModelView>().ReverseMap();
                    cfg.CreateMap<Rate, RateViewModel>().ReverseMap();
                    //cfg.CreateMap<IdentityResult, ResultStatue>().ReverseMap();

                });
            Mapper = config.CreateMapper();
        }
    }
}
