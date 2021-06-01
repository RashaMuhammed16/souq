using AutoMapper;
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
    class Sub_CategortAppService:Bases.AppServiceBase
    {
       
        Sub_CategortAppService(IUnitOfWork iunitOfWork, IMapper mapper) : base(iunitOfWork, mapper)
        {

        }
        public List<Sub_CategoryViewModel>GetAll()
        {
            return Mapper.Map<List<Sub_CategoryViewModel>>(TheUnitOfWork.SubCategoryRepository.GetAll());
        }
        public Sub_CategoryViewModel GetById(int id)
        {
            return Mapper.Map<Sub_CategoryViewModel>(TheUnitOfWork.SubCategoryRepository.GetById(id));
        }
        public bool CheckSubcategoryExists(Sub_Catogery sub_Catogery)
        {
            
            return TheUnitOfWork.SubCategoryRepository.CheckSubCategoryExists(sub_Catogery);
        }
        public bool UpdateCategory(Sub_CategoryViewModel sub_Catogery)
        {
          Sub_Catogery sub_Catogery1= Mapper.Map<Sub_Catogery>(sub_Catogery);
            TheUnitOfWork.SubCategoryRepository.Update(sub_Catogery1);
            return TheUnitOfWork.Commit() > new int();
        }
        public bool DeleteSubCategory(Sub_CategoryViewModel sub_Catogery)
        {
            TheUnitOfWork.SubCategoryRepository.Delete(Mapper.Map<Sub_Catogery>(sub_Catogery));
            return TheUnitOfWork.Commit() > new int();
        }
       public bool SaveNewSubCategory(Sub_CategoryViewModel sub_CategoryViewModel)
        {
            TheUnitOfWork.SubCategoryRepository.AddSubCategory(Mapper.Map<Sub_Catogery>(sub_CategoryViewModel))
;
            return TheUnitOfWork.Commit() > new int();
        }

    

        

        
    }
}
