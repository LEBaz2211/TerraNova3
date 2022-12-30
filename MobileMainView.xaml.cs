namespace TerraNova3;

public partial class MobileMainView : ContentView
{
	public MobileMainView()
	{
		InitializeComponent();
	}
    private void OnPlayClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new PreGame(), true);
    }
    private void OnLoadClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new PreGame(), true);
    }
}
