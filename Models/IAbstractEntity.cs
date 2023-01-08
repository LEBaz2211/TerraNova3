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

    int EntityID { get; set; }
    
    int Row { get; set; }

    int Col { get; set; }

    int Energy { get; set; }

    int MaxEnergy { get; set; }

    int LostEnergy { get; set; }

    int DecayRate { get; set; }

    Image EntityImage { get; set; }

    Label EnergyLabel { get; set; }

    void Update();

    void EnergyDecay();

    bool Removed();

}

