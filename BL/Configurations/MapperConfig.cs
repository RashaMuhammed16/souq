using AutoMapper;
using BL.ViewModel;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

      


            CreateMap<OrderDetails, OrderDetailsViewModel>()
                 .ForMember(vm => vm.productName, m => m.MapFrom(u => u.Product.Name)).ReverseMap()
                 .ForMember(m => m.Order, m => m.Ignore())
                 .ForMember(m => m.Product, m => m.Ignore());

          
            CreateMap<Rate, RateViewModel>()
                //.ForMember(vm => vm.UserFullName, vm => vm.MapFrom(m => m.User.FullName))
                .ReverseMap();
            CreateMap<Rate,Rate>().ReverseMap()
                .ForMember(r => r.User, r => r.Ignore())
                .ForMember(r => r.Product, r => r.Ignore());

           
            CreateMap<ProductWishList, ProductWishListViewModel>().ReverseMap();

          
            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<BillingAddress, BillingAddressModelView>().ReverseMap();
            CreateMap<Shipper,ShipperViewModel>().ReverseMap();
            CreateMap<Brand, BrandViewModel>().ReverseMap();
        }
    }
}
