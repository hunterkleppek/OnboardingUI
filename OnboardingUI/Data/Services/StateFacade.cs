using Fluxor;
using OnboardingUI.Domain.ReturnClasses;
using OnboardingUI.Store.Features.Roles.Actions;
using OnboardingUI.Store.Features.Software.Actions;
using OnboardingUI.Store.Features.Teams.Actions;

namespace OnboardingUI.Data.Services
{
    public record StateFacade
    {
        private readonly IDispatcher _dispatcher;

        public StateFacade(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void GetSoftware(List<SoftwareClass> softwareList)
        {
            _dispatcher.Dispatch(new GetSoftwareAction(softwareList));
        }
        public void GetTeams(List<string> teamsList)
        {
            _dispatcher.Dispatch(new GetTeamsAction(teamsList));
        }
        public void GetRoles(List<string> rolesList)
        {
            _dispatcher.Dispatch(new GetRolesAction(rolesList));
        }


    }
}
