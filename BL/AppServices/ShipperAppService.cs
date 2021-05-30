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
    public class ShipperAppService : AppServiceBase
    {
        public ShipperAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<ShipperViewModel> GetAllShipper()
        {

            return Mapper.Map<List<ShipperViewModel>>(TheUnitOfWork.Shipper.GetAllShipper());
        }
        public ShipperViewModel GetShipper(int id)
        {
            return Mapper.Map<ShipperViewModel>(TheUnitOfWork.Shipper.GetById(id));
        }


        public bool SaveNewShipper(ShipperViewModel shipperViewModel)
        {
            bool result = false;
            var shipper = Mapper.Map<Shipper>(shipperViewModel);
            if (TheUnitOfWork.Shipper.Insert(shipper))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdatShipper(ShipperViewModel shipperViewModel)
        {
            var shipper = Mapper.Map<Shipper>(shipperViewModel);
            TheUnitOfWork.Shipper.Update(shipper);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteShipper(int id)
        {
            bool result = false;

            TheUnitOfWork.Shipper.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckShipperExists(ShipperViewModel shipperViewModel)
        {
            var shipper = Mapper.Map<Shipper>(shipperViewModel);
            return TheUnitOfWork.Shipper.CheckShipperExists(shipper);
        }
        #endregion

    }
}