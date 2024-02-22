using Microsoft.AspNetCore.Mvc;
using ReletionshipRepstryType.WebApp.RepositoryServices;
using ReletionshipRepstryType.WebApp.ViewModel;

namespace ReletionshipRepstryType.WebApp.Controllers
{
    public class StateController(IStateRepository stateRepository,ICountryRepository countryRepository ) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<StateVm>> Index()
        {
            var data = await stateRepository.GetAllAsync(x => x.Country);
            return View(data);
        }
        [HttpGet]
        public async Task<ActionResult<StateVm>> CreateOrEdit(long id, CancellationToken cancellation)
        {
            ViewData["CountryId"] = countryRepository.Dropdown();
            if (id == 0)
            {
                return View(new StateVm());

            }
            else
            {
                return View(await stateRepository.GetByIdAsync(id, cancellation));
            }
        }
        [HttpPost]
        public async Task<ActionResult<StateVm>> CreateOrEdit(long id, StateVm StateVm, CancellationToken cancellation)
        {
            if (id == 0)
            {
                await stateRepository.InsertAsync(StateVm, cancellation);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                await stateRepository.UpdateAsync(id, StateVm, cancellation);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<ActionResult<StateVm>> Delete(long id, CancellationToken cancellation)
        {
            if (id != 0)
            {
                await stateRepository.DeleteAsync(id, cancellation);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

