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
    public int HitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _maxHitPoints;
    public int MaxHitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _energy;
    public int Energy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _maxEnergy;
    public int MaxEnergy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private List<string> _dietList;
    public List<string> DietList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _rootZone;
    public int RootZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _seedZone;
    public int SeedZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Plant(int row, int col, Image image)
    {
        Row = row;
        Col = col;
        EntityImage = image;
    }

    public void Update()
    {
        
    }

    public void Feed()
    {
        throw new NotImplementedException();
    }

    public void ConvertHPtoEnergy()
    {
        throw new NotImplementedException();
    }

    public void Seed()
    {
        throw new NotImplementedException();
    }

    public void EnergyDecay()
    {
        throw new NotImplementedException();
    }
}
