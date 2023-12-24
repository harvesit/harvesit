namespace Harvesit.AdministratorServices.Contract;

public record CropCatalogItemContract(Guid Id, string Name, string ScientificName, string Variety, string Description, string ImageUrl);
