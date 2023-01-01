﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Model;
using System.Text.Json;
using Newtonsoft.Json;

namespace TerraNova3.Models;

internal class Herbivore : IAbstractEntity, IAbstractLiving, IAbstractMoving
{
    Random rand = new Random();

    SmartList plnts;

    SmartList herbs;

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
    public int MaxHitPoints { get => _maxHitPoints; set => _maxHitPoints = value ; }

    private int _energy;
    public int Energy { get => _energy; set => _energy = value; }

    private int _maxEnergy;
    public int MaxEnergy { get => _maxEnergy ; set => _maxEnergy = value; }

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

    public Herbivore(int row, int col, SmartList plnts, SmartList herbs)
    {
        Row = row;
        Col = col;
        
        
        Image image = new Image();
        image.Source = "herbivores.png";
        EntityImage = image;
        
        this.plnts = plnts;
        this.herbs = herbs;
        
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



    public void Feed(IAbstractEntity entity)
    {
        if(Energy <= MaxEnergy)
        {
            Energy += 100;
            entity.Energy -= 100;
        }
    }

    public void LookForEnemy()
    {
        throw new NotImplementedException();
    }

    public void LookForFood()
    {
        var closestPlant = new Dictionary<IAbstractEntity,double>() ;
        var list = plnts.GetProxyEntities(this);

        if (list.Count != 0)
        {
            foreach ((IAbstractEntity pl, double distance) in list)
            {
                Plant plant = pl as Plant;
                if (closestPlant.Keys.Count == 0) { closestPlant.Add(plant, distance); }
                else if (distance < closestPlant.Values.Last()) { closestPlant.Remove(closestPlant.Keys.First()); closestPlant.Add(plant, distance);}
            }
            int rowDist = closestPlant.Keys.First().Row - Row;
            int colDist = closestPlant.Keys.First().Col - Col;
            if (Math.Abs(rowDist) >= Math.Abs(colDist) & rowDist != 0)
            {
                Move(rowDist / Math.Abs(rowDist), 0);
            }
            else if(colDist != 0){ Move(0, (colDist/Math.Abs(colDist))); }
            else { Feed(closestPlant.Keys.First()); }
        }
        
    }

    public void LookForMate()
    {
        var closestMate = new Dictionary<Herbivore, double>();
        var list = herbs.GetProxyEntities(this);

        if (list.Count != 0 & Mate == null)
        {
            foreach ((IAbstractEntity hb, double distance) in list)
            {
                Herbivore herb = hb as Herbivore;
                if(herb.Sex != Sex & herb.Mate == null & herb.BreedCoolDown == false)
                {
                    if (closestMate.Keys.Count == 0) { closestMate.Add(herb, distance); }
                    else if (distance < closestMate.Values.Last()) { closestMate.Remove(closestMate.Keys.First()); closestMate.Add(herb, distance); }
                }
            }

            if(closestMate.Keys.Count != 0)
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
        else if(Mate != null)
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
    
    public void Gestation()
    {
        CoolDown -= 1;
        if (CoolDown == 0)
        {
            Herbivore newHerb = new Herbivore(Row, Col, plnts, herbs);
            herbs.add(newHerb);
            BreedCoolDown = false;
        }
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
    
    public void Update()
    {
        EnergyDecay();

        if(Energy <= MaxEnergy/2 ) { LookForFood(); }
        else if(Energy > MaxEnergy / 2) { LookForMate(); }

        if (BreedCoolDown == true) { Gestation(); }

    }
}
