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


        BrandsRepository Brand  { get; }
        PaymentRepository Payment { get; }
       ModelRepository Model { get; }
       BillingAddressRepository BillingAddress { get; }
       
        ShipperRepository Shipper { get; } 
        ProductWishListRepository ProductWishList { get; }
        OrderDetailsRepository OrderDetails { get; }
        RateRepository Rate { get; }
        CategoryRepository Category { get; }
        OrderRepository Order { get; }

    }
}
