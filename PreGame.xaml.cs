
namespace TerraNova2._0;



public partial class PreGame : ContentPage
{
    
    public PreGame()
    {
        InitializeComponent();
    }
    private void OnBackClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new MainPage(), true);
    }
    private void OnPlayClicked(object sender, EventArgs e)
    {
        Preferences.Set("PlantsNumber",(int)PlantSlider.Value);
        Preferences.Set("HerbivoresNumber", (int)HerbivoresSlider.Value);
        Preferences.Set("CarnivoresNumber", (int)CarnivoresSlider.Value);
        Application.Current.MainPage.Navigation.PushModalAsync(new TestOutput(), true);
    }
}
