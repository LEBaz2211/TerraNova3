using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terranova3.Models;

namespace TerraNova3.View_Models;

public class OverlayGrid
{
    private Grid _grid;
    public Dictionary<Entity, Image> _entityImages;
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

        _entityImages = new Dictionary<Entity, Image>();
    }

    public void AddEntity(Entity entity, string imageFile)
    {
        Image image = new Image();
        image.Source = imageFile;
        image.WidthRequest = 40;
        image.HeightRequest = 40;
        _grid.SetRow(image, entity.Row);
        _grid.SetColumn(image, entity.Column);
        image.IsVisible = true;
        _grid.Children.Add(image);
        _entityImages.Add(entity, image);
    }

    public void RemoveEntity(Entity entity)
    {
        Image image = _entityImages[entity];
        _grid.Children.Remove(image);
        _entityImages.Remove(entity);
    }


}
