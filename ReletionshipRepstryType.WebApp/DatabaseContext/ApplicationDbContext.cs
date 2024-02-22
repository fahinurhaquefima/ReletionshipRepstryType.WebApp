using Microsoft.EntityFrameworkCore;
using ReletionshipRepstryType.WebApp.ViewModel;

namespace ReletionshipRepstryType.WebApp.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>dbContext):base(dbContext)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

public DbSet<ReletionshipRepstryType.WebApp.ViewModel.CountryVm> CountryVm { get; set; } = default!;
}
