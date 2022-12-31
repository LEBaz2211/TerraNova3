using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.View_Models;

namespace TerraNova3.Models;

internal class TileSet
{
    public SmartList plnts;
    public SmartList herbs;
    public SmartList apexs;
    public SmartList pFood;
    public SmartList aFood;

    private int plNumber;
    private int heNumber;
    private int prNumber;

    private int turnC;

    private int size;

    private Grid background;
    private Grid overlay;
    private OverlayGrid overlayGrid;


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
        plnts = new SmartList( new List<IAbstractEntity>());
        herbs = new SmartList(new List<IAbstractEntity>());
        apexs = new SmartList(new List<IAbstractEntity>());
        pFood = new SmartList(new List<IAbstractEntity>());
        aFood = new SmartList(new List<IAbstractEntity>());

        TerraGrid gridGen = new TerraGrid(size, size);
        gridGen.GenerateGrid();

        overlayGrid = new OverlayGrid(gridGen);

        

        background = gridGen.GetGrid();
        


    }
    public void update()
    {
        plnts.update(overlayGrid);
        herbs.update(overlayGrid);
        apexs.update(overlayGrid);
        pFood.update(overlayGrid);
        aFood.update(overlayGrid);
    }

    public Grid getBackground()
    {
        return background;
    }
    public OverlayGrid getOverlay()
    {
        return overlayGrid;
    }
}

internal class SmartList
{
    private List<IAbstractEntity> entities;

    public SmartList(List<IAbstractEntity> entitiesList)
    {
        entities = entitiesList;
    }

    public void add(IAbstractEntity entity)
    {
        entities.Add(entity);
    }
    public void remove(IAbstractEntity entity)
    {
        entities.Remove(entity);
    }
    public List<IAbstractEntity> GetEntities()
    {
        return entities;
    }
    public void update(OverlayGrid overlayGrid)
    {
        foreach (IAbstractEntity e in entities)
        {
            e.Update();
            overlayGrid.RemoveEntity(e);
            overlayGrid.AddEntity(e);

        }
    }
}
