namespace Harvesit.AdministratorServices.CoreTests.Application;

using Harvesit.AdministratorServices.Core.Application;
using Harvesit.AdministratorServices.Core.Doman;
using Harvesit.AdministratorServices.Core.Infrastructure.Database.Repositories;

public class CropCatalogManagementTests
{
    private readonly ICropCatalogItemRepository _repository;
    private readonly CropCatalogManagement _catalogManagement;

    public CropCatalogManagementTests()
    {
        _repository = Substitute.For<ICropCatalogItemRepository>();
        _catalogManagement = new CropCatalogManagement(_repository);
    }

    [Fact]
    public async Task AddNewCropCatalogItem_WithValidData_ShouldAddSuccessfully()
    {
        // Arrange
        var newCropItem = new CropCatalogItem(Guid.NewGuid(), "Apple", "Malus domestica", "Fuji", "A sweet apple", new Uri("http://example.com/apple.jpg"));
        _repository.GetByIdAsync(newCropItem.Id).Returns(Task.FromResult<CropCatalogItem>(null));

        // Act
        Func<Task> act = async () => await _catalogManagement.AddCropItem(newCropItem, CancellationToken.None);

        // Assert
        await act.Should().NotThrowAsync();
        await _repository.Received(1).AddAsync(Arg.Is<CropCatalogItem>(item => item.Id == newCropItem.Id));
    }

    [Fact]
    public async Task AddNewCropCatalogItem_WithValidData_ShouldPassValidation()
    {
        // Arrange
        var newCropItem = new CropCatalogItem(Guid.NewGuid(), "Orange", "Citrus sinensis", "Valencia", "A juicy orange", new Uri("http://example.com/orange.jpg"));
        _repository.GetByIdAsync(newCropItem.Id).Returns(Task.FromResult<CropCatalogItem>(null));

        // Act
        await _catalogManagement.AddCropItem(newCropItem, CancellationToken.None);

        // Assert
        newCropItem.Id.Should().NotBe(Guid.Empty);
        newCropItem.Name.Should().NotBeNullOrEmpty();
        newCropItem.ScientificName.Should().NotBeNullOrEmpty();
        newCropItem.Variety.Should().NotBeNullOrEmpty();
        newCropItem.Description.Should().NotBeNullOrEmpty();
        newCropItem.ImageURL.Should().NotBeNull();
        newCropItem.ImageURL.IsAbsoluteUri.Should().BeTrue();
    }
}

