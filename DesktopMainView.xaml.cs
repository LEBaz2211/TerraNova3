namespace TerraNova3;

public partial class DesktopMainView : ContentView
{
	public DesktopMainView()
	{
		InitializeComponent();
	}
    private void OnPlayClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new Game(), true);
    }
    private void OnLoadClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new PreGame(), true);
    }
}
