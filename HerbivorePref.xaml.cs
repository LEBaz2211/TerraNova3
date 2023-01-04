namespace TerraNova3;

public partial class HerbivorePref : ContentPage
{
    public int HitPoints { get; set; }
    public int Energy { get; set; }
    public int EnergyDecayPercentage { get; set; }
    public int MatingEnergyCostPercentage { get; set; }
    public int LaborEnergyCostPercentage { get; set; }
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
        HitPoints = Math.Abs(int.Parse(hitPointsEntry.Text));
        Energy = Math.Abs(int.Parse(energyEntry.Text));
        EnergyDecayPercentage = Math.Abs(int.Parse(energyDecayEntry.Text));
        MatingEnergyCostPercentage = Math.Abs(int.Parse(matingEnergyCostEntry.Text));
        LaborEnergyCostPercentage = Math.Abs(int.Parse(laborEnergyCostEntry.Text));
        GestationPeriod = Math.Abs(int.Parse(gestationPeriodEntry.Text));
        VisionRadius = Math.Abs(int.Parse(visionRadiusEntry.Text));
        ContactRadius = Math.Abs(int.Parse(contactRadiusEntry.Text));
    }

    public void SetPref()
    {
        hitPointsEntry.Text = $"{Preferences.Get("HerbivoreHitPoints", 100)}";
        energyEntry.Text = $"{Preferences.Get("HerbivoreEnergy", 1000)}";
        energyDecayEntry.Text = $"{Preferences.Get("HerbivoreEnergyDecayPercentage", 1)}";
        matingEnergyCostEntry.Text = $"{Preferences.Get("HerbivoreSeedingEnergyCostPercentage", 33)}";
        laborEnergyCostEntry.Text = $"{Preferences.Get("HerbivoreLaborEnergyCostPercentage", 50)}";
        gestationPeriodEntry.Text = $"{Preferences.Get("HerbivoreGestationPeriod", 30)}";
        visionRadiusEntry.Text = $"{Preferences.Get("HerbivoreVisionRadius", 10)}";
        contactRadiusEntry.Text = $"{Preferences.Get("HerbivoreContactRadius", 1)}";

    }

    public void SavePref()
    {
        Preferences.Set("HerbivoreHitPoints", HitPoints);
        Preferences.Set("HerbivoreEnergy", Energy);
        Preferences.Set("HerbivoreEnergyDecayPercentage", EnergyDecayPercentage);
        Preferences.Set("HerbivoreMatingEnergyCostPercentage", MatingEnergyCostPercentage);
        Preferences.Set("HerbivoreLaborEnergyCostPercentage", LaborEnergyCostPercentage);
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
        Preferences.Remove("HerbivoreLaborEnergyCostPercentage");
        Preferences.Remove("HerbivoreGestationPeriod");
        Preferences.Remove("HerbivoreVisionRadius");
        Preferences.Remove("HerbivoreContactRadius");
    }
}

