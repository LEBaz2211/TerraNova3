using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraNova3.Models;

internal abstract class AbstractFood
{

    protected int maxEnergy;
    protected int energy;
    public AbstractFood(int maxEnergy)
    {
        this.maxEnergy = maxEnergy;
        this.energy = maxEnergy;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void SetEnergy(int energy)
    {
        this.energy = energy;
    }

    public abstract void Decay();
}
