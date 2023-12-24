namespace Harvesit.AdministratorServices.Infrastructure;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Harvesit.AdministratorServices.Core.Doman;

public class CropCatalogItemConfiguration : IEntityTypeConfiguration<CropCatalogItem>
{
    public void Configure(EntityTypeBuilder<CropCatalogItem> builder)
    {
        // Define table name
        builder.ToTable("CropCatalogItems");

        // Key configuration
        builder.HasKey(c => c.Id);

        // Field configurations
        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(200); // Example max length, adjust as necessary

        builder.Property(c => c.ScientificName)
               .IsRequired()
               .HasMaxLength(300); // Example max length

        builder.Property(c => c.Variety)
               .HasMaxLength(200); // Example max length, nullable

        builder.Property(c => c.Description)
               .IsRequired()
               .HasMaxLength(500); // Example max length

        // Since EF Core does not support Uri type natively, store it as a string
        builder.Property(c => c.ImageURL)
               .HasConversion(
                   uri => uri.ToString(),
                   uriString => new Uri(uriString))
               .IsRequired()
               .HasColumnName("ImageUrl")
               .HasMaxLength(500); // Example max length
    }
}
