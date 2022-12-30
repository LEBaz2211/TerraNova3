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
    protected Dictionary<char, int> position;

    protected int contactZone;

    // The type of the living entity (e.g. "herbivore", "predator", "plant")
    protected string entityType;

    public Entity(int startX, int startY)
    {
        position = new Dictionary<char, int>
        {
            { 'x', startX },
            { 'y', startY }
        };

        contactZone = 1;
    }

    public int GetX()
    {
        return position['x'];
    }

    public int GetY()
    {
        return position['y'];
    }

    public void SetX(int x)
    {
        position['x'] = x;
    }

    public void SetY(int y)
    {
        position['y'] = y;
    }

    public int GetContactZone()
    {
        return contactZone;
    }

    public void SetContactZone(int contactZone)
    {
        this.contactZone = contactZone;
    }

    // Abstract method that must be implemented by derived classes
    public abstract void Update();
}

