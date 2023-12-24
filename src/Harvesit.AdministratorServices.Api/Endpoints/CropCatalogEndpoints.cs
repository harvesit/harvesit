namespace Harvesit.AdministratorServices.Api.Endpoints;

using Harvesit.AdministratorServices.Api.Mapper;
using Harvesit.AdministratorServices.Contract;
using Harvesit.AdministratorServices.Core.Application;

public static class CropCatalogEndpoints
{
    public static void MapCropCatalogEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/cropcatalogitem/add", async (CropCatalogItemContract cropItem, ICropCatalogManagement catalogManagement) =>
            await EndpointBase.ExecuteWithExceptionHandling(async () =>
            {
                if (cropItem == null)
                    throw new ArgumentNullException(nameof(cropItem), "Crop item is required.");

                await catalogManagement.AddCropItem(cropItem.ToEntity(), CancellationToken.None);
                return Results.Ok("Crop item added successfully.");
            }));

        app.MapGet("/api/cropcatalogitem/{id}", async (Guid id, ICropCatalogManagement catalogManagement) =>
            await EndpointBase.ExecuteWithExceptionHandling(async () =>
            {
                var cropItem = await catalogManagement.GetCropItemByIdAsync(id);
                if (cropItem == null)
                    return Results.NotFound("Crop item not found.");

                return Results.Ok(cropItem.ToContract());
            }));
    }
}