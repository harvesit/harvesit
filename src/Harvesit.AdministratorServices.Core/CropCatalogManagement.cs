namespace Harvesit.AdministratorServices.Core;

using Harvesit.AdministratorServices.Core.Doman;

public class CropCatalogManagement
{
    private readonly Dictionary<Guid, CropCatalogItem> _catalog;

    public CropCatalogManagement()
    {
        _catalog = new Dictionary<Guid, CropCatalogItem>();
    }

    public void AddCropItem(CropCatalogItem newCropItem)
    {
        if (newCropItem == null)
        {
            throw new ArgumentNullException(nameof(newCropItem), "New crop item cannot be null.");
        }

        if (_catalog.ContainsKey(newCropItem.Id))
        {
            throw new ArgumentException($"A crop item with the ID {newCropItem.Id} already exists.", nameof(newCropItem));
        }

        _catalog[newCropItem.Id] = newCropItem;
    }

    public CropCatalogItem GetCropItemById(Guid cropItemId)
    {
        if (!_catalog.TryGetValue(cropItemId, out CropCatalogItem cropItem))
        {
            throw new KeyNotFoundException($"No crop item found with the ID {cropItemId}.");
        }

        return cropItem;
    }
}
