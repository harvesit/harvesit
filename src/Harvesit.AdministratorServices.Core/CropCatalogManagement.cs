
namespace Harvesit.AdministratorServices.Core
{
    public class CropCatalogManagement
    {
        private readonly Dictionary<Guid, CropItem> _catalog;

        public CropCatalogManagement()
        {
            _catalog = new Dictionary<Guid, CropItem>();
        }

        public void AddCropItem(CropItem newCropItem)
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

        public CropItem GetCropItemById(Guid cropItemId)
        {
            if (!_catalog.TryGetValue(cropItemId, out CropItem cropItem))
            {
                throw new KeyNotFoundException($"No crop item found with the ID {cropItemId}.");
            }

            return cropItem;
        }
    }
}
