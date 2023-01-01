using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Model;
using static Android.Icu.Text.CaseMap;

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
    public int VisionRadius { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _entityID;
    public int EntityID { get => _entityID; set => _entityID = value; }

    private IAbstractEntity _mate;
    public IAbstractEntity Mate { get => _mate; set => _mate = value; }

    private bool _breedCoolDown;
    public bool BreedCoolDown { get => _breedCoolDown; set => _breedCoolDown = value; }

    private int _coolDown;
    public int CoolDown { get => _coolDown; set => _coolDown = value; }

    private int _attackDamage;
    public int AttackDamage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }





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

        MaxEnergy = 1000;
        Energy = MaxEnergy;
        MaxHitPoints = 30;
        HitPoints = MaxHitPoints;
        ContactZone = 10;

        Sex = rand.Next(2);
        Mate = null;
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
            Energy -= MaxEnergy / 6;
            Mate = null;
            BreedCoolDown = true;
            CoolDown = 20;
        }
        else
        {
            Energy -= MaxEnergy / 3;
            Mate = null;
        }

    }



    public void Feed(IAbstractEntity meat)
    {
        if (Energy <= MaxEnergy)
        {
            Energy += 100;
            meat.Energy -= 100;
        }

    }

    public void LookForEnemy()
    {
        var closestHerb = new Dictionary<Herbivore, double>();
        var list = herbs.GetProxyEntities(this);

        if (list.Count != 0)
        {
            foreach ((IAbstractEntity herb, double distance) in list)
            {
                Herbivore prey = herb as Herbivore;
                if (closestHerb.Keys.Count == 0) { closestHerb.Add(prey, distance); }
                else if (distance < closestHerb.Values.Last()) { closestHerb.Remove(closestHerb.Keys.First()); closestHerb.Add(prey, distance); }
            }

            int rowDist = closestHerb.Keys.First().Row - Row;
            int colDist = closestHerb.Keys.First().Col - Col;

            if (Math.Abs(rowDist) >= Math.Abs(colDist) & rowDist != 0)
            {
                Move(rowDist / Math.Abs(rowDist), 0);
            }
            else if (colDist != 0) { Move(0, colDist / Math.Abs(colDist)); }
            else { Attack(closestHerb.Keys.First()); }
        }
        else { RandomMove(); }

    }

    public void LookForFood()
    {
        var closestMeat = new Dictionary<Meat, double>();
        var list = aFood.GetProxyEntities(this);

        if (list.Count != 0)
        {
            foreach ((IAbstractEntity m, double distance) in list)
            {
                Meat meat = m as Meat;
                if (closestMeat.Keys.Count == 0) { closestMeat.Add(meat, distance); }
                else if (distance < closestMeat.Values.Last()) { closestMeat.Remove(closestMeat.Keys.First()); closestMeat.Add(meat, distance); }
            }

            int rowDist = closestMeat.Keys.First().Row - Row;
            int colDist = closestMeat.Keys.First().Col - Col;

            if (Math.Abs(rowDist) >= Math.Abs(colDist) & rowDist != 0)
            {
                Move(rowDist / Math.Abs(rowDist), 0);
            }
            else if (colDist != 0) { Move(0, colDist / Math.Abs(colDist)); }
            else { Feed(closestMeat.Keys.First() as IAbstractEntity); }
        }
        else { LookForEnemy(); }

    }

    public void LookForMate()
    {
        var closestMate = new Dictionary<Predator, double>();
        var list = apexs.GetProxyEntities(this);

        if (list.Count != 0 & Mate == null)
        {
            foreach ((IAbstractEntity pr, double distance) in list)
            {
                Predator predator = pr as Predator;
                if (predator.Sex != Sex & predator.Mate == null & predator.BreedCoolDown == false)
                {
                    if (closestMate.Keys.Count == 0) { closestMate.Add(predator, distance); }
                    else if (distance < closestMate.Values.Last()) { closestMate.Remove(closestMate.Keys.First()); closestMate.Add(predator, distance); }
                }
            }

            if (closestMate.Keys.Count != 0)
            {
                Mate = closestMate.Keys.First();
                closestMate.Keys.First().Mate = this;
                int rowDist = closestMate.Keys.First().Row - Row;
                int colDist = closestMate.Keys.First().Col - Col;
                if (Math.Abs(rowDist) >= Math.Abs(colDist) & rowDist != 0)
                {
                    Move(rowDist / Math.Abs(rowDist), 0);
                }
                else if (colDist != 0) { Move(0, (colDist / Math.Abs(colDist))); }
            }

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
        else if (HitPoints < MaxHitPoints)
        {
            ConvertEnergytoHP();
        }
        Energy -= 1;
    }

    public void ConvertEnergytoHP()
    {
        if (Energy >= MaxEnergy)
        {
            Energy -= MaxEnergy / 300;
            HitPoints += 1;
        }
    }

    public void ConvertHPtoEnergy()
    {

        Energy += MaxEnergy / 300;
        HitPoints -= 1;

    }


    public bool IsAlive()
    {
        if (HitPoints <= 0)
        {
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
            apexs.add(newApex);
            BreedCoolDown = false;
        }
    }

    public void RandomMove()
    {
        (int, int) size = Global.GetSize();
        int dir = rand.Next(3);
        if (dir == 0 & Col < size.Item2) { Move(0, 1); }
        else if (dir == 1 & Row < size.Item1) { Move(1, 0); }
        else if (dir == 2 & Col > 0) { Move(0, -1); }
        else if (Row > 0) { Move(-1, 0); }
    }

    public void Update()
    {
        EnergyDecay();

        if (Energy <= MaxEnergy / 2) { LookForFood(); }
        else if (Energy > MaxEnergy / 2) { LookForMate(); }
        else { RandomMove(); }

        if (BreedCoolDown == true) { Gestation(); }
    }

}