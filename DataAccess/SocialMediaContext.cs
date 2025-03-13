using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class SocialMediaContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("MsSql");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {  
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.user)
                .WithMany(u => u.comments)
                .HasForeignKey(c => c.userId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasQueryFilter(c => !c.isDeleted);
                


        }
        public DbSet<Auth> Auths { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}