using BL.Interfaces;
using BL.Repositories;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Common Properties
        private DbContext EC_DbContext { get; set; }
       


        #endregion

        #region Constructors
        
        #endregion

        #region Methods
        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }
        #endregion


       
      
        public OrderDetailsRepository orderDetails;//=> throw new NotImplementedException();
        public OrderDetailsRepository OrderDetails
        {
            get
            {
                if (orderDetails == null)
                    orderDetails = new OrderDetailsRepository(EC_DbContext);
                return orderDetails;
            }
        }

       

      
        public ProductWishListRepository productWishList;//=> throw new NotImplementedException();
        public ProductWishListRepository ProductWishList
        {
            get
            {
                if (productWishList == null)
                    productWishList = new ProductWishListRepository(EC_DbContext);
                return productWishList;
            }
        }

        public PaymentRepository payment;//=> throw new NotImplementedException();
        public PaymentRepository Payment
        {
            get
            {
                if (payment == null)
                    payment = new PaymentRepository(EC_DbContext);
                return payment;
            }
        }

        public ShipperRepository shipper;//=> throw new NotImplementedException();
        public ShipperRepository Shipper
        {
            get
            {
                if (shipper == null)
                    shipper= new ShipperRepository(EC_DbContext);
                return shipper;
            }
        }

        public BillingAddressRepository address;//=> throw new NotImplementedException();
        public BillingAddressRepository Address
        {
            get
            {
                if (address == null)
                   address = new BillingAddressRepository(EC_DbContext);
                return address;
            }
        }
        public BrandsRepository brand;//=> throw new NotImplementedException();
        public BrandsRepository Brand
        {
            get
            {
                if (brand == null)
                    brand = new BrandsRepository(EC_DbContext);
                return brand;
            }
        }
        public RateRepository rate;//=> throw new NotImplementedException();
        public RateRepository Rate 
        {
            get
            {
                if (rate== null)
                    rate = new RateRepository(EC_DbContext);
                return rate;
            }
        }
        public ModelRepository model;//=> throw new NotImplementedException();
        public ModelRepository Model
        {
            get
            {
                if (model == null)
                    model = new ModelRepository(EC_DbContext);
                return model;
            }
        }
        public CategoryRepository category;//=> throw new NotImplementedException();
        public CategoryRepository Category

        {
            get
            {
                if (category == null)
                    category = new CategoryRepository(EC_DbContext);
                return category;
            }
        }
        public OrderRepository order;//=> throw new NotImplementedException();
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                    order = new OrderRepository(EC_DbContext);
                return order;
            }
        }

        //public ModelRepository Model => throw new NotImplementedException();

        public BillingAddressRepository Wishlist => throw new NotImplementedException();

        public OrderDetailsRepository OrderProduct => throw new NotImplementedException();

        public RateRepository Review => throw new NotImplementedException();

        public BillingAddressRepository BillingAddress => throw new NotImplementedException();
    }
}
