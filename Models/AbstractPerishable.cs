using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraNova3.Models;

internal abstract class AbstractPerishable
{

    protected int decayRate;
    
    public AbstractPerishable(int decayRate)
    {
        this.decayRate = decayRate;
    }

    public abstract void Decay();

    public abstract void Convert();
}
