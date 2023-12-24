using Harvesit.AdministratorServices.Api.Endpoints;
using Harvesit.AdministratorServices.Core.Application;
using Harvesit.AdministratorServices.Core.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCropCatalogEndpoints();

app.Run();