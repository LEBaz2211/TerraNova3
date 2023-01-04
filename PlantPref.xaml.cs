namespace TerraNova3;

public partial class PlantPref : ContentPage
{
    public int HitPoints { get; set; }
    public int Energy { get; set; }
    public int EnergyDecayPercentage { get; set; }
    public int SeedingEnergyCostPercentage { get; set; }
    public int WinterSeasonTime { get; set; }
    public int SpringSeasonTime { get; set; }
    public int RootRadius { get; set; }
    public int SeedingRadius { get; set; }

    public PlantPref()
    {
        InitializeComponent();
        SetPref();


    }
    private void OnBackClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new PreGame(), true);
    }
    private void OnSaveClicked(object sender, EventArgs e)
    {
        Parse();
        SavePref();
    }
    private void OnResetClicked(object sender, EventArgs e)
    {
        ClearPref();
        SetPref();
    }
    public void Parse()
    {
        HitPoints = Math.Abs(int.Parse(hitPointsEntry.Text));
        Energy = Math.Abs(int.Parse(energyEntry.Text));
        EnergyDecayPercentage = Math.Abs(int.Parse(energyDecayEntry.Text));
        SeedingEnergyCostPercentage = Math.Abs(int.Parse(seedingEnergyCostEntry.Text));
        WinterSeasonTime = Math.Abs(int.Parse(winterSeasonTimeEntry.Text));
        SpringSeasonTime = Math.Abs(int.Parse(springSeasonTimeEntry.Text));
        RootRadius = Math.Abs(int.Parse(rootRadiusEntry.Text));
        SeedingRadius = Math.Abs(int.Parse(seedingRadiusEntry.Text));
    }

    public void SetPref()
    {
        hitPointsEntry.Text = $"{Preferences.Get("PlantHitPoints", 2)}";
        energyEntry.Text = $"{Preferences.Get("PlantEnergy", 1000)}";
        energyDecayEntry.Text = $"{Preferences.Get("PlantEnergyDecayPercentage", 1)}";
        seedingEnergyCostEntry.Text = $"{Preferences.Get("PlantSeedingEnergyCostPercentage", 50)}";
        winterSeasonTimeEntry.Text = $"{Preferences.Get("PlantWinterSeasonTime", 20)}";
        springSeasonTimeEntry.Text = $"{Preferences.Get("PlantSpringSeasonTime", 20)}";
        rootRadiusEntry.Text = $"{Preferences.Get("PlantRootRadius", 4)}";
        seedingRadiusEntry.Text = $"{Preferences.Get("PlantSeedingRadius", 8)}";

    }


    public void SavePref()
    {
        Preferences.Set("PlantHitPoints", HitPoints);
        Preferences.Set("PlantEnergy", Energy);
        Preferences.Set("PlantEnergyDecayPercentage", EnergyDecayPercentage);
        Preferences.Set("PlantSeedingEnergyCostPercentage", SeedingEnergyCostPercentage);
        Preferences.Set("PlantWinterSeasonTime", WinterSeasonTime);
        Preferences.Set("PlantSpringSeasonTime", SpringSeasonTime);
        Preferences.Set("PlantRootRadius", RootRadius);
        Preferences.Set("PlantSeedingRadius", SeedingRadius);
        foolCheck();
    }
    public static void ClearPref()
    {
        Preferences.Remove("PlantHitPoints");
        Preferences.Remove("PlantEnergy");
        Preferences.Remove("PlantEnergyDecayPercentage");
        Preferences.Remove("PlantSeedingEnergyCostPercentage");
        Preferences.Remove("PlantWinterSeasonTime");
        Preferences.Remove("PlantSpringSeasonTime");
        Preferences.Remove("PlantRootRadius");
        Preferences.Remove("PlantSeedingRadius");
    }
    public void foolCheck()
    {
        if (EnergyDecayPercentage > 100 || SeedingEnergyCostPercentage > 100)
        {
            BrowserOpen_Clicked();
        }
    }
    private async void BrowserOpen_Clicked()
    {
        try
        {
            Uri uri = new Uri("https://www.youtube.com/watch?v=y2weNM4JtME");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {

        }
    }
}
