

namespace TerraNova3.Models;

internal abstract class AbstractKiller : AbstractMoving
{
    // The amount of damage that the killer can inflict on its prey
    protected int attackDamage;

    public AbstractKiller(int startX, int startY, int maxEnergy, int maxHitPoints,string entityType, int speed, int visionRadius, int movementRadius, int attackDamage, int attackRadius)
        : base( startX, startY, maxEnergy, maxHitPoints, entityType, speed, visionRadius, movementRadius)
    {
        this.attackDamage = attackDamage;
    }

    // Returns the amount of damage that the killer can inflict on its prey
    public int GetAttackDamage()
    {
        return attackDamage;
    }

    // Abstract method that must be implemented by derived classes
    public abstract void Attack(Entity prey);
}

