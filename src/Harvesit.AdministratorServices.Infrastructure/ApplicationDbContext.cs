namespace Harvesit.AdministratorServices.Infrastructure;

using System.Reflection;
using Harvesit.AdministratorServices.Core.Doman;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    public DbSet<CropCatalogItem> CropCatalogItems => Set<CropCatalogItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
