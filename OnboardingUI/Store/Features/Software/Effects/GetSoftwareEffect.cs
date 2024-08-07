﻿using Fluxor;
using JetBrains.Annotations;
using OnboardingUI.Domain.Entities;
using OnboardingUI.Store.Features.Software.Actions;

namespace OnboardingUI.Store.Features.Software.Effects;

[UsedImplicitly]
public class GetSoftwareEffect(EnterpriseSoftwareList stuffList) : Effect<GetSoftwareAction>
{

    public override Task HandleAsync(GetSoftwareAction action, IDispatcher dispatcher)
    {
        try
        {
            dispatcher.Dispatch(new GetSoftwareSuccessAction(stuffList.GetSoftwareList()));

        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new GetSoftwareFailureAction(ex.Message));
        }

        return Task.CompletedTask;
    }
}