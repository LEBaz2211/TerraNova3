using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraNova3.View_Models;

public class TerraGrid
{
    private Grid _grid;
    private int _cellSize;
    private int _numRows;
    private int _numColumns;
    private Random _random;

    //set the picture paths:
    private string tile1 = "tile1.png";
    private string tile2 = "tile2.png";
    private string tile3 = "tile3.png";
    private string tileL = "tile_left.png";
    private string tileR = "tile_right.png";
    private string tileT = "tile_top.png";
    private string tileB = "tile_bottom.png";
    private string tileBR = "tile_bottom_right.png";
    private string tileBL = "tile_bottom_left.png";
    private string tileTL = "tile_top_left.png";
    private string tileTR = "tile_top_right.png";

    public TerraGrid(int numRows, int numColumns)
    {
        _cellSize = 40;
        _numRows = numRows;
        _numColumns = numColumns;
        _random = new Random();

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

    public void AddImage(string imageFile, int row, int column)
    {
        Image image = new Image();
        image.Source = imageFile;
        image.WidthRequest = _cellSize;
        image.HeightRequest = _cellSize;
        _grid.SetRow(image, row);
        _grid.SetColumn(image, column);
        _grid.Children.Add(image);
    }

    public void AddCornerImages(string tileTL, string tileTR, string tileBR, string tileBL)
    {
        AddImage(tileTL, 0, 0);
        AddImage(tileTR, 0, _numColumns - 1);
        AddImage(tileBR, _numRows - 1, _numColumns - 1);
        AddImage(tileBL, _numRows - 1, 0);
    }
    public void AddBorderImages(string tileL, string tileR, string tileT, string tileB)
    {
        for (int i = 1; i < _numColumns - 1; i++)
        {
            AddImage(tileT, 0, i);
            AddImage(tileB, _numRows - 1, i);
        }
        for (int i = 1; i < _numRows - 1; i++)
        {
            AddImage(tileL, i, 0);
            AddImage(tileR, i, _numColumns - 1);
        }
    }

    public void AddRandomInnerImage(string image1, string image2, string image3)
    {
        for (int row = 1; row < _numRows - 1; row++)
        {
            for (int col = 1; col < _numColumns - 1; col++)
            {
                int randomInt = _random.Next(3);
                if (randomInt == 0)
                {
                    AddImage(image1, row, col);
                }
                else if (randomInt == 1)
                {
                    AddImage(image2, row, col);
                }
                else
                {
                    AddImage(image3, row, col);
                }
            }
        }

    }

    public void GenerateGrid()
    {
        AddCornerImages(tileTL, tileTR, tileBR, tileBL);
        AddBorderImages(tileL, tileR, tileT, tileB);
        AddRandomInnerImage(tile1, tile2, tile3);
    }

    public Grid GetGrid()
    {
        return _grid;
    }

    public int GetCellSize()
    {
        return _cellSize;
    }

    public int GetNumRows()
    {
        return _numRows;
    }

    public int GetNumColumns()
    {
        return _numColumns;
    }

    public void GenOverlayGrid()
    {

    }
}



