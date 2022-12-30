using System;
using System.Collections.Generic;

namespace TerraNova3.Models;

public abstract class AbstractMoving
{

    // The sex of the moving entity
    protected string sex;

    // The speed of the moving entity
    protected int speed;

    // The vision radius of the moving entity
    protected int visionRadius;

    // The movement radius of the moving entity
    protected int movementRadius;

    public AbstractMoving(int startX, int startY, int maxEnergy, int maxHitPoints, string type, int speed, int visionRadius, int movementRadius)
    {
        this.speed = speed;
        this.visionRadius = visionRadius;
        this.movementRadius = movementRadius;
    }

    // Returns the speed of the moving entity
    public int GetSpeed()
    {
        return speed;
    }

    // Returns the vision radius of the moving entity
    public int GetVisionRadius()
    {
        return visionRadius;
    }

    // Returns the movement radius of the moving entity
    public int GetMovementRadius()
    {
        return movementRadius;
    }

    // Abstract method that must be implemented by derived classes
    public abstract void Move();
}

