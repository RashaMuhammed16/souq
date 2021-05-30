﻿using AutoMapper;
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
   public class BrandAppService : AppServiceBase
    {
        public BrandAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<BrandViewModel> GetAllBrand()
        {

            return Mapper.Map<List<BrandViewModel>>(TheUnitOfWork.Brand.GetAllBrand());
        }
        public ShipperViewModel GetBrand(int id)
        {
            return Mapper.Map<ShipperViewModel>(TheUnitOfWork.Brand.GetById(id));
        }


        public bool SaveNewBrand(BrandViewModel brandViewModel)
        {
            bool result = false;
            var brand = Mapper.Map<Brand>(brandViewModel);
            if (TheUnitOfWork.Brand.Insert(brand))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdatShipper(ShipperViewModel shipperViewModel)
        {
            var shipper = Mapper.Map<Brand>(shipperViewModel);
            TheUnitOfWork.Brand.Update(shipper);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteBrand(int id)
        {
            bool result = false;

            TheUnitOfWork.Brand.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckBrandExists(BrandViewModel brandViewModel)
        {
            var brand = Mapper.Map<Brand>(brandViewModel);
            return TheUnitOfWork.Brand.CheckBrandExists(brand);
        }
        #endregion

    }  
    
    }
