namespace Harvesit.AdministratorServices.CoreTests;

using Harvesit.AdministratorServices.Core;
using Harvesit.AdministratorServices.Core.Doman;

public class CropCatalogManagementTests
{
    private readonly CropCatalogManagement _cropCatalogManagement;

    public CropCatalogManagementTests()
    {
        _cropCatalogManagement = new CropCatalogManagement();
    }

    [Fact]
    public void AddNewCropCatalogItem_WithValidData_ShouldAddSuccessfully()
    {
        // Arrange
        var newCropItemId = Guid.NewGuid();
        var newCropItem = new CropCatalogItem(
            newCropItemId,
            "Apple",
            "Malus domestica",
            "Gala",
            "A popular variety of apple.",
            //"Late Summer to Early Autumn",
            new Uri("http://example.com/apple.jpg"));

        // Act
        _cropCatalogManagement.AddCropItem(newCropItem);

        var addedCropItem = _cropCatalogManagement.GetCropItemById(newCropItemId);

        // Assert
        addedCropItem.Should().NotBeNull();
        addedCropItem.Id.Should().Be(newCropItemId);
        addedCropItem.Name.Should().Be("Apple");
        addedCropItem.ScientificName.Should().Be("Malus domestica");
        addedCropItem.Variety.Should().Be("Gala");
        addedCropItem.Description.Should().Be("A popular variety of apple.");
        //addedCropItem.HarvestTime.Should().Be("Late Summer to Early Autumn");
        addedCropItem.ImageURL.Should().BeEquivalentTo(new Uri("http://example.com/apple.jpg"));
    }

    [Fact]
    public void AddNewCropCatalogItem_WithValidData_ShouldPassValidation()
    {
        // Arrange
        var validCropItemId = Guid.NewGuid();
        var validCropItem = new CropCatalogItem(
            validCropItemId,
            "Apple",
            "Malus domestica",
            "Gala",
            "A popular variety of apple.",
            //"Late Summer to Early Autumn",
            new Uri("http://example.com/apple.jpg"));

        // Act
        Action act = () => _cropCatalogManagement.AddCropItem(validCropItem);

        // Assert
        act.Should().NotThrow<Exception>("because the data for the new crop item is valid");
    }
}
