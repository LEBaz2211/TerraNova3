using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Model;
using TerraNova3.Models;
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

    List<(int, int)> positions;

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
        plnts = new SmartList(new List<IAbstractEntity>());
        herbs = new SmartList(new List<IAbstractEntity>());
        apexs = new SmartList(new List<IAbstractEntity>());
        pFood = new SmartList(new List<IAbstractEntity>());
        aFood = new SmartList(new List<IAbstractEntity>());

        TerraGrid gridGen = new TerraGrid(size, size);
        gridGen.GenerateGrid();


        overlayGrid = new OverlayGrid(gridGen);

        Global.SetSize((gridGen.GetNumRows(), gridGen.GetNumColumns()));

        background = gridGen.GetGrid();
        


    }
    public void update()
    {
        pFood.update(overlayGrid);
        aFood.update(overlayGrid);
        plnts.update(overlayGrid);
        herbs.update(overlayGrid);
        apexs.update(overlayGrid);
    }

    public Grid getBackground()
    {
        return background;
    }
    public OverlayGrid getOverlay()
    {
        List<(int, int)> positions = overlayGrid.GetRandomPositions();

        addOrganicMatter(positions);
        addPlants(positions);
        addHerbs(positions);
        addApexs(positions);
        
        return overlayGrid;
    }

    public void addPlants(List<(int, int)> positions)
    {
        for (int i = 0; i < plNumber; i++)
        {
            plnts.add(new Plant(positions[i% (size * size)].Item1, positions[i % (size * size)].Item2, plnts, pFood));
        }
    }

    public void addHerbs(List<(int, int)> positions)
    {
        for (int i = plNumber; i < heNumber + plNumber; i++)
        {
            herbs.add(new Herbivore(positions[i % (size * size)].Item1, positions[i % (size * size)].Item2, plnts, herbs, aFood, pFood));
        }
    }

    public void addApexs(List<(int, int)> positions)
    {
        for (int i = heNumber + plNumber; i < prNumber + heNumber + plNumber; i++)
        {
            apexs.add(new Predator(positions[i % (size * size)].Item1, positions[i % (size * size)].Item2, apexs, herbs, aFood, pFood));
        }
    }

    public void addOrganicMatter(List<(int, int)> positions)
    {
        for (int i = plNumber + heNumber + plNumber; i < positions.Count; i++)
        {
            if (i % 5 == 0)
            { 
                pFood.add(new OrganicMatter(positions[i % (size * size)].Item1, positions[i % (size * size)].Item2, 2000, pFood));
            }
        }
    }
}

public class SmartList
{
    private List<IAbstractEntity> entities;
    private Dictionary<(int,int), IAbstractEntity> entitiesPos;
    

    public SmartList(List<IAbstractEntity> entitiesList)
    {
        entities = entitiesList;
        entitiesPos = new Dictionary<(int, int), IAbstractEntity>();
    }

    public bool ISFree(int x, int y)
    {
        return !entitiesPos.ContainsKey((x, y));
    }

    public Dictionary<(int, int), IAbstractEntity> GetEntitiesPos()
    {
        return entitiesPos;
    }

    public void makePos()
    {
        entitiesPos = new Dictionary<(int, int), IAbstractEntity>();
        foreach (IAbstractEntity e in entities)
        {
            if (!entitiesPos.Keys.Contains((e.Row, e.Col)))
            entitiesPos.Add((e.Row,e.Col),e); 
        }
        
    }
    public List<((int, int), double)> calcProxy(IAbstractEntity e, int zone)
    {
        List<((int, int), double)> res = new List<((int, int), double)>();
        int r = zone;
        int x = e.Col;
        int y = e.Row;
       

        for (int col = x - r; col <= x + r; col++)
        {
            for (int row = y - r; row <= y + r; row++)
            {
                // Calculate the distance between the current point and the center
                double distance = Math.Sqrt((col - x) * (col - x) + (row - y) * (row - y));

                (int, int) gridSize = Global.GetSize();

                // If the distance is less than or equal to the radius, add the point to the list ONLY if they are in the grid
                if (distance <= r & row >= 0 & col >= 0 & row <= gridSize.Item1 & col <= gridSize.Item2)
                {
                    res.Add(((row, col), distance));
                }
            }
        }
        return res;
    }
    public void add(IAbstractEntity entity)
    {
        entities.Add(entity);
    }
    public void  remove(IAbstractEntity entity)
    {
        entities.Remove(entity);
    }
    public List<IAbstractEntity> GetEntities()
    {
        return entities;
    }

    public List<(IAbstractEntity, double)> GetProxyEntities(IAbstractEntity e, int zone)
    {
        List<(IAbstractEntity, double)> proxy = new List<(IAbstractEntity, double)>();
        List<((int, int), double)> proxyPos = calcProxy(e, zone);

        foreach(((int, int) pos , double distance) in proxyPos)
        {
            
            if (entitiesPos.Keys.Contains(pos))
            {
                if (entitiesPos[pos].EntityID != e.EntityID)
                {
                    proxy.Add((entitiesPos[pos], distance));
                }
            }

        }
        return proxy;
    }

    public void update(OverlayGrid overlayGrid)
    {
        makePos();
        List<IAbstractEntity> temp = new List<IAbstractEntity>(entities);
        foreach (IAbstractEntity e in temp)
        {

            if (e.Removed())
            {
                overlayGrid.RemoveEntity(e);
                remove(e);
            }
            else
            {
                e.Update();
                overlayGrid.RemoveEntity(e);
                overlayGrid.AddEntity(e);
            }

        }
    }
}

public static class Global
{
    public static int ID = 0;
    public static (int, int) Size = (0, 0);
    public static int GameTime = 0;

    public static int GetID()
    {
        ID++;
        return ID;
    }

    public static void SetSize((int,int) size)
    {
        Size = size;
    }

    public static (int, int) GetSize()
    {
        return Size;
    }

    public static void TickGameTime()
    {
        GameTime++;
    }

    public static int GetGameTime()
    {
        return GameTime;
    }

    public static void ResetGameTime()
    {
        GameTime = 0;
    }

}
