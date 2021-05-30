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
    public class RateAppService : AppServiceBase
    {
        public RateAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public RateViewModel SaveNewReview(Rate rate)
        {

            bool result = false;
            if (TheUnitOfWork.Rate.Insert(rate))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return (result) ? Mapper.Map<RateViewModel>(rate) : null;
        }
        public RateViewModel UpdateRate(Rate rate)
        {
            bool result = false;
            Rate oldRate = TheUnitOfWork.Rate.GetRateById(rate.ID);
            Mapper.Map(rate, oldRate);
            TheUnitOfWork.Rate.Update(oldRate);
            result = TheUnitOfWork.Commit() > new int();
            return (result) ? Mapper.Map<RateViewModel>(oldRate) : null;
        }
        public bool DeleteReview(int id)
        {
            bool result = false;
            TheUnitOfWork.Rate.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public RateViewModel GetUserRateOnProduct(string userID, int productId)
        {
            Rate rate = TheUnitOfWork.Rate
                .GetUserRateOnProduct(userID, productId);
            return Mapper.Map<RateViewModel>(rate);

        }

        public double GetAverageRateForProduct(int productId)
        {
            return TheUnitOfWork.Rate.GetAverageRateForProduct(productId);
        }
        #region pagination
        public int CountEntity(int productId)
        {
            return TheUnitOfWork.Rate.CountProductRates(productId);
        }
        public IEnumerable<RateViewModel> GetPageRecords(int productId, int pageSize, int pageNumber)
        {
            return Mapper.Map<IEnumerable<RateViewModel>>(TheUnitOfWork.Rate.GetRatePageRecords(productId, pageSize, pageNumber));
        }
        #endregion


        

    }
}

