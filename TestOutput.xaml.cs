using System;
using Microsoft.Maui.Controls;
using TerraNova2._0.View_Models;

namespace TerraNova2._0;

public partial class TestOutput : ContentPage
{
    Microsoft.Maui.Controls.Grid grid = new Microsoft.Maui.Controls.Grid();
    Microsoft.Maui.Controls.Grid overlay = new Microsoft.Maui.Controls.Grid();
    List<Image> imposters;

    public TestOutput()
	{
		InitializeComponent();
        P.Text = Preferences.Get("PlantsNumber",0).ToString();
        H.Text = Preferences.Get("HerbivoresNumber", 0).ToString();
        C.Text = Preferences.Get("CarnivoresNumber", 0).ToString();


        /*        var i = 20;
                var j = 20;


                grid.WidthRequest = 40*j;
                overlay.WidthRequest = 40 * j;


                for (var m = 0; m < i; m++)
                {
                    grid.RowDefinitions.Add(new RowDefinition());
                    overlay.RowDefinitions.Add(new RowDefinition());
                }
                for (var n = 0; n < j; n++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                    overlay.ColumnDefinitions.Add(new ColumnDefinition());
                }
                for (var m =0; m<i; m++)
                {
                    for (var n = 0; n < j; n++)
                    {
                        Image grass = new Image();

                        grass.Source = "tile1.png";

                        grass.WidthRequest = 40;
                        grass.HeightRequest = 40;
                        grid.SetRow(grass, m);
                        grid.SetColumn(grass, n);
                        grid.Children.Add(grass);
                        Image imposter = new Image();

                        imposter.Source = "dotnet_bot.png";

                        imposter.WidthRequest = 40;
                        imposter.HeightRequest = 40;
                        imposters[-1] = imposter;



                    }
                }*/

        TerraGrid gridGen = new TerraGrid(20, 20);
        gridGen.GenerateGrid();

        Grid grid = gridGen.GetGrid();

        Layout.Add(grid);
        //Layout.Add(overlay);




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
