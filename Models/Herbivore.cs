using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Model;

namespace TerraNova3.Models;

internal class Herbivore : IAbstractEntity, IAbstractLiving, IAbstractMoving
{

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

    private int _HitPoints;
    public int HitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _maxHitPoints;
    public int MaxHitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _energy;
    public int Energy { get => _energy; set => _energy = value; }

    private int _maxEnergy;
    public int MaxEnergy { get => _maxEnergy ; set => _maxEnergy = value; }

    private List<string> _dietList;
    public List<string> DietList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private string _sex;
    public string Sex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _speed;
    public int Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private int _visionRadius;
    public int VisionRadius { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Herbivore(int row, int col, Image image, SmartList plnts, SmartList herbs)
    {
        Row = row;
        Col = col;
        EntityImage = image;
        this.plnts = plnts;
        this.herbs = herbs;
        MaxEnergy = 3000;
        Energy = MaxEnergy;
        ContactZone = 10;
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
            foreach ((IAbstractEntity plant, double distance) in list)
            {
                if (closestPlant.Keys.Count == 0) { closestPlant.Add(plant, distance); }
                else if (distance < closestPlant.Values.Last()) { closestPlant.Remove(closestPlant.Keys.First()); closestPlant.Add(plant, distance);}
            }
        }
        

      

        int rowDist = closestPlant.Keys.First().Row - Row;
        int colDist = closestPlant.Keys.First().Col - Col;
        if (Math.Abs(rowDist) >= Math.Abs(colDist) & rowDist != 0)
        {
            Move(rowDist / Math.Abs(rowDist), 0);
        }
        else if(colDist != 0){ Move(0, (colDist/Math.Abs(colDist))); }
        else { Feed(); }
    }

    public void LookForMate()
    {
        var closestMate = new Dictionary<IAbstractEntity, double>();

        foreach (IAbstractEntity herb in herbs.GetEntities())
        {
            double distance = Math.Sqrt(Math.Pow(Math.Abs(herb.Row - Row), 2) + Math.Pow(Math.Abs(herb.Col - Col), 2));
            if (closestMate.Keys.Count == 0) { closestMate.Add(herb, distance); }
            else if (distance < closestMate.Values.Last()) { closestMate.Remove(closestMate.Keys.First()); closestMate.Add(herb, distance); }
        }

        int rowDist = closestMate.Keys.First().Row - Row;
        int colDist = closestMate.Keys.First().Col - Col;
        if (Math.Abs(rowDist) >= Math.Abs(colDist) & rowDist != 0)
        {
            Move(rowDist / Math.Abs(rowDist), 0);
        }
        else if (colDist != 0) { Move(0, (colDist / Math.Abs(colDist))); }
        else { Feed(); }
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
        Energy--;
    }

    public void Update()
    {
        EnergyDecay();

        LookForFood();
        
    }


}
