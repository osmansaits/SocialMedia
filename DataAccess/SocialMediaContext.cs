using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class SocialMediaContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options, IConfiguration configuration):base(options)
        {
            _configuration =configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("MsSql");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<User> Users { get; set; }

    }
}