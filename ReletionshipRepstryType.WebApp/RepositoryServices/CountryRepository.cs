using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReletionshipRepstryType.WebApp.DatabaseContext;
using ReletionshipRepstryType.WebApp.Models;
using ReletionshipRepstryType.WebApp.Services;
using ReletionshipRepstryType.WebApp.ViewModel;

namespace ReletionshipRepstryType.WebApp.RepositoryServices;

public class CountryRepository:RepositoryService<Country , CountryVm>, ICountryRepository
{
    public CountryRepository(IMapper mapper , ApplicationDbContext dbContext):base(mapper , dbContext)
    {
        
    }

    public IEnumerable<SelectListItem> Dropdown()
    {
       return DbSet.Select(x=> new SelectListItem { Text=x.Name,Value=x.Id.ToString() });
    }
}
