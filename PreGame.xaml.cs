
namespace TerraNova3;



public partial class PreGame : ContentPage
{
    
    public PreGame()
    {
        InitializeComponent();
        PlantSlider.Value = (int)Preferences.Get("PlantsNumber", 10);
        HerbivoresSlider.Value = (int)Preferences.Get("HerbivoresNumber", 10);
        CarnivoresSlider.Value = (int)Preferences.Get("CarnivoresNumber", 10);
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
