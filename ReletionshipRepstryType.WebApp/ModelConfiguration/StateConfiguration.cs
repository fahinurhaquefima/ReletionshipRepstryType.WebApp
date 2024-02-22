using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReletionshipRepstryType.WebApp.Models;

namespace ReletionshipRepstryType.WebApp.ModelConfiguration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable(nameof(State));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);
        builder.HasOne(x=>x.Country).WithMany(x=>x.State).HasForeignKey(x=>x.CountryID).OnDelete(DeleteBehavior.Restrict);
    }
}
