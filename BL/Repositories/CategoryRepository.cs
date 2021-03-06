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
     public class CategoryRepository: BaseRepository<Category>
    {
        private DbContext EC_DbContext;

        public CategoryRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Category> GetAllCategory()
        {
            return GetAll().ToList();
        }

        public bool InsertCategory(Category category)
        {
            return Insert(category);
        }
        public void UpdateCategory(Category category)
        {
            Update(category);
        }
        public void DeleteCategory(int id)
        {
            Delete(id);
        }

    }
}

