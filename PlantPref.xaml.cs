namespace TerraNova3;

public partial class PlantPref : ContentPage
{
    public int HitPoints { get; set; }
    public int Energy { get; set; }
    public int EnergyDecayPercentage { get; set; }
    public int SeedingEnergyCostPercentage { get; set; }
    public int SeedingCooldown { get; set; }

    public int RootRadius { get; set; }
    public int SeedingRadius { get; set; }

    public PlantPref()
    {
        InitializeComponent();


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
    }
    public void Parse()
    {
        HitPoints = int.Parse(hitPointsEntry.Text);
        Energy = int.Parse(energyEntry.Text);
        EnergyDecayPercentage = int.Parse(energyDecayEntry.Text);
        SeedingEnergyCostPercentage = int.Parse(seedingEnergyCostEntry.Text);
        SeedingCooldown = int.Parse(seedingCooldownEntry.Text);

        RootRadius = int.Parse(rootRadiusEntry.Text);
        SeedingRadius = int.Parse(seedingRadiusEntry.Text);
    }


    public void SavePref()
    {
        Preferences.Set("PlantHitPoints", HitPoints);
        Preferences.Set("PlantEnergy", Energy);
        Preferences.Set("PlantEnergyDecayPercentage", EnergyDecayPercentage);
        Preferences.Set("PlantSeedingEnergyCostPercentage", SeedingEnergyCostPercentage);
        Preferences.Set("PlantSeedingCooldown", SeedingCooldown);

        Preferences.Set("PlantRootRadius", RootRadius);
        Preferences.Set("PlantSeedingRadius", SeedingRadius);
    }
    public static void ClearPref()
    {
        Preferences.Remove("PlantHitPoints");
        Preferences.Remove("PlantEnergy");
        Preferences.Remove("PlantEnergyDecayPercentage");
        Preferences.Remove("PlantSeedingEnergyCostPercentage");
        Preferences.Remove("PlantSeedingCooldown");

        Preferences.Remove("PlantRootRadius");
        Preferences.Remove("PlantSeedingRadius");
    }
}
