using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraNova3.Models;

internal class Herbivore : IAbstractEntity, IAbstractLiving, IAbstractMoving
{

    private int _row;
    public int Row { get => _row; set => _row = value; }

    private int _col;
    public int Col { get => _col; set => _col = value; }

    private int _contactZone;
    public int ContactZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private Image entityImage;
    public Image EntityImage { get => entityImage; set => entityImage = value; }

    private int _HitPoints;
    public int HitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _maxHitPoints;
    public int MaxHitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _energy;
    public int Energy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _maxEnergy;
    public int MaxEnergy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private List<string> _dietList;
    public List<string> DietList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private string _sex;
    public string Sex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _speed;
    public int Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _visionRadius;
    public int VisionRadius { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Herbivore(int row, int col, Image image)
    {
        Row = row;
        Col = col;
        EntityImage = image;

    }

    public void Breed()
    {
        throw new NotImplementedException();
    }

    public void ConvertHPtoEnergy()
    {
        throw new NotImplementedException();
    }

    public void Feed()
    {
        throw new NotImplementedException();
    }

    public void LookForEnemy()
    {
        throw new NotImplementedException();
    }

    public void LookForFood()
    {
        throw new NotImplementedException();
    }

    public void LookForMate()
    {
        throw new NotImplementedException();
    }

    public void Move()
    {
        Col++;
    }

    public void Repost()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        Move();
    }
}
