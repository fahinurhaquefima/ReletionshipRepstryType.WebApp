using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReletionshipRepstryType.WebApp.Models;

namespace ReletionshipRepstryType.WebApp.ModelConfiguration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);
        builder.HasData(new Country
        {
            Id = 1,
            Name = "Bangladesh",
        });
    }
}
