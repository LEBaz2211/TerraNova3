using System;
using Microsoft.Maui.Controls;
using TerraNova3.View_Models;
using TerraNova3.Models;

using TerraNova3.Model;


namespace TerraNova3;

public partial class TestOutput : ContentPage
{
    TileSet tiles;
    Boolean running;



    public TestOutput()
	{
		InitializeComponent();
        int pn = Preferences.Get("PlantsNumber", 0);
        int hn = Preferences.Get("HerbivoresNumber", 0);
        int cn = Preferences.Get("CarnivoresNumber", 0);

        tiles = new TileSet(pn, hn, cn, 20);

        Grid overlay = tiles.getOverlay().GetGrid();
        
        tiles.update();

        Grid grid = tiles.getBackground();
        

        //P.Text = pn.ToString();
        //H.Text = hn.ToString();
        C.Text = cn.ToString();

        
        


        // Create a list of all the positions in the grid





        Layout.Add(grid);
        Layout.Add(overlay);


    }

    public void OnBackClicked(object sender, EventArgs e)

    {
        running = false;
        Application.Current.MainPage.Navigation.PushModalAsync(new PreGame(), true);
    }
    public void OnFillClicked(object sender, EventArgs e)

    {
        running = true;
        Start();

    }
    public void OnClearClicked(object sender, EventArgs e)
    {


        


    }
    public async void Start()
    {

        while (running)
        {

            // Update Game at 60fps
            tiles.update();
            Plant plant = tiles.plnts.GetEntities()[0] as Plant;
            P.Text = tiles.pFood.GetEntities().Count.ToString();
            H.Text = tiles.plnts.GetEntities().Count.ToString();
            await Task.Delay(8);
        }
    }
}
