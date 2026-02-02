using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ELKH.Models;

namespace ELKH.Data
{ 
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderStatuses)
                .WithOne(d => d.Order)
                .HasForeignKey<OrderStatus>(o => o.FkOrderId);

            modelBuilder.Entity<RegisteredUser>()
                        .HasOne(r => r.WishLists)
                        .WithOne(w => w.RegisteredUser)
                        .HasForeignKey<WishList>(w => w.FkUserId);

            modelBuilder.Entity<Order>()
                        .HasOne(o => o.Transaction)
                        .WithOne(t => t.Order)
                        .HasForeignKey<Transaction>(t => t.FkOrderId);

        }
    }

}
