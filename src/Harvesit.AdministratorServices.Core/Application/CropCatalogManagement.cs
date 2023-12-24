namespace Harvesit.AdministratorServices.Core.Application;

using Harvesit.AdministratorServices.Core.Doman;
using Harvesit.AdministratorServices.Core.Infrastructure.Database.Repositories;

public class CropCatalogManagement
{
    private readonly ICropCatalogItemRepository _cropCatalogItemRepository;

    public CropCatalogManagement(ICropCatalogItemRepository cropCatalogItemRepository)
    {
        _cropCatalogItemRepository = cropCatalogItemRepository ?? throw new ArgumentNullException(nameof(cropCatalogItemRepository));
    }

    public async Task AddCropItem(CropCatalogItem newCropItem, CancellationToken cancellationToken)
    {
        if (newCropItem == null) throw new ArgumentNullException(nameof(newCropItem), "New crop item cannot be null.");

        var existingItem = await _cropCatalogItemRepository.GetByIdAsync(newCropItem.Id);
        if (existingItem != null) throw new ArgumentException($"A crop item with the ID {newCropItem.Id} already exists.", nameof(newCropItem));

        await _cropCatalogItemRepository.AddAsync(newCropItem);
    }

    public async Task<CropCatalogItem> GetCropItemByIdAsync(Guid cropItemId)
    {
        var cropItem = await _cropCatalogItemRepository.GetByIdAsync(cropItemId);
        if (cropItem == null) throw new KeyNotFoundException($"No crop item found with the ID {cropItemId}.");

        return cropItem;
    }
}


