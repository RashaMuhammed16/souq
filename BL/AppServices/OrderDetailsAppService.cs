using AutoMapper;
using BL.Bases;
using BL.Interfaces;
using BL.ViewModel;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    
        public class OrderDetailsAppService : AppServiceBase
        {
            public OrderDetailsAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
            {

            }
            #region CURD

            public List<OrderDetailsViewModel> GetAllOrderDetails()
            {

                return Mapper.Map<List<OrderDetailsViewModel>>(TheUnitOfWork.OrderDetails.GetAllOrderDetails());
            }
            //public CartViewModel GetCart(int id)
            //{
            //    return Mapper.Map<CartViewModel>(TheUnitOfWork.Cart.GetById(id));
            //}



            public bool SaveNewOrderProduct(OrderDetailsViewModel orderDetailsViewModel)
            {

                bool result = false;
                var orderDetails = Mapper.Map<OrderDetails>(orderDetailsViewModel);
                if (TheUnitOfWork.OrderDetails.Insert(orderDetails))
                {
                    result = TheUnitOfWork.Commit() > new int();
                }
                return result;
            }


            /*public bool UpdateCategory(OrderViewModel orderViewModel)
            {
                var category = Mapper.Map<Category>(orderViewModel);
                TheUnitOfWork.Category.Update(category);
                TheUnitOfWork.Commit();

                return true;
            }*/


            #endregion
        }
    }
