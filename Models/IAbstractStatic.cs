using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraNova3.Models;

interface IAbstractStatic
{
    int RootZone { get; set; }

    int SeedZone { get; set; }

    int WinterCycleTime { get; set; }

    int SpringCycleTime { get; set; }

    int Timer { get; set; }

    bool Winter { get; set; }

    bool Spring { get; set; }

    void Seed();

    void LookForOrganicMatter();

    void SeasonalChange();

}
