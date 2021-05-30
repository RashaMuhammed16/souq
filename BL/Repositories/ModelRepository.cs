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
    public  class ModelRepository : BaseRepository<Model>
    {
        private DbContext EC_DbContext;
        public ModelRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }

        #region CRUB

        public List<Model> GetAllModel()
        {
            return GetAll().ToList();
        }

        public bool InsertModel(Model model)
        {
            return Insert(model);
        }
        public void UpdateModel(Model model)
        {
            Update(model);
        }
        public void DeleteModel(int id)
        {
            Delete(id);
        }

        public bool CheckModelExists(Model model)
        {
            return GetAny(l => l.ID == model.ID);
        }
        public Model GetModelById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        #endregion


    }
}


