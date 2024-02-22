using Microsoft.AspNetCore.Mvc.Rendering;
using ReletionshipRepstryType.WebApp.Models;
using ReletionshipRepstryType.WebApp.Services;
using ReletionshipRepstryType.WebApp.ViewModel;

namespace ReletionshipRepstryType.WebApp.RepositoryServices;

public interface ICountryRepository:IRepositoryService<Country , CountryVm>
{
   IEnumerable<SelectListItem> Dropdown();
}
