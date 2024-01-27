using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Movie_rental.Entities;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Movie_rental.Data
{
    public class MovieRentalDbContext : IdentityDbContext<User>
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Store> Stores { get; set; }


        public MovieRentalDbContext(DbContextOptions<MovieRentalDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Rename Identity tables
            RenameAspTables(builder);

            //Seed roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Manager", NormalizedName = "MANAGER", Id = "12ef1baa-3601-4c1f-8873-3259bmanager" },
                new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER", Id = "3ba53cbd-20ad-4684-8709-c662customer" }
            );

            // Add unique constraints
            AddConstraint(builder);

            // Configure TPC for User, Manager, and Customer
            builder.Entity<User>().ToTable("User");
            builder.Entity<Manager>().ToTable("Manager").HasBaseType<User>();
            builder.Entity<Customer>().ToTable("Customer").HasBaseType<User>();

        }

        private void AddConstraint(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .Property(p => p.DelayCount)
                .HasDefaultValue(0);
        }

        public static void RenameAspTables(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
                //in case you chagned the TKey type
                //  entity.HasKey(key => new { key.UserId, key.RoleId });
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
                //in case you chagned the TKey type
                //  entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });       
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
                //in case you chagned the TKey type
                // entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });
            });
        }
    }
}
