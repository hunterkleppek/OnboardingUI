using Fluxor;
using OnboardingUI.Domain.ReturnClasses;
using OnboardingUI.Store.Features.Software.Actions;

namespace OnboardingUI.Data.Services
{
    public record StateFacade
    {
        private readonly IDispatcher _dispatcher;

        public StateFacade(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void GetSoftware(List<SoftwareClass> softwareList, UserADClass user)
        {
            _dispatcher.Dispatch(new GetSoftwareAction(softwareList, user));
        }


    }
}
