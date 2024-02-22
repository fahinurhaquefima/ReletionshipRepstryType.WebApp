using AutoMapper;
using ReletionshipRepstryType.WebApp.DatabaseContext;
using ReletionshipRepstryType.WebApp.Models;
using ReletionshipRepstryType.WebApp.Services;
using ReletionshipRepstryType.WebApp.ViewModel;

namespace ReletionshipRepstryType.WebApp.RepositoryServices
{
    public class StateRepository:RepositoryService<State , StateVm>, IStateRepository
    {
        public StateRepository(IMapper mapper ,ApplicationDbContext dbContext):base(mapper ,dbContext)
        {
            
        }
    }
}
