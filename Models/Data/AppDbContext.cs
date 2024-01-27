using bookstore1.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bookstore1.Models.Data
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<Book> books {  get; set; }
        public DbSet<Author> Authors { get; set; }
      
        public DbSet<Catogry>catogries  { get; set; }
        public DbSet<Cart> carts { get; set; }
       public DbSet<Custmors> Custmors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config=new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            var ConnectionString = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="admin",
                    NormalizedName="Admin",
                    ConcurrencyStamp= Guid.NewGuid().ToString(),

                },
                 new IdentityRole()
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "User",
                     NormalizedName = "User",
                     ConcurrencyStamp = Guid.NewGuid().ToString(),

                 }

                );
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
           
        }

    }
}
