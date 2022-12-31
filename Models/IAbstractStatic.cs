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

    void Seed();

}
