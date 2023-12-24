namespace Harvesit.AdministratorServices.Core.Infrastructure.Database.Repositories;

using System.Threading.Tasks;
using Harvesit.AdministratorServices.Core.Doman;
using Microsoft.EntityFrameworkCore;

public interface ICropCatalogItemRepository
{
    Task<CropCatalogItem> GetByIdAsync(Guid id);
    Task<IEnumerable<CropCatalogItem>> GetAllAsync();
    Task AddAsync(CropCatalogItem item);
    Task UpdateAsync(CropCatalogItem item);
    Task DeleteAsync(Guid id);
}

public class CropCatalogItemRepository : ICropCatalogItemRepository
{
    private readonly IApplicationDbContext _context;

    public CropCatalogItemRepository(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddAsync(CropCatalogItem item)
    {
        await _context.CropCatalogItems.AddAsync(item);
        await _context.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<IEnumerable<CropCatalogItem>> GetAllAsync()
    {
        return await _context.CropCatalogItems.ToListAsync();
    }

    public async Task<CropCatalogItem> GetByIdAsync(Guid id)
    {
        return await _context.CropCatalogItems.FindAsync(id);
    }

    public async Task UpdateAsync(CropCatalogItem item)
    {
        _context.CropCatalogItems.Update(item);
        await _context.SaveChangesAsync(CancellationToken.None);
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = await _context.CropCatalogItems.FindAsync(id);
        if (item != null)
        {
            _context.CropCatalogItems.Remove(item);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
