

namespace TerraNova3.Models;

internal interface IAbstractKiller
{
    // The amount of damage that the killer can inflict on its prey
    int AttackDamage { get; set; }


    // Abstract method that must be implemented by derived classes
    void Attack(IAbstractLiving prey);
}

