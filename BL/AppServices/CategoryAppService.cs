
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
    public class CategoryAppService: BaseAppService
    {
        //public CategoryAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        //{

        // }

        #region CURD
        public List<CategoryViewModel> GetAllCategory()
        {

            return Mapper.Map<List<CategoryViewModel>>(TheUnitOfWork.Category.GetAllCategory());
        }
        public CategoryViewModel GetCategory(int id)
        {
            return Mapper.Map<CategoryViewModel>(TheUnitOfWork.Category.GetById(id));
        }



        public bool SaveNewCategory(CategoryViewModel categoryViewModel)
        {
            bool result = false;
            var category = Mapper.Map<Category>(categoryViewModel);
            if (TheUnitOfWork.Category.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


       
        public bool UpdateCategory(CategoryViewModel categoryViewModel)
        {
            var category = Mapper.Map<Category>(categoryViewModel);
            TheUnitOfWork.Category.Update(category);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.Category.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        /*public bool CheckCategoryExists(CategoryViewModel categoryViewModel)
        {
            Category category = Mapper.Map<Category>(categoryViewModel);
            return TheUnitOfWork.Category.CheckCategoryExists(category);
        }*/
        #endregion
    }
}
