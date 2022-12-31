using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace TerraNova3.Models;

public interface IAbstractEntity
{
    // A dictionary to store the x and y positions of the entity on the grid

    int EntityID { get; set; }
    
    int Row { get; set; }

    int Col { get; set; }

    int ContactZone { get; set; }

    // The current energy of the living entity
    int Energy { get; set; }

    // The maximum energy of the living entity
    int MaxEnergy { get; set; }

    Image EntityImage { get; set; }

    void Update();

    void ConvertHPtoEnergy();

    void ConvertEnergytoHP();

    void EnergyDecay();

    bool Removed();

    ///MUST REMOVE AFTER TESTING
    int GetHitPoints();
}

