using Harvesit.AdministratorServices.Core.Application;
using Harvesit.AdministratorServices.Core.Doman;
using Harvesit.AdministratorServices.Core.Infrastructure.Database.Repositories;

namespace Harvesit.AdministratorServices.CoreTests.Application;

public class CropCatalogManagementTests : IDisposable
{
    private readonly ICropCatalogItemRepository _mockRepository;
    private readonly CropCatalogManagement _cropCatalogManagement;

    public CropCatalogManagementTests()
    {
        // Create mock repository
        _mockRepository = Substitute.For<ICropCatalogItemRepository>();

        // Create CropCatalogManagement with the mock repository
        _cropCatalogManagement = new CropCatalogManagement(_mockRepository);
    }

    [Fact]
    public async Task AddNewCropCatalogItem_WithValidData_ShouldAddSuccessfully()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var newCropItem = new CropCatalogItem(
            Guid.NewGuid(), "Wheat", "Triticum aestivum", "Variety A",
            "Agricultural crop used for food production.", new Uri("https://example.com/wheat.jpg"));

        // Set up the behavior of the mock repository
        _mockRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult<CropCatalogItem>(null)); // Simulate no existing item
        _mockRepository.AddAsync(Arg.Any<CropCatalogItem>()).Returns(Task.CompletedTask);

        // Act
        await _cropCatalogManagement.AddCropItem(newCropItem, cancellationToken);

        // Assert
        await _mockRepository.Received(1).AddAsync(Arg.Is<CropCatalogItem>(item =>
            item.Id == newCropItem.Id &&
            item.Name == newCropItem.Name
            // Add more property checks here
        ));
    }

    [Fact]
    public async Task AddNewCropCatalogItem_WithValidData_ShouldPassValidation()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var newCropItem = new CropCatalogItem(
            Guid.NewGuid(), "Corn", "Zea mays", null,
            "Agricultural crop used for various purposes.", new Uri("https://example.com/corn.jpg"));

        // Set up the behavior of the mock repository
        _mockRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult<CropCatalogItem>(null)); // Simulate no existing item
        _mockRepository.AddAsync(Arg.Any<CropCatalogItem>()).Returns(Task.CompletedTask);

        // Act
        Func<Task> action = async () => await _cropCatalogManagement.AddCropItem(newCropItem, cancellationToken);

        // Assert
        await action.Should().NotThrowAsync<Exception>(); // Ensure no exceptions are thrown
    }

    public void Dispose()
    {
        // Cleanup resources if needed
    }
}
