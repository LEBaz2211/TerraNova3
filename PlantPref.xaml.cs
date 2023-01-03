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
        HitPoints = int.Parse(hitPointsEntry.Text);
        Energy = int.Parse(energyEntry.Text);
        EnergyDecayPercentage = int.Parse(energyDecayEntry.Text);
        SeedingEnergyCostPercentage = int.Parse(seedingEnergyCostEntry.Text);
        WinterSeasonTime = int.Parse(winterSeasonTimeEntry.Text);
        SpringSeasonTime = int.Parse(springSeasonTimeEntry.Text);
        RootRadius = int.Parse(rootRadiusEntry.Text);
        SeedingRadius = int.Parse(seedingRadiusEntry.Text);
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
}
