using Fluxor;
using OnboardingUI.Domain.Entities;
using OnboardingUI.Store.Features.Software.Actions;

namespace OnboardingUI.Store.Features.Software.Effects;

public class GetSoftwareEffect : Effect<GetSoftwareAction>
{
    public readonly SoftwareList _stuffList;
    public GetSoftwareEffect(SoftwareList stuffList)
    {
        _stuffList = stuffList;
    }


    public override async Task HandleAsync(GetSoftwareAction action, IDispatcher dispatcher)
    {
        try
        {
            dispatcher.Dispatch(new GetSoftwareSuccessAction(_stuffList.GetSoftwareList()));

        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new GetSoftwareFailureAction(ex.Message));
        }
    }
}