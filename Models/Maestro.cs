﻿using System;
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
    private Dictionary<(int,int), IAbstractEntity> entitiesPos;
    

    public SmartList(List<IAbstractEntity> entitiesList)
    {
        entities = entitiesList;
        
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
    public List<((int, int), double)> calcProxy(IAbstractEntity e)
    {
        List<((int, int), double)> res = new List<((int, int), double)>();
        int r = e.ContactZone;
        int x = e.Col;
        int y = e.Row;
       

        for (int col = x - r; col <= x + r; col++)
        {
            for (int row = y - r; row <= y + r; row++)
            {
                // Calculate the distance between the current point and the center
                double distance = Math.Sqrt((col - x) * (col - x) + (row - y) * (row - y));

                // If the distance is less than or equal to the radius, add the point to the list
                if (distance <= r)
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

    public List<(IAbstractEntity, double)> GetProxyEntities(IAbstractEntity e)
    {
        List<(IAbstractEntity, double)> proxy = new List<(IAbstractEntity, double)>();
        List<((int, int), double)> proxyPos = calcProxy(e);

        foreach(((int, int)pos , double distance) in proxyPos)
        {
            //    if (entitiesPos[pos.Item1] != e)
            //    {
            //        proxy.Add((entitiesPos[pos.Item1], pos.Item2));
            //    }
            if (entitiesPos.Keys.Contains(pos))
            {
                proxy.Add((entitiesPos[pos], distance));
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
