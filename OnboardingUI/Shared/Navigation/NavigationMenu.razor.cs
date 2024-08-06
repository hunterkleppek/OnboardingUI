using JetBrains.Annotations;

namespace OnboardingUI.Shared.Navigation;

[UsedImplicitly]
public partial class NavigationMenu
{
    private bool _open;

    private void ToggleDrawer()
    {
        _open = !_open;
    }
}