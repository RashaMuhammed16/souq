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
    public class OrderDetailsRepository : BaseRepository<OrderDetails>
    {
        private DbContext EC_DbContext;

        public OrderDetailsRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }



        public List<OrderDetails> GetAllOrderDetails()
        {
            return GetAll().Include(op => op.Product).ToList();
        }

        public bool InsertOrderDetails(OrderDetails orderDetails)
        {
            return Insert(orderDetails);
        }
        public void UpdateOrderDetails(OrderDetails orderDetails)
        {
            Update(orderDetails);
        }
        
    }
}