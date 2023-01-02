namespace TerraNova3;

public partial class PredatorPref : ContentPage
{
    public int HitPoints { get; set; }
    public int Energy { get; set; }
    public int EnergyDecayPercentage { get; set; }
    public int MatingEnergyCostPercentage { get; set; }
    public int GestationPeriod { get; set; }

    public int AttackDamage { get; set; }
    public int AttackRadius { get; set; }
    public int VisionRadius { get; set; }
    public int ContactRadius { get; set; }

    public PredatorPref()
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
        AttackDamage = int.Parse(attackDamageEntry.Text);
        AttackRadius = int.Parse(attackRadiusEntry.Text);
        VisionRadius = int.Parse(visionRadiusEntry.Text);
        ContactRadius = int.Parse(contactRadiusEntry.Text);
    }


    public  void SavePref()
    {
        Preferences.Set("PredatorHitPoints", HitPoints);
        Preferences.Set("PredatorEnergy", Energy);
        Preferences.Set("PredatorEnergyDecayPercentage", EnergyDecayPercentage);
        Preferences.Set("PredatorMatingEnergyCostPercentage", MatingEnergyCostPercentage);
        Preferences.Set("PredatorGestationPeriod", GestationPeriod);
        Preferences.Set("PredatorAttackDamage", AttackDamage);
        Preferences.Set("PredatorAttackRadius", AttackRadius);
        Preferences.Set("PredatorVisionRadius", VisionRadius);
        Preferences.Set("PredatorContactRadius", ContactRadius);
    }

    public void SetPref()
    {
        hitPointsEntry.Text = $"{Preferences.Get("PredatorHitPoints", 100)}";
        energyEntry.Text = $"{Preferences.Get("PredatorEnergy", 1000)}";
        energyDecayEntry.Text = $"{Preferences.Get("PredatorEnergyDecayPercentage", 1)}";
        matingEnergyCostEntry.Text = $"{Preferences.Get("PredatorMatingEnergyCostPercentage", 50)}";
        gestationPeriodEntry.Text = $"{Preferences.Get("PredatorGestationPeriod", 50)}";
        attackDamageEntry.Text  = $"{Preferences.Get("PredatorAttackDamage", 30)}";
        attackRadiusEntry.Text = $"{Preferences.Get("PredatorAttackRadius", 1)}";
        visionRadiusEntry.Text = $"{Preferences.Get("PredatorVisionRadius", 10)}";
        contactRadiusEntry.Text = $"{Preferences.Get("PredatorContactRadius", 0)}";
    }

    public static void ClearPref()
    {
        Preferences.Remove("PredatorHitPoints");
        Preferences.Remove("PredatorEnergy");
        Preferences.Remove("PredatorEnergyDecayPercentage");
        Preferences.Remove("PredatorMatingEnergyCostPercentage");
        Preferences.Remove("PredatorGestationPeriod");
        Preferences.Remove("PredatorAttackDamage");
        Preferences.Remove("PredatorAttackRadius");
        Preferences.Remove("PredatorVisionRadius");
        Preferences.Remove("PredatorContactRadius");
        
    }
}

