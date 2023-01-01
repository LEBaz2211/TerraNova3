namespace TerraNova3;

public partial class PredatorPref : ContentPage
{
    public int HitPoints { get; set; }
    public int Energy { get; set; }
    public int EnergyDecayPercentage { get; set; }
    public int MatingEnergyCostPercentage { get; set; }
    public int BreedingCooldown { get; set; }
    public int GestationPeriod { get; set; }
    public int AttackDamage { get; set; }
    public int VisionRadius { get; set; }
    public int ContactRadius { get; set; }

    public PredatorPref()
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
        AttackDamage = int.Parse(attackDamageEntry.Text);
        VisionRadius = int.Parse(visionRadiusEntry.Text);
        ContactRadius = int.Parse(contactRadiusEntry.Text);
    }


    public  void SavePref()
    {
        Preferences.Set("PredatorHitPoints", HitPoints);
        Preferences.Set("PredatorEnergy", Energy);
        Preferences.Set("PredatorEnergyDecayPercentage", EnergyDecayPercentage);
        Preferences.Set("PredatorMatingEnergyCostPercentage", MatingEnergyCostPercentage);
        Preferences.Set("PredatorBreedingCooldown", BreedingCooldown);
        Preferences.Set("PredatorGestationPeriod", GestationPeriod);
        Preferences.Set("PredatorAttackDamage", AttackDamage);
        Preferences.Set("PredatorVisionRadius", VisionRadius);
        Preferences.Set("PredatorContactRadius", ContactRadius);
    }
    public static void ClearPref()
    {
        Preferences.Remove("PredatorHitPoints");
        Preferences.Remove("PredatorEnergy");
        Preferences.Remove("PredatorEnergyDecayPercentage");
        Preferences.Remove("PredatorMatingEnergyCostPercentage");
        Preferences.Remove("PredatorBreedingCooldown");
        Preferences.Remove("PredatorGestationPeriod");
        Preferences.Remove("PredatorAttackDamage");
        Preferences.Remove("PredatorVisionRadius");
        Preferences.Remove("PredatorContactRadius");
    }
}

