using System;

namespace Terranova3.Models;

public abstract class AbstractLiving
{
    // The current hit points of the living entity
    protected int hitPoints;

    // The maximum hit points of the living entity
    protected int maxHitPoints;

    // The current energy of the living entity
    protected int energy;

    // The maximum energy of the living entity
    protected int maxEnergy;

    public AbstractLiving(int startX, int startY, int maxEnergy, int maxHitPoints)
    {
        this.hitPoints = maxHitPoints;
        this.maxHitPoints = maxHitPoints;
        this.energy = maxEnergy;
        this.maxEnergy = maxEnergy;
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

    // Returns the current energy of the living entity
    public int GetEnergy()
    {
        return energy;
    }

    // Returns the maximum energy of the living entity
    public int GetMaxEnergy()
    {
        return maxEnergy;
    }

    // Returns true if the living entity is still alive, false otherwise
    public bool IsAlive()
    {
        return hitPoints > 0;
    }

}
