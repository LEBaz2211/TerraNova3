using System;
using System.Collections.Generic;

namespace TerraNova3.Models;

public interface IAbstractMoving
{

    // The sex of the moving entity
    int Sex { get; set; }
    
    bool BreedCoolDown { get; set; }

    int CoolDown { get; set; }

    // The speed of the moving entity
    int Speed { get; set; }

    bool ISEating { get; set; }

    // The vision radius of the moving entity
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

    void Repost();

    void Poop();
}

