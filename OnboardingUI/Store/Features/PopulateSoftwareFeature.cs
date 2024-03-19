using Fluxor;
using JetBrains.Annotations;
using OnboardingUI.Store.State;

namespace OnboardingUI.Store.Features;

[UsedImplicitly]
public class PopulateSoftwareFeature : Feature<PopulateSoftwareState>
{
    public override string GetName() => "Softwares";
    protected override PopulateSoftwareState GetInitialState() =>
        new (false, null);
}