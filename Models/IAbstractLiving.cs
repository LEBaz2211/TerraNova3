﻿using System;

namespace TerraNova3.Models;

public interface IAbstractLiving
{
    // The current hit points of the living entity
    int HitPoints { get; set; }

    // The maximum hit points of the living entity
    int MaxHitPoints { get; set; }

    List<string> DietList { get; set; }

    void Feed(IAbstractEntity entity);

    bool IsAlive();

    void ConvertHPtoEnergy();

    void ConvertEnergytoHP();

}
