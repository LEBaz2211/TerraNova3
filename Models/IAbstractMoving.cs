using System;
using System.Collections.Generic;

namespace TerraNova3.Models;

public interface IAbstractMoving
{

    // The sex of the moving entity
    string Sex { get; set; }

    // The speed of the moving entity
    int Speed { get; set; }

    // The vision radius of the moving entity
    int VisionRadius { get; set; }

    // Abstract method that must be implemented by derived classes
    void Move(int row, int col);

    void LookForFood();

    void LookForMate();

    void LookForEnemy();

    void Breed(IAbstractEntity mate);

    void Repost();
}

