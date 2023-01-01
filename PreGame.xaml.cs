
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
        Save();
        Application.Current.MainPage.Navigation.PushModalAsync(new MainPage(), true);
    }
    private void OnPlayClicked(object sender, EventArgs e)
    {
        Save();
        Application.Current.MainPage.Navigation.PushModalAsync(new TestOutput(), true);
    }
    private void GoToPredatorPref(object sender, EventArgs e)
    {
        Save();
        Application.Current.MainPage.Navigation.PushModalAsync(new PredatorPref(), true);
    }
    private void GoToHerbivorePref(object sender, EventArgs e)
    {
        Save();
        Application.Current.MainPage.Navigation.PushModalAsync(new HerbivorePref(), true);
    }
    private void GoToPlantPref(object sender, EventArgs e)
    {
        Save();
        Application.Current.MainPage.Navigation.PushModalAsync(new PlantPref(), true);
    }
    private void Save()
    {
        Preferences.Set("PlantsNumber", (int)PlantSlider.Value);
        Preferences.Set("HerbivoresNumber", (int)HerbivoresSlider.Value);
        Preferences.Set("CarnivoresNumber", (int)CarnivoresSlider.Value);
    }


}
