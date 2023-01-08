

namespace TerraNova3.Models;

internal interface IAbstractKiller
{

    int AttackDamage { get; set; }

    int AttackZone { get; set; }


    void Attack(IAbstractLiving prey);
}

