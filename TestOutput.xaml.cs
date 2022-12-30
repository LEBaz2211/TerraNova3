using System;
using Microsoft.Maui.Controls;
using TerraNova3.View_Models;
using TerraNova3.Models;
namespace TerraNova3;

public partial class TestOutput : ContentPage
{
    Microsoft.Maui.Controls.Grid grid = new Microsoft.Maui.Controls.Grid();
    Microsoft.Maui.Controls.Grid overlay = new Microsoft.Maui.Controls.Grid();
    List<Image> imposters;

    public TestOutput()
	{
		InitializeComponent();
        int pn = Preferences.Get("PlantsNumber", 0);
        int hn = Preferences.Get("HerbivoresNumber", 0);
        int cn = Preferences.Get("CarnivoresNumber", 0);

        P.Text = pn.ToString();
        H.Text = hn.ToString();
        C.Text = cn.ToString();
        
        TerraGrid gridGen = new TerraGrid(20, 20);
        OverlayGrid overlayGrid = new OverlayGrid(gridGen);
        
        gridGen.GenerateGrid();

        Grid grid = gridGen.GetGrid();
        Grid overlay = overlayGrid.GetGrid();
        

        // Create a list of all the positions in the grid
        List<(int, int)> positions = new List<(int, int)>();
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                positions.Add((x, y));
            }
        }

        // Shuffle the list of positions
        Random rnd = new Random();
        for (int i = positions.Count - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            (int, int) temp = positions[i];
            positions[i] = positions[j];
            positions[j] = temp;
        }

        for (var i = 0;i< pn;i++)
        {
            Image image = new Image();
            image.Source = "plant.png";
            overlayGrid.AddEntity(new Entity(positions[i].Item1, positions[i].Item2, image));
        }
        for (var i = pn; i < hn+pn; i++)
        {
            Image image = new Image();
            image.Source = "herbivores.png";
            overlayGrid.AddEntity(new Entity(positions[i].Item1, positions[i].Item2, image));
        }
        for (var i = hn + pn; i < hn + pn + cn; i++)
        {
            Image image = new Image();
            image.Source = "carnivores.png";
            overlayGrid.AddEntity(new Entity(positions[i].Item1, positions[i].Item2, image));
        }




        Layout.Add(grid);
        Layout.Add(overlay);


    }

    public void OnBackClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new PreGame(), true);
    }
    public void OnFillClicked(object sender, EventArgs e)

    {
        
        foreach (Image child in imposters)
        {
            overlay.Children.Append(child);

        }

    }
    public void OnClearClicked(object sender, EventArgs e)
    {

        
        foreach(Image child in overlay.Children.ToList()){
            overlay.Children.Remove(child);
        }



    }
}
