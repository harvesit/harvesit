namespace Harvesit.AdministratorServices.Core.Infrastructure.Database;

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Harvesit.AdministratorServices.Core.Doman;
using Microsoft.EntityFrameworkCore;

public interface IApplicationDbContext
{
    DbSet<CropCatalogItem> CropCatalogItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<CropCatalogItem> CropCatalogItems => Set<CropCatalogItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
