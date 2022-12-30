using System;

namespace Terranova3.Models;

public abstract class AbstractLiving : Entity
{
    // The current hit points of the living entity
    protected int hitPoints;

    // The maximum hit points of the living entity
    protected int maxHitPoints;

    // The type of the living entity (e.g. "herbivore", "predator", "plant")
    protected string entityType;

    public AbstractLiving(int startX, int startY, int maxEnergy, int maxHitPoints, string entityType) : base(startX, startY, maxEnergy, maxHitPoints)
    {
        this.hitPoints = maxHitPoints;
        this.maxHitPoints = maxHitPoints;
        this.entityType = entityType;
    }

    // Returns the current hit points of the living entity
    public int GetHitPoints()
    {
        return hitPoints;
    }

    // Returns the maximum hit points of the living entity
    public int GetMaxHitPoints()
    {
        return maxHitPoints;
    }

    // Returns the type of the living entity
    public string GetEntityType()
    {
        return entityType;
    }

    // Returns true if the living entity is still alive, false otherwise
    public bool IsAlive()
    {
        return hitPoints > 0;
    }

}
