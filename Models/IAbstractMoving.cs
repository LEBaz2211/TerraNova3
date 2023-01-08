using System;
using System.Collections.Generic;

namespace TerraNova3.Models;

public interface IAbstractMoving
{

    int Sex { get; set; }

    int GestationPeriod { get; set; }

    bool BreedCoolDown { get; set; }

    int MatingEnergyCost { get; set; }

    int LaborEnergyCost { get; set; }

    int CoolDown { get; set; }

    

    int VisionRadius { get; set; }

    int ContactZone { get; set; }

    IAbstractEntity Mate { get; set; }

    void Move(int row, int col);

    void RandomMove();

    void LookForFood();

    void LookForMate();

    void LookForEnemy();

    void Breed();

    void Gestation();

    void Poop();
}

