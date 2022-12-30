using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terranova3.Models;

internal class Predator : AbstractKiller
{

    public Predator(int startX, int startY, int maxEnergy, int maxHitPoints, string entityType, int speed, int visionRadius, int movementRadius, int attackDamage) : base(startX, startY, maxEnergy, maxHitPoints, entityType, speed, visionRadius, movementRadius, attackDamage)
    {
    }

    // Returns the attack strength of the predator
    public int GetAttackStrength()
    {
        return attackStrength;
    }

    // Returns the range at which the predator can detect prey
    public int GetVisionRange()
    {
        return visionRange;
    }

    // Returns the range at which the predator can attack prey
    public int GetAttackRange()
    {
        return attackRange;
    }

    // Sets the current amount of hit points that the predator has
    public void SetHitPoints(int hitPoints)
    {
        this.hitPoints = hitPoints;
    }

    // Sets the attack strength of the predator
    public void SetAttackStrength(int attackStrength)
    {
        this.attackStrength = attackStrength;
    }

    // Sets the movement speed of the predator
    public void SetMovementSpeed(int movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    // Sets the range at which

