using MudBlazor;

namespace OnboardingUI.Shared;

public partial class MainLayout
{
    private readonly MudTheme _securaTheme = new()
    {
        Palette = new PaletteLight
        {
            Primary = "#f2a900",
            Secondary = "#f2f2f2",
            Tertiary = "#3f4444",
            Success = "#31b700",
            Warning = "#f0ad4e",
            Info = "#3e87cb",
            Error = "#dd2222",
            Background = "#f2f2f2",
            DrawerBackground = "#f2f2f2",
            AppbarBackground = "#ffffff",
            AppbarText = "#3f4444"
        },
        Typography = new Typography
        {
            H3 = new H3
            {
                FontFamily = new[] { "Open Sans", "sans-serif" },
                FontWeight = 400
            },
            Body2 = new Body2
            {
                FontFamily = new[] { "Open Sans", "sans-serif" },
                FontWeight = 400
            },
            Default = new Default
            {
                FontFamily = new[] { "Open Sans", "sans-serif" },
                FontWeight = 600,
                FontSize = "14px"
            }
        }
    };
}