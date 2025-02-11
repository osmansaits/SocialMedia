using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SocialMediaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer
                ("Server=localhost,1433;" +
                "Database=SocialMediaMainDb;" +
                "User Id =sa;" +
                "Password=asd123ASD;" +
                "Trusted_Connection=False;" +
                "TrustServerCertificate=True");
        }
        public DbSet<User> Users { get; set; }

    }
}
