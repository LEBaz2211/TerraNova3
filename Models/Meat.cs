using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Models;

namespace TerraNova3.Model;

public class Meat : IAbstractEntity
{
    SmartList pFood;
    
    private int _entityID;
    public int EntityID { get => _entityID; set => _entityID = value; }

    private int _row;
    public int Row { get => _row; set => _row = value; }

    private int _col;
    public int Col { get => _col; set => _col = value ; }

    private int _energy;
    public int Energy { get => _energy; set => _energy = value; }

    private int _maxEnergy;
    public int MaxEnergy { get => _maxEnergy; set => _maxEnergy = value; }

    public Image entityImage;
    public Image EntityImage { get => entityImage; set => entityImage = value; }

    private int _lostEnergy;
    public int LostEnergy { get => _lostEnergy; set => _lostEnergy = value; }

    private int _decayRate;
    public int DecayRate { get => _decayRate; set => _decayRate = value; }

    public Meat(int row, int col, int maxEnergy, SmartList pFood)
    {
        Row = row;
        Col = col;
        MaxEnergy = maxEnergy;
        Energy = MaxEnergy;
        LostEnergy = 0;
        DecayRate = 10;

        this.pFood = pFood;

        Image image = new Image();
        image.Source = "meat.png";
        EntityImage = image;

        EntityID = Global.GetID();
    }
    
    public void EnergyDecay()
    {
        Energy -= DecayRate;
        LostEnergy += DecayRate;
    }

    public bool Removed()
    {
        if (Energy <= 0) { pFood.add(new OrganicMatter(Row, Col, LostEnergy)); return true; }
        else { return false; }
    }

    public void Update()
    {
        EnergyDecay();
    }
}
