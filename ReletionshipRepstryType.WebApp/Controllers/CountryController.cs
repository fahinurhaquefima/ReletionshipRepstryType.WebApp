using Microsoft.AspNetCore.Mvc;
using ReletionshipRepstryType.WebApp.RepositoryServices;
using ReletionshipRepstryType.WebApp.ViewModel;

namespace ReletionshipRepstryType.WebApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository countryRepository;

        public CountryController(ICountryRepository countryRepository) {
            this.countryRepository = countryRepository;
        }

        public async Task<ActionResult<CountryVm>> Index(CancellationToken cancellation)
        {
            return View(await countryRepository.GetAllAsync(cancellation));
        }
        [HttpGet]
        public async Task<ActionResult<CountryVm>> CreateOrEdit(long id, CancellationToken cancellation)
        {
            if (id == 0)
            {
                return View(new CountryVm());

            }
            else
            {
                return View(await countryRepository.GetByIdAsync(id, cancellation));
            }
        }
        [HttpPost]
        public async Task<ActionResult<CountryVm>> CreateOrEdit(long id, CountryVm countryVm, CancellationToken cancellation)
        {
            if (id == 0)
            {
                await countryRepository.InsertAsync(countryVm, cancellation);
                return RedirectToAction(nameof(Index));
               
            }
            else
            {
                await countryRepository.UpdateAsync(id, countryVm, cancellation);
                return RedirectToAction(nameof(Index));
            }
        }
    
        public async Task<ActionResult<CountryVm>>Delete(long id,CancellationToken cancellation)
        {
            if (id != 0)
            {
                await countryRepository.DeleteAsync(id, cancellation);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
