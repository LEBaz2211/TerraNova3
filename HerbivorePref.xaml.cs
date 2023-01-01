namespace TerraNova3;

public partial class HerbivorePref : ContentPage
{
    public int HitPoints { get; set; }
    public int Energy { get; set; }
    public int EnergyDecayPercentage { get; set; }
    public int MatingEnergyCostPercentage { get; set; }
    public int BreedingCooldown { get; set; }
    public int GestationPeriod { get; set; }
    public int VisionRadius { get; set; }
    public int ContactRadius { get; set; }

    public HerbivorePref()
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
        MatingEnergyCostPercentage = int.Parse(matingEnergyCostEntry.Text);
        BreedingCooldown = int.Parse(breedingCooldownEntry.Text);
        GestationPeriod = int.Parse(gestationPeriodEntry.Text);
        VisionRadius = int.Parse(visionRadiusEntry.Text);
        ContactRadius = int.Parse(contactRadiusEntry.Text);
    }


    public void SavePref()
    {
        Preferences.Set("HerbivoreHitPoints", HitPoints);
        Preferences.Set("HerbivoreEnergy", Energy);
        Preferences.Set("HerbivoreEnergyDecayPercentage", EnergyDecayPercentage);
        Preferences.Set("HerbivoreMatingEnergyCostPercentage", MatingEnergyCostPercentage);
        Preferences.Set("HerbivoreBreedingCooldown", BreedingCooldown);
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
        Preferences.Remove("HerbivoreBreedingCooldown");
        Preferences.Remove("HerbivoreGestationPeriod");
        Preferences.Remove("HerbivoreVisionRadius");
        Preferences.Remove("HerbivoreContactRadius");
    }
}

