using BL.Bases;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class ShipperRepository : BaseRepository<Shipper>
    {
        private DbContext EC_DbContext;

        public ShipperRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<Shipper> GetAllShipper()
        {
            return GetAll().ToList();
        }

        public bool InsertShipper(Shipper shipper)
        {
            return Insert(shipper);
        }
        public void UpdateShipper(Shipper shipper)
        {
            Update(shipper);
        }
        public void DeleteShipper(int id)
        {
            Delete(id);
        }

        public bool CheckShipperExists(Shipper shipper)
        {
            return GetAny(l => l.ShipperID == shipper.ShipperID);
        }
        /*
        public Order GetOrderById(int id)
        {
        return GetFirstOrDefault(l => l.Id == id);
        }
        */

        public List<Shipper> ShipperByTimeDecending()
        {
            return EC_DbContext.Set<Shipper>().OrderByDescending(o => o.shipper_date).ToList();//.Include(o => o.appUser)
        }
        #endregion

    }
}