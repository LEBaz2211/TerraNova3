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
        EnergyDecayPercentage = Convert.ToInt32(Energy * 29 / 100);
        //EnergyDecayPercentage = int.Parse(energyDecayEntry.Text);
        SeedingEnergyCostPercentage = int.Parse(seedingEnergyCostEntry.Text);
        SeedingCooldown = int.Parse(seedingCooldownEntry.Text);
        RootRadius = int.Parse(rootRadiusEntry.Text);
        SeedingRadius = int.Parse(seedingRadiusEntry.Text);
    }

    public void SetPref()
    {
        hitPointsEntry.Text = $"{Preferences.Get("PlantHitPoints", 100)}";
        energyEntry.Text = $"{Preferences.Get("PlantEnergy", 1000)}";
        energyDecayEntry.Text = $"{Preferences.Get("PlantEnergyDecayPercentage", 1)}";
        seedingEnergyCostEntry.Text = $"{Preferences.Get("PlantSeedingEnergyCostPercentage", 50)}";
        seedingCooldownEntry.Text = $"{Preferences.Get("PlantSeedingCooldown", 50)}";
        rootRadiusEntry.Text = $"{Preferences.Get("PlantRootRadius", 30)}";
        seedingRadiusEntry.Text = $"{Preferences.Get("PlantSeedingRadius", 1)}";

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
