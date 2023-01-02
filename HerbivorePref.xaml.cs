namespace TerraNova3;

public partial class HerbivorePref : ContentPage
{
    public int HitPoints { get; set; }
    public int Energy { get; set; }
    public int EnergyDecayPercentage { get; set; }
    public int MatingEnergyCostPercentage { get; set; }

    public int GestationPeriod { get; set; }
    public int VisionRadius { get; set; }
    public int ContactRadius { get; set; }

    public HerbivorePref()
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
        MatingEnergyCostPercentage = int.Parse(matingEnergyCostEntry.Text);
        GestationPeriod = int.Parse(gestationPeriodEntry.Text);
        VisionRadius = int.Parse(visionRadiusEntry.Text);
        ContactRadius = int.Parse(contactRadiusEntry.Text);
    }

    public void SetPref()
    {
        hitPointsEntry.Text = $"{Preferences.Get("PlantHitPoints", 100)}";
        energyEntry.Text = $"{Preferences.Get("PlantEnergy", 1000)}";
        energyDecayEntry.Text = $"{Preferences.Get("PlantEnergyDecayPercentage", 1)}";
        matingEnergyCostEntry.Text = $"{Preferences.Get("PlantSeedingEnergyCostPercentage", 50)}";
        gestationPeriodEntry.Text = $"{Preferences.Get("PlantSeedingCooldown", 50)}";
        visionRadiusEntry.Text = $"{Preferences.Get("PlantRootRadius", 30)}";
        contactRadiusEntry.Text = $"{Preferences.Get("PlantSeedingRadius", 1)}";
    }

    public void SavePref()
    {
        Preferences.Set("HerbivoreHitPoints", HitPoints);
        Preferences.Set("HerbivoreEnergy", Energy);
        Preferences.Set("HerbivoreEnergyDecayPercentage", EnergyDecayPercentage);
        Preferences.Set("HerbivoreMatingEnergyCostPercentage", MatingEnergyCostPercentage);
        Preferences.Set("HerbivoreGestationPeriod", GestationPeriod);
        Preferences.Set("HerbivoreVisionRadius", VisionRadius);
        Preferences.Set("HerbivoreContactRadius", ContactRadius);
    }
    public static void ClearPref()
    {
        Preferences.Remove("HerbivoreHitPoints");
        Preferences.Remove("HerbivoreEnergy");
        Preferences.Remove("HerbivoreEnergyDecayPercentage");
        Preferences.Remove("HerbivoreMatingEnergyCostPercentage");
        Preferences.Remove("HerbivoreGestationPeriod");
        Preferences.Remove("HerbivoreVisionRadius");
        Preferences.Remove("HerbivoreContactRadius");
    }
}

