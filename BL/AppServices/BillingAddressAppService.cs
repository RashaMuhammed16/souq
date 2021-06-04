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
   public class BillingAddressAppService : AppServiceBase
    {
        public BillingAddressAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<BillingAddressModelView> GetAllBillingAddress()
        {

            return Mapper.Map<List<BillingAddressModelView>>(TheUnitOfWork.BillingAddress.GetAllBillingAddress());
        }
        public BillingAddressModelView GetBillingAddress(int id)
        {
            return Mapper.Map<BillingAddressModelView>(TheUnitOfWork.BillingAddress.GetById(id));
        }


        public bool SaveNewBillingAddress(BillingAddressModelView billingAddressModelView)
        {
            bool result = false;
            var brand = Mapper.Map<BillingAddress>(billingAddressModelView);
            if (TheUnitOfWork.BillingAddress.Insert(brand))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdatBilling(BillingAddressModelView BillingAddressModelView)
        {
            var billingAddress = Mapper.Map<BillingAddress>(BillingAddressModelView);
            TheUnitOfWork.BillingAddress.Update(billingAddress);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteBillingAddress(int id)
        {
            bool result = false;

            TheUnitOfWork.BillingAddress.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckBillingAddressExists(BillingAddressModelView billingAddressViewModel)
        {
            var billingAddress  = Mapper.Map<BillingAddress>(billingAddressViewModel);
            return TheUnitOfWork.BillingAddress.CheckBillingAddressExists(billingAddress);
        }
        #endregion

    }

}
