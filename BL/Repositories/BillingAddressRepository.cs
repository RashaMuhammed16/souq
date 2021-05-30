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
   public  class BillingAddressRepository : BaseRepository<BillingAddress>
    {
        private DbContext EC_DbContext;
        public BillingAddressRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }

        #region CRUB

        public List<BillingAddress> GetAllBillingAddress()
        {
            return GetAll().ToList();
        }

        public bool InsertBillingAddress(BillingAddress billingAddress)
        {
            return Insert(billingAddress);
        }
        public void UpdateBillingAddress(BillingAddress billingAddress)
        {
            Update(billingAddress);
        }
        public void DeleteBillingAddress(int id)
        {
            Delete(id);
        }

        public bool CheckBillingAddressExists(BillingAddress billingaddress)
        {
            return GetAny(l => l.ID == billingaddress.ID);
        }
        public BillingAddress GetBillingAddressById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        #endregion


    }
}

