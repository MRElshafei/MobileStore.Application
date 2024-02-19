using Domain;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base class method
            base.OnModelCreating(modelBuilder);

            // Seed roles
            modelBuilder.Entity<Role>().HasData(
                new Role { ID = 1, RoleName = "Admin" },
                new Role { ID = 2, RoleName = "User" }
            );

            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "OPPO" },
                new Category { ID = 2, Name = "Samsung" }
            );

            // Seed items
            modelBuilder.Entity<Item>().HasData(
                new Item { ID = 1, Name = "Oppo Reno 10", Price = 1000, Description = "Description of Oppo Reno 10", CategoryId = 1, Quantity = 10 },
                new Item { ID = 2, Name = "Oppo Reno 6", Price = 800, Description = "Description of Oppo Reno 6", CategoryId = 1, Quantity = 5 },
                new Item { ID = 3, Name = "Samsung S24", Price = 1200, Description = "Description of Samsung S24", CategoryId = 2, Quantity = 8 },
                new Item { ID = 4, Name = "Samsung A54", Price = 900, Description = "Description of Samsung A54", CategoryId = 2, Quantity = 12 }
            );

            // Seed a user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    //Password = "12345678",
                    Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                    Email = "admin@example.com",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St"
                }
            );

            // Seed role assignment
            modelBuilder.Entity<RoleAssignment>().HasData(
                new RoleAssignment { ID = 1, RoleId = 1, UserId = 1 }
            );
        }
    }
}
