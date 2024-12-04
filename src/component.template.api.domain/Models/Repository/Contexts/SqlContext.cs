using Microsoft.EntityFrameworkCore;

namespace component.template.api.domain.Models.Repository.Contexts;

public class SqlContext : DbContext
{
    public DbSet<UserDto> Users { get; set; }
    public DbSet<ProfileDto> Profiles { get; set; }
    public DbSet<UserProfileDto> UserProfiles { get; set; }
    public DbSet<PermissionDto> Permissions { get; set; }
    public DbSet<ProfilePermissionDto> ProfilePermissions { get; set; }

    public SqlContext(DbContextOptions<SqlContext> options)
           : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseSqlServer("YourConnectionStringHere");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        base.OnModelCreating(modelBuilder);
        // Configurações adicionais, se necessário
    }
}

