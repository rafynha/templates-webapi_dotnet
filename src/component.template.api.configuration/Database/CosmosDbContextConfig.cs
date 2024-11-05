using Microsoft.EntityFrameworkCore;

namespace component.template.api.configuration.Database
{
    public class CosmosDbContextConfig : DbContext
    {
        // public DbSet<UserRepository> User { get; set; }

        public CosmosDbContextConfig(DbContextOptions<CosmosDbContextConfig> options) : base(options)
        {
        }

        public CosmosDbContextConfig()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<UserRepository>().HasNoDiscriminator().ToContainer("User").Property(p => p.Id).ToJsonProperty("id");
        }
    }
}