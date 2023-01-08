using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraNova3.Models;

namespace TerraNova3.View_Models;

public class OverlayGrid
{
    private Grid _grid;

    private TerraGrid _terraGrid;
    private int _cellSize;
    private int _numRows;
    private int _numColumns;

    public OverlayGrid(TerraGrid terraGrid)
    {
        _terraGrid = terraGrid;
        _numRows = terraGrid.GetNumRows();
        _numColumns = terraGrid.GetNumColumns();
        _cellSize = terraGrid.GetCellSize();

        _grid = new Grid();
        _grid.WidthRequest = _numColumns * _cellSize;
        _grid.HeightRequest = _numRows * _cellSize;


        for (int i = 0; i < _numRows; i++)
        {
            _grid.RowDefinitions.Add(new RowDefinition());
        }
        for (int i = 0; i < _numColumns; i++)
        {
            _grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        
    }

    public void AddEntity(IAbstractEntity entity)
    {
        //entity.EnergyLabel.Text = entity.Energy.ToString();
        entity.EntityImage.WidthRequest = _cellSize;
        entity.EntityImage.HeightRequest = _cellSize;
        _grid.SetRow(entity.EntityImage, entity.Row);
        //_grid.SetRow(entity.EnergyLabel, entity.Row);
        _grid.SetColumn(entity.EntityImage, entity.Col);
        //_grid.SetColumn(entity.EnergyLabel, entity.Col);
        entity.EntityImage.IsVisible = true;
        _grid.Children.Add(entity.EntityImage);
        //_grid.Children.Add(entity.EnergyLabel);

    }

    public void RemoveEntity(IAbstractEntity e)
    {
        
        _grid.Children.Remove(e.EntityImage);
        //_grid.Children.Remove(e.EnergyLabel);

    }
    public Grid GetGrid()
    {
        return _grid;
    }
    public List<(int, int)> GetPositions() { 

        List<(int, int)>positions = new List<(int, int)>();

        for (int x = 0; x< _numRows; x++)
        {
            for (int y = 0; y< _numColumns; y++)
            {
                positions.Add((x, y));
            }
        }
        return positions;
    }
    public List<(int, int)> GetRandomPositions()
    {
        List<(int, int)> positions = GetPositions();
        // Shuffle the list of positions
        Random rnd = new Random();
        for (int i = positions.Count - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            (int, int) temp = positions[i];
            positions[i] = positions[j];
            positions[j] = temp;

        }
        return positions;
    }

    public (int,int) GetSize()
    {
        return (_numRows, _numColumns);
    }


}
