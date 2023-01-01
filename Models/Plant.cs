using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Models;

namespace TerraNova3.Model;

internal class Plant : IAbstractEntity, IAbstractLiving, IAbstractStatic
{
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
    public int RootZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _seedZone;
    public int SeedZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _entityID;
    public int EntityID { get => _entityID; set => _entityID = value; }

    public Plant(int row, int col)
    {
        Row = row;
        Col = col;
        
        Image image = new Image();
        image.Source = "plant.png";
        EntityImage = image;
        
        MaxEnergy = 3000;
        Energy = MaxEnergy;
        MaxHitPoints = 10;
        HitPoints = MaxHitPoints;

        EntityID = Global.GetID();
    }

    public void Update()
    {
        EnergyDecay();
    }

    public void Feed(IAbstractEntity entity)
    {
        throw new NotImplementedException();
    }

    public void ConvertHPtoEnergy()
    {
        Energy += 100;
        HitPoints -= 1;
    }

    public void Seed()
    {
        throw new NotImplementedException();
    }

    public void EnergyDecay()
    {

        if(Energy <= 0) { ConvertHPtoEnergy(); }
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
            Energy -= 100;
            HitPoints += 1;
        }
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

}
