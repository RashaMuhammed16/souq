using BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methode
        int Commit();
        #endregion


       
        CategoryRepository Category { get; }
        SubCategoryRepository SubCategory { get; }
        ProductRepository  Product { get; }
        AccountRepository Account { get; }
        PaymentRepository Payment { get; }
        ModelRepository Model{ get; }
        BrandsRepository Brand { get; }
        OrderRepository Order { get; }
        OrderDetailsRepository OrderDetails { get; }
        ProductWishListRepository ProductWishList { get; }
        RateRepository Rate { get; }
<<<<<<< HEAD
        ShipperRepository Shipper { get; }
        BillingAddressRepository BillingAddress { get; }
=======
        CategoryRepository Category { get; }
        OrderRepository Order{ get; }
        AccountRepository account { get; }
        ProductRepository Product { get; }
        SubCategoryRepository SubCategoryRepository { get; }
>>>>>>> 6fc95b019d49c2f5dc1203fa14d86f7531d3c8be

    }
}
