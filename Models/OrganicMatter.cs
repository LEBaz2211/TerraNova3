using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Models;

namespace TerraNova3.Model;

public class OrganicMatter : IAbstractEntity
{
    private int _entityID;
    public int EntityID { get => _entityID; set => _entityID = value; }

    private int _row;
    public int Row { get => _row; set => _row = value; }

    private int _col;
    public int Col { get => _col; set => _col = value; }

    private int _energy;
    public int Energy { get => _energy; set => _energy = value; }

    private int _maxEnergy;
    public int MaxEnergy { get => _maxEnergy; set => _maxEnergy = value; }

    public Image entityImage;
    public Image EntityImage { get => entityImage; set => entityImage = value; }

    public OrganicMatter(int row, int col)
    {
        Row = row;
        Col = col;
        MaxEnergy = 1000;
        Energy = MaxEnergy;

        Image image = new Image();
        image.Source = "organic.png";
        EntityImage = image;

        EntityID = Global.GetID();
    }
    public void EnergyDecay()
    {

    }

    public bool Removed()
    {
        if (Energy <= 0) { return true; }
        else { return false; }
    }

    public void Update()
    {

    }
}
