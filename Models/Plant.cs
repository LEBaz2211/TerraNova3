using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Models;

namespace TerraNova3.Model;

internal class Plant : IAbstractEntity, IAbstractLiving, IAbstractStatic
{
    Random rand = new Random();

    SmartList pFood;

    SmartList plnts;

    private int _row;
    public int Row { get => _row; set => _row = value; }

    private int _col;
    public int Col { get => _col; set => _col = value; }

    private int _contactZone;
    public int ContactZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private Image entityImage;
    public Image EntityImage { get => entityImage; set => entityImage = value; }

    private int _hitPoints;
    public int HitPoints { get => _hitPoints; set => _hitPoints = value; }

    private int _maxHitPoints;
    public int MaxHitPoints { get => _maxHitPoints; set => _maxHitPoints = value; }

    private int _energy;
    public int Energy { get => _energy; set => _energy = value; }

    private int _maxEnergy;
    public int MaxEnergy { get => _maxEnergy; set => _maxEnergy = value; }

    private List<string> _dietList;
    public List<string> DietList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _rootZone;
    public int RootZone { get => _rootZone; set => _rootZone = value; }

    private int _seedZone;
    public int SeedZone { get => _seedZone; set => _seedZone = value; }

    private int _entityID;
    public int EntityID { get => _entityID; set => _entityID = value; }

    private int _timer;
    public int Timer { get => _timer; set => _timer = value; }

    private bool _winter;
    public bool Winter { get => _winter; set => _winter = value; }

    private bool _spring;
    public bool Spring { get => _spring; set => _spring = value; }

    private int _winterCycleTime;
    public int WinterCycleTime { get => _winterCycleTime; set => _winterCycleTime = value; }

    private int _springCycleTime;
    public int SpringCycleTime { get => _springCycleTime; set => _springCycleTime = value; }

    private int _lostEnergy;
    public int LostEnergy { get => _lostEnergy; set => _lostEnergy = value; }

    private int _decayRate;
    public int DecayRate { get => _decayRate; set => _decayRate = value; }

    private int _eatSpeed;
    public int EatSpeed { get => _eatSpeed; set => _eatSpeed = value; }

    private int _seedingEnergyCost;
    public int SeedingEnergyCost { get => _seedingEnergyCost; set => _seedingEnergyCost = value; }

    private Label _energyLabel;
    public Label EnergyLabel { get => _energyLabel; set => _energyLabel = value; }

    public Plant(int row, int col, SmartList plnts, SmartList pFood)
    {


        Row = row;
        Col = col;

        Label energyLabel = new Label();
        energyLabel.Text = Energy.ToString();
        EnergyLabel = energyLabel;

        Image image = new Image();
        image.Source = "plant.png";
        EntityImage = image;

        this.pFood = pFood;
        this.plnts = plnts;
        
        
        
        MaxEnergy = Preferences.Get("PlantEnergy", 1000);
        SeedingEnergyCost = Convert.ToInt32(MaxEnergy*Preferences.Get("PlantSeedingEnergyCostPercentage", 50)/100);
        DecayRate = Convert.ToInt32(MaxEnergy * Preferences.Get("PlantEnergyDecayPercentage", 1) / 100);
        Energy = SeedingEnergyCost;
        MaxHitPoints = Preferences.Get("PlantHitPoints", 2);
        HitPoints = MaxHitPoints;

        
        LostEnergy = 0;

        EntityID = Global.GetID();

        SeedZone = Preferences.Get("PlantSeedingRadius", 10);
        RootZone = Preferences.Get("PlantRootRadius", 4);
        EatSpeed = 50 + (EatSpeed - plnts.GetEntities().Count);

        

        WinterCycleTime = Preferences.Get("PlantWinterSeasonTime", 15);
        SpringCycleTime = Preferences.Get("PlantSpringSeasonTime", 20);
        Timer = WinterCycleTime;
        Winter = true;
        Spring = false;
    }

    public void Feed(IAbstractEntity entity)
    {
        Energy += EatSpeed;
        entity.Energy -= EatSpeed;
    }

    public void Seed()
    {
        List<((int, int),double)> freePostitions = plnts.calcProxy(this, SeedZone);
          

        int nbFreePos = freePostitions.Count;

        if (nbFreePos != 0)
        {
            int randomPos = rand.Next(0, nbFreePos);

            if(plnts.ISFree(freePostitions[randomPos].Item1.Item1, freePostitions[randomPos].Item1.Item2))
            {

                Energy -= SeedingEnergyCost;

                plnts.add(new Plant(freePostitions[randomPos].Item1.Item1, freePostitions[randomPos].Item1.Item2, plnts, pFood));
                
            }
        }
    }

    public void EnergyDecay()
    {

        if(Energy <= 0) 
        {
            ConvertHPtoEnergy();
        }
        else if (HitPoints < MaxHitPoints & Energy >= MaxEnergy / 100)
        {
            ConvertEnergytoHP();
        }
        
        
        Energy -= DecayRate;
        LostEnergy += DecayRate;
    }

    public void ConvertEnergytoHP()
    {
        Energy -= MaxEnergy / 100;
        HitPoints += 1;
    }

    public void ConvertHPtoEnergy()
    {
        Energy += MaxEnergy / 100;
        HitPoints -= 1;
    }
    public bool IsAlive()
    {
        if (HitPoints <= 0)
        {
            pFood.add(new OrganicMatter(Row, Col, Energy+LostEnergy, pFood));
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool Removed()
    {
        return !IsAlive();
    }

    public void LookForOrganicMatter()
    {
        var closestOrganicMatter = new Dictionary<IAbstractEntity, double>();
        var list = pFood.GetProxyEntities(this, RootZone);

        if (list.Count != 0)
        {
            foreach ((IAbstractEntity organicMatter, double distance) in list)
            {
                if (closestOrganicMatter.Keys.Count == 0) { closestOrganicMatter.Add(organicMatter, distance); }
                else if (distance < closestOrganicMatter.Values.Last()) { closestOrganicMatter.Remove(closestOrganicMatter.Keys.First()); closestOrganicMatter.Add(organicMatter, distance); }
            }
            Feed(closestOrganicMatter.Keys.First());
        }
    }

    public void SeasonalChange()
    {
        if (Timer <= 0) 
        { 
            if (Winter) { Winter = false; Spring = true; Timer = SpringCycleTime; }
            else { Winter = true; Spring = false; Timer = WinterCycleTime; }
        }
        else if (Timer > 0) { Timer -= 1; }
    }

    public void Update()
    {
        EnergyDecay();
        SeasonalChange();

        if(Energy <= MaxEnergy - 10*DecayRate) { LookForOrganicMatter(); }

        if(Spring & Energy >= MaxEnergy - MaxEnergy / 4) { Seed(); }
    }
}
