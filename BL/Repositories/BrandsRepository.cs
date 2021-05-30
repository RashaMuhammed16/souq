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
   public class BrandsRepository : BaseRepository<Brand>
    {
        private DbContext EC_DbContext;
        public BrandsRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }

        #region CRUB

        public List<Brand> GetAllBrand()
        {
            return GetAll().ToList();
        }

        public bool InsertBrand(Brand brand)
        {
            return Insert(brand);
        }
        public void UpdateBrand(Brand brand)
        {
            Update(brand);
        }
        public void DeleteBrand(int id)
        {
            Delete(id);
        }

        public bool CheckBrandExists(Brand brand)
        {
            return GetAny(l => l.ID == brand.ID);
        }
        public Brand GetBrandById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        #endregion


    }
}
