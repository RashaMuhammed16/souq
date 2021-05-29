using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    public class ApplicationUserIdentity : IdentityUser
    {
        // public string Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        [Required]
        public bool isDeleted { get; set; }
        //public List<Payment> Payments { get; set; }
    }
    public class ApplicationUserStore : UserStore<ApplicationUserIdentity>
    {

        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }



    //public class ApplicationRoleManager : RoleManager<IdentityRole>
    //{
    //    public ApplicationRoleManager()
    //        : base(new RoleStore<IdentityRole>(new ApplicationDBContext()))
    //    {

    //    }
    //    public ApplicationRoleManager(DbContext db)
    //        : base(new RoleStore<IdentityRole>(db))
    //    {

    //    }
    //}
    //public class ApplicationUserManager : UserManager<ApplicationUserIdentity>
    //{
    //    public ApplicationUserManager() : base(new ApplicationUserStore())
    //    {

    //    }
    //    public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
    //    {

    //    }

    //}
    public class ApplicationDBContext : IdentityDbContext<ApplicationUserIdentity>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Data Source=.;Initial Catalog=Souq;Integrated Security=True"
               , options => options.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Sub_Catogery> Sub_Catogeries { get; set; }
        public DbSet<BillingAddress> billingAddresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductWishList> ProductWishLists { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
