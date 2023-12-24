using Harvesit.AdministratorServices.Contract;
using Harvesit.AdministratorServices.Core.Doman;

namespace Harvesit.AdministratorServices.Api.Mapper;

public static class CropCatalogItemMapper
{
    public static CropCatalogItem ToEntity(this CropCatalogItemContract contract)
    {
        return new CropCatalogItem(
            contract.Id,
            contract.Name,
            contract.ScientificName,
            contract.Variety,
            contract.Description,
            new Uri(contract.ImageUrl));
    }

    public static CropCatalogItemContract ToContract(this CropCatalogItem entity)
    {
        return new CropCatalogItemContract(
            entity.Id,
            entity.Name,
            entity.ScientificName,
            entity.Variety,
            entity.Description,
            entity.ImageURL.ToString());
    }
}
