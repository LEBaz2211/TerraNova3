using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terranova3.Models;

internal class TileSet
{
    private SmartList plnts;
    private SmartList herbs;
    private SmartList apexs;
    private SmartList pFood;
    private SmartList aFood;
    
    private int plNumber;
    private int heNumber;
    private int prNumber;

    private int turnC;

    private int size;

    public TileSet(int plantNumber, int herbivorNumber, int predatorNumber, int sz)
    {
        plNumber = plantNumber;
        heNumber = herbivorNumber;
        prNumber = predatorNumber;

        size = sz;
        init();
    }

    public void init()
    {
        turnC = 0;
    }
    public void update()
    {
        plnts.update();
        herbs.update();
        apexs.update();
        pFood.update();
        aFood.update();
    }

}

internal class SmartList
{
    private List<Entity> entities;

    public SmartList(List<Entity> entitiesList)
    {
        entities = entitiesList;
    }

    public void add(Entity entity)
    {
        entities.Add(entity);
    }
    public void remove(Entity entity)
    {
        entities.Remove(entity);
    }
    public List<Entity> GetEntities()
    {
        return entities;
    }
    public void update()
    {
        foreach (Entity e in entities)
        {
            e.update();
        }
    }
}
