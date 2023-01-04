
using TerraNova3.Models;
namespace TerraNova3;

public partial class Game : ContentPage
{
    TileSet tiles;
    Boolean running;
    Grid overlay;
    Grid grid;



    public Game()
    {
        InitializeComponent();
        Init();
    }
    public void Init()
    {
        int pn = Preferences.Get("PlantsNumber", 10);
        int hn = Preferences.Get("HerbivoresNumber", 10);
        int cn = Preferences.Get("CarnivoresNumber", 10);
        int size = Preferences.Get("Size", 10);

        tiles = new TileSet(pn, hn, cn, size);

        overlay = tiles.getOverlay().GetGrid();
        grid = tiles.getBackground();
        tiles.update();

        Layout.Add(grid);
        Layout.Add(overlay);

    }

    public void OnBackClicked(object sender, EventArgs e)

    {
        running = false;
        Application.Current.MainPage.Navigation.PushModalAsync(new MainPage(), true);
    }
    public void OnRun(object sender, EventArgs e)

    {
        running = true;
        Start();

    }
    public void OnPause(object sender, EventArgs e)

    {
        running = false;

    }
    public void OnStep(object sender, EventArgs e)
    {
        tiles.update();
    }
    void OnZoomIn(object sender, EventArgs e)
    {
        Layout.Scale = Layout.Scale * 1.1;
    }
    void OnZoomOut(object sender, EventArgs e)
    {
        Layout.Scale = Layout.Scale / 1.1;
    }

    void Step()
    {
        tiles.update();
    }
    public async void Start()
    {

        while (running)
        {
            tiles.update();
            await Task.Delay(8);
        }
    }
}