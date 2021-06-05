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
    
        public class OrderDetailsAppService : BaseAppService
    {

            #region CURD
            public List<OrderDetailsViewModel> GetAllOrderDetails()
            {

                return Mapper.Map<List<OrderDetailsViewModel>>(TheUnitOfWork.OrderDetails.GetAllOrderDetails());
            }
            



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
