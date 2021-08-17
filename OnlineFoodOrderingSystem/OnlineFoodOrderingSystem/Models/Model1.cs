using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnlineFoodOrderingSystem.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Address_> Address_ { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Cuisine> Cuisine { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<Order_> Order_ { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<OrderState> OrderState { get; set; }
        public virtual DbSet<PaymentCard> PaymentCard { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Role_> Role_ { get; set; }
        public virtual DbSet<User_> User_ { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<UserFavourite> UserFavourite { get; set; }
        public virtual DbSet<UserRating> UserRating { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address_>()
                .HasMany(e => e.UserAddress)
                .WithRequired(e => e.Address_)
                .HasForeignKey(e => e.id_address);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cuisine>()
                .HasMany(e => e.Restaurant)
                .WithRequired(e => e.Cuisine)
                .HasForeignKey(e => e.cuisine_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.total_price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.MenuItem)
                .WithRequired(e => e.Menu)
                .HasForeignKey(e => e.id_Menu);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.UserFavourite)
                .WithOptional(e => e.Menu)
                .HasForeignKey(e => e.id_menu);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.UserRating)
                .WithOptional(e => e.Menu)
                .HasForeignKey(e => e.id_menu);

            modelBuilder.Entity<Order_>()
                .Property(e => e.total_price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order_>()
                .HasMany(e => e.OrderItem)
                .WithRequired(e => e.Order_)
                .HasForeignKey(e => e.id_order);

            modelBuilder.Entity<OrderState>()
                .HasMany(e => e.Order_)
                .WithRequired(e => e.OrderState)
                .HasForeignKey(e => e.id_state);

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_weight)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.MenuItem)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.id_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderItem)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.id_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.UserFavourite)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.id_product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.UserRating)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.id_product);

            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Menu)
                .WithRequired(e => e.Restaurant)
                .HasForeignKey(e => e.id_restaurant);

            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Restaurant)
                .HasForeignKey(e => e.id_restaurant);

            modelBuilder.Entity<Role_>()
                .HasMany(e => e.UserRole)
                .WithRequired(e => e.Role_)
                .HasForeignKey(e => e.id_role);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.Order_)
                .WithRequired(e => e.User_)
                .HasForeignKey(e => e.id_customer);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.PaymentCard)
                .WithRequired(e => e.User_)
                .HasForeignKey(e => e.id_user);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.Report)
                .WithOptional(e => e.User_)
                .HasForeignKey(e => e.id_admin)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User_>()
                .HasMany(e => e.Restaurant)
                .WithRequired(e => e.User_)
                .HasForeignKey(e => e.id_seller);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.UserAddress)
                .WithRequired(e => e.User_)
                .HasForeignKey(e => e.id_user);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.UserFavourite)
                .WithRequired(e => e.User_)
                .HasForeignKey(e => e.id_user);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.UserRating)
                .WithRequired(e => e.User_)
                .HasForeignKey(e => e.id_user);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.UserRole)
                .WithRequired(e => e.User_)
                .HasForeignKey(e => e.id_user);

            modelBuilder.Entity<UserRating>()
                .Property(e => e.star)
                .HasPrecision(2, 2);
        }
    }
}
