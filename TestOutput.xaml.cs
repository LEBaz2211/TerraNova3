using System;
using Microsoft.Maui.Controls;
using TerraNova3.View_Models;
using TerraNova3.Models;
using TerraNova3.Model;

namespace TerraNova3;

public partial class TestOutput : ContentPage
{
    TileSet tiles;



    public TestOutput()
	{
		InitializeComponent();
        int pn = Preferences.Get("PlantsNumber", 0);
        int hn = Preferences.Get("HerbivoresNumber", 0);
        int cn = Preferences.Get("CarnivoresNumber", 0);

        tiles = new TileSet(pn, hn, cn, 20);


        OverlayGrid overlayGrid = tiles.getOverlay();
        List<(int, int)> positions = overlayGrid.GetRandomPositions();

        for (var i = 0; i < pn; i++)
        {
            Image image = new Image();
            image.Source = "plant.png";
            tiles.plnts.add(new Plant(positions[i].Item1, positions[i].Item2, image));
        }
        for (var i = pn; i < hn + pn; i++)
        {
            Image image = new Image();
            image.Source = "herbivores.png";
            tiles.herbs.add(new Herbivore(positions[i].Item1, positions[i].Item2, image));
        }
        for (var i = hn + pn; i < hn + pn + cn; i++)
        {
            Image image = new Image();
            image.Source = "carnivores.png";
            tiles.apexs.add(new Predator(positions[i].Item1, positions[i].Item2, image));
        }

        
        tiles.update();

        Grid grid = tiles.getBackground();
        Grid overlay = tiles.getOverlay().GetGrid();

        P.Text = pn.ToString();
        H.Text = hn.ToString();
        C.Text = cn.ToString();

        
        

        // Create a list of all the positions in the grid
        




        Layout.Add(grid);
        Layout.Add(overlay);


    }

    public void OnBackClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new PreGame(), true);
    }
    public void OnFillClicked(object sender, EventArgs e)

    {

        tiles.update();

    }
    public void OnClearClicked(object sender, EventArgs e)
    {


        


    }
}
