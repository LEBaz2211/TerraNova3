using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace Terranova3.Models;

public abstract class Entity
{
    // A dictionary to store the x and y positions of the entity on the grid
    private Dictionary<char, int> position;

    private int contactZone { get; set; }

    public Entity(int startX, int startY, int maxEnergy, int maxHitPoints)
    {
        position = new Dictionary<char, int>
        {
            { 'x', startX },
            { 'y', startY }
        };
        energy = maxEnergy;
    }

    // Returns the current x position of the entity
    public int GetX()
    {
        return position['x'];
    }

    // Returns the current y position of the entity
    public int GetY()
    {
        return position['y'];
    }

    // Returns the current amount of energy that the entity has
    public int GetEnergy()
    {
        return energy;
    }

    // Returns the maximum amount of energy that the entity can have
    public int GetMaxEnergy()
    {
        return maxEnergy;
    }

    // Sets the current x position of the entity
    public void SetX(int x)
    {
        position['x'] = x;
    }

    // Sets the current y position of the entity
    public void SetY(int y)
    {
        position['y'] = y;
    }

    // Sets the current amount of energy that the entity has
    public void SetEnergy(int energy)
    {
        this.energy = energy;
    }

    // Abstract method that must be implemented by derived classes
    public abstract void Update();
}

