using System;

namespace TerraNova3.Models;

public interface IAbstractLiving
{

    int HitPoints { get; set; }

    int MaxHitPoints { get; set; }

    int EatSpeed { get; set; }

    void Feed(IAbstractEntity entity);

    bool IsAlive();

    void ConvertHPtoEnergy();

    void ConvertEnergytoHP();

}
