using System;

namespace TerraNova3.Models;

public interface IAbstractLiving
{
    // The current hit points of the living entity
    int HitPoints { get; set; }

    // The maximum hit points of the living entity
    int MaxHitPoints { get; set; }

    // The current energy of the living entity
    int Energy { get; set; }

    // The maximum energy of the living entity
    int MaxEnergy { get; set; }

    List<string> DietList { get; set; }

    void Feed();

    void ConvertHPtoEnergy();

    void EnergyDecay();

}
