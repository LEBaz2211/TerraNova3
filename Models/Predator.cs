using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Model;

namespace TerraNova3.Models;

class Predator : IAbstractEntity, IAbstractLiving, IAbstractMoving, IAbstractKiller
{
    // Declare variables

    Random rand = new Random();

    SmartList apexs;

    SmartList herbs;

    SmartList aFood;

    SmartList pFood;

    private int _row;
    public int Row { get => _row; set => _row = value; }

    private int _col;
    public int Col { get => _col; set => _col = value; }

    private int _contactZone;
    public int ContactZone { get => _contactZone; set => _contactZone = value; }

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

    private int _sex;
    public int Sex { get => _sex; set => _sex = value; }

    private int _speed;
    public int Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _visionRadius;
    public int VisionRadius { get => _visionRadius; set => _visionRadius = value; }

    private int _entityID;
    public int EntityID { get => _entityID; set => _entityID = value; }

    private IAbstractEntity _mate;
    public IAbstractEntity Mate { get => _mate; set => _mate = value; }

    private bool _breedCoolDown;
    public bool BreedCoolDown { get => _breedCoolDown; set => _breedCoolDown = value; }

    private int _coolDown;
    public int CoolDown { get => _coolDown; set => _coolDown = value; }

    private int _attackDamage;
    public int AttackDamage { get => _attackDamage; set => _attackDamage = value; }

    private int _lostEnergy;
    public int LostEnergy { get => _lostEnergy; set => _lostEnergy = value; }

    private int _decayRate;
    public int DecayRate { get => _decayRate; set => _decayRate = value; }

    private int _eatSpeed;
    public int EatSpeed { get => _eatSpeed; set => _eatSpeed = value; }

    private int _gestationTime;
    public int GestationPeriod { get => _gestationTime; set => _gestationTime = value; }

    private int _attackZone;
    public int AttackZone { get => _attackZone; set => _attackZone = value; }

    private int _matingEnergyCost;
    public int MatingEnergyCost { get => _matingEnergyCost; set => _matingEnergyCost = value; }

    private int _laborEnergyCost;
    public int LaborEnergyCost { get => _laborEnergyCost; set => _laborEnergyCost = value; }


    // Constructor
    public Predator(int row, int col, SmartList apexs, SmartList herbs, SmartList aFood, SmartList pFood)
    {
        Row = row;
        Col = col;


        Image image = new Image();
        image.Source = "carnivores.png";
        EntityImage = image;

        this.apexs = apexs;
        this.herbs = herbs;
        this.aFood = aFood;
        this.pFood = pFood;

        MaxEnergy = Preferences.Get("PredatorEnergy", 1000);
        Energy = LaborEnergyCost;
        MaxHitPoints = Preferences.Get("PredatorHitPoints", 100);
        HitPoints = MaxHitPoints;
        ContactZone = Preferences.Get("PredatorContactRadius", 0);
        AttackZone = Preferences.Get("PredatorAttackRadius", 1);
        VisionRadius = Preferences.Get("PredatorVisionRadius", 10);

        MatingEnergyCost = Convert.ToInt32(MaxEnergy * Preferences.Get("PredatorMatingEnergyCostPercentage", 50)/100);

        LaborEnergyCost = Convert.ToInt32(MaxEnergy * Preferences.Get("PredatorLaborEnergyCostPercentage", 50) / 100);

        DecayRate = Convert.ToInt32( MaxEnergy*Preferences.Get("PredatorEnergyDecayPercentage", 1)/100);
      
        LostEnergy = 0;
        EatSpeed = 100;

        AttackDamage = Preferences.Get("PredatorAttackDamage", 30);

        Sex = rand.Next(2);
        Mate = null;
        GestationPeriod = Preferences.Get("PredatorGestationPeriod", 50);

        BreedCoolDown = false;

        EntityID = Global.GetID();
    }

    public void Attack(IAbstractLiving prey)
    {
        prey.HitPoints -= AttackDamage;
    }

    public void Breed()
    {
        if (Sex == 0)
        {
            Energy -= MatingEnergyCost;
            LostEnergy += MatingEnergyCost;
            Mate = null;
            BreedCoolDown = true;
            CoolDown = GestationPeriod;
        }
        else
        {
            Energy -= MatingEnergyCost ;
            LostEnergy += MatingEnergyCost ;
            Mate = null;
        }

    }



    public void Feed(IAbstractEntity meat)
    {
        Energy += EatSpeed;
        meat.Energy -= EatSpeed;
    }

    public void LookForEnemy()
    {
        (Herbivore closestHerb, double smallestDist) = new Tuple<Herbivore, double>(null, 0);
        var list = herbs.GetProxyEntities(this, VisionRadius);

        if (list.Count != 0)
        {
            foreach ((IAbstractEntity herb, double distance) in list)
            {
                Herbivore prey = herb as Herbivore;
                if (closestHerb == null) { closestHerb = prey; smallestDist = distance; }
                else if (distance < smallestDist) { closestHerb = prey; smallestDist = distance; }
            }

            int rowDist = closestHerb.Row - Row;
            int colDist = closestHerb.Col - Col;
            
            if (Math.Abs(rowDist) >= Math.Abs(colDist) + AttackZone & rowDist != 0)
            {
                Move(rowDist / Math.Abs(rowDist), 0);
            }
            else if (colDist != 0 & Math.Abs(colDist) > AttackZone) { Move(0, colDist / Math.Abs(colDist)); }
            else { Attack(closestHerb); }
        }
        else { RandomMove(); }

    }

    public void LookForFood()
    {
        (Meat closestMeat, double smallestDist) = new Tuple<Meat, double>(null, 0);
        var list = aFood.GetProxyEntities(this, VisionRadius);

        if (list.Count != 0)
        {
            foreach ((IAbstractEntity m, double distance) in list)
            {
                Meat meat = m as Meat;
                if (closestMeat == null) { closestMeat = meat; smallestDist = distance; }
                else if (distance < smallestDist) { closestMeat = meat; smallestDist = distance; }
            }

            int rowDist = closestMeat.Row - Row;
            int colDist = closestMeat.Col - Col;

            if (Math.Abs(rowDist) >= Math.Abs(colDist) + ContactZone & rowDist != 0)
            {
                Move(rowDist / Math.Abs(rowDist), 0);
            }
            else if (colDist != 0 & Math.Abs(colDist) > ContactZone) { Move(0, colDist / Math.Abs(colDist)); }
            else { Feed(closestMeat); }
        }
        else { LookForEnemy(); }

    }

    public void LookForMate()
    {
        (Predator closestMate, double smallestDist) = new Tuple<Predator, double>(null, 0);
        var list = apexs.GetProxyEntities(this, VisionRadius);

        if (list.Count != 0 & Mate == null)
        {
            foreach ((IAbstractEntity pr, double distance) in list)
            {
                Predator predator = pr as Predator;
                if (predator.Sex != Sex & predator.Mate == null & predator.BreedCoolDown == false)
                {
                    if (closestMate == null) { closestMate = predator; smallestDist = distance; }
                    else if (distance < smallestDist) { closestMate = predator; smallestDist = distance; }
                }
            }

            if (closestMate != null)
            {
                Mate = closestMate;
                closestMate.Mate = this;
                int rowDist = closestMate.Row - Row;
                int colDist = closestMate.Col - Col;
                if (Math.Abs(rowDist) >= Math.Abs(colDist) + ContactZone & rowDist != 0)
                {
                    Move(rowDist / Math.Abs(rowDist), 0);
                }
                else if (colDist != 0 & Math.Abs(colDist) > ContactZone) { Move(0, (colDist / Math.Abs(colDist))); }
            }
            else { RandomMove(); }

        }
        else if (Mate != null)
        {
            int rowDist = Mate.Row - Row;
            int colDist = Mate.Col - Col;
            if (Math.Abs(rowDist) >= Math.Abs(colDist) & rowDist != 0)
            {
                Move(rowDist / Math.Abs(rowDist), 0);
            }
            else if (colDist != 0) { Move(0, (colDist / Math.Abs(colDist))); }
            else { Breed(); }
        }
        else { RandomMove(); }
    }

    public void Move(int row, int col)
    {
        Row += row;
        Col += col;
    }

    public void Repost()
    {
        throw new NotImplementedException();
    }

 

    public void EnergyDecay()
    {
        if (Energy <= 0) { ConvertHPtoEnergy(); }
        else if (HitPoints < MaxHitPoints & Energy >= MaxEnergy - MaxEnergy/10)
        {
            ConvertEnergytoHP();
        }
        Energy -= DecayRate;
        LostEnergy += DecayRate;
    }

    public void ConvertEnergytoHP()
    {
        Energy -= MaxEnergy/100;
        HitPoints += 1;
    }
    public void ConvertHPtoEnergy()
    {
        Energy += MaxEnergy/100;
        HitPoints -= 1;
    }


    public bool IsAlive()
    {
        if (HitPoints <= 0)
        {
            aFood.add(new Meat(Row, Col, Energy + LostEnergy, pFood));
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

    public void Gestation()
    {
        CoolDown -= 1;
        if (CoolDown == 0)
        {
            Predator newApex = new Predator(Row, Col, apexs, herbs, aFood, pFood);
            Energy -= LaborEnergyCost;
            apexs.add(newApex);
            BreedCoolDown = false;
        }
    }

    public void RandomMove()
    {
        (int, int) size = Global.GetSize();
        int dir = rand.Next(4);
        if (Row == size.Item1) { Move(-1, 0); }
        else if (Row == 0) { Move(1, 0); }
        else if (Col == size.Item2) { Move(0, -1); }
        else if (Col == 0) { Move(0, 1); }
        else if (dir == 0) { Move(0, 1); }
        else if (dir == 1) { Move(1, 0); }
        else if (dir == 2) { Move(0, -1); }
        else if (dir == 3) { Move(-1, 0); }
    }

    public void Update()
    {
        EnergyDecay();
        Poop();

        if (Energy <= MaxEnergy / 2) { LookForFood(); }
        else if (Energy > MaxEnergy / 2) { LookForMate(); }
        else { RandomMove(); }

        if (BreedCoolDown == true) { Gestation(); }
    }

    public void Poop()
    {
        if (rand.Next(15) == 0)
        {
            pFood.add(new OrganicMatter(Row, Col, LostEnergy, pFood));
            LostEnergy = 0;
        }
    }
}