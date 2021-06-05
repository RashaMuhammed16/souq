using AutoMapper.Configuration;
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
    public class UnitOfWork: IUnitOfWork
    {
        /*#region Common Properties
        private DbContext EC_DbContext { get; set; }
        #region Common Properties
        UserManager<ApplicationUserIdentity> manger;
        RoleManager<IdentityRole> role;
        public UnitOfWork(DbContext context, UserManager<ApplicationUserIdentity> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.manger = userManager;
            this.role = roleManager;
            this.EC_DbContext = context;
            EC_DbContext = new ApplicationDBContext();//
            // Avoid load navigation properties
            //EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }
        
        #endregion*/

        // #region Constructors
        #region Common Properties
        private DbContext EC_DbContext { get; set; }
        // IConfiguration Configuration;
        #endregion

<<<<<<< HEAD
        #region Constructors
        public UnitOfWork()
        {
            EC_DbContext = new ApplicationDBContext();//
            // Avoid load navigation properties
            //EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }
=======
        // #region Constructors

>>>>>>> 6fc95b019d49c2f5dc1203fa14d86f7531d3c8be
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
                    shipper = new ShipperRepository(EC_DbContext);
                return shipper;
            }
        }

<<<<<<< HEAD
        public BillingAddressRepository billingaddress;//=> throw new NotImplementedException();
=======
        public BillingAddressRepository address;//=> throw new NotImplementedException();
>>>>>>> 6fc95b019d49c2f5dc1203fa14d86f7531d3c8be
        public BillingAddressRepository BillingAddress
        {
            get
            {
                if (billingaddress == null)
                    billingaddress = new BillingAddressRepository(EC_DbContext);
                return billingaddress;
            }
        }
        public AccountRepository accountt;//=> throw new NotImplementedException();
        public AccountRepository Account
        {
            get
            {
                if (accountt == null)
                    accountt = new AccountRepository(EC_DbContext);
                //accountt = new AccountRepository(EC_DbContext, manger, role);
                return accountt;
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
                if (rate == null)
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
        public SubCategoryRepository subCategory;//=> throw new NotImplementedException();
        public SubCategoryRepository SubCategory
        {
            get
            {
                if (subCategory == null)
                    subCategory = new SubCategoryRepository(EC_DbContext);
                return subCategory;
            }
        }
        public ProductRepository product;//=> throw new NotImplementedException();
        public ProductRepository Product
        {
            get
            {
                if (product == null)
                    product = new ProductRepository(EC_DbContext);
                return product;
            }

<<<<<<< HEAD

        }
=======
       




>>>>>>> 6fc95b019d49c2f5dc1203fa14d86f7531d3c8be
    }
    }

