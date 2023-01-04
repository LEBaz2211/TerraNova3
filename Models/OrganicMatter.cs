using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Models;

namespace TerraNova3.Model;

public class OrganicMatter : IAbstractEntity
{

    SmartList pFood;
    
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

    private int _lostEnergy;
    public int LostEnergy { get => _lostEnergy; set => _lostEnergy = value; }

    private int _decayRate;
    public int DecayRate { get => _decayRate; set => _decayRate = value; }

    private Label _energyLabel;
    public Label EnergyLabel { get => _energyLabel; set => _energyLabel = value; }

    public OrganicMatter(int row, int col, int maxEnergy, SmartList pFood)
    {
        Row = row;
        Col = col;
        MaxEnergy = maxEnergy;
        Energy = MaxEnergy;

        this.pFood = pFood;

        DecayRate = 0;
        LostEnergy = 0;

        Image image = new Image();
        image.Source = "organic.png";
        EntityImage = image;

        Label energyLabel = new Label();
        energyLabel.Text = Energy.ToString();
        EnergyLabel = energyLabel;

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

    public void PooCombine()
    {
        foreach (OrganicMatter poo in pFood.GetEntities())
        {
            if (poo.Row == Row && poo.Col == Col && poo.EntityID != EntityID)
            {
                Energy += poo.Energy;
                poo.Energy = 0;
            }
        }
    }

    public void Update()
    {
        PooCombine();
    }
}
