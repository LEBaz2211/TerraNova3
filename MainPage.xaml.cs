namespace TerraNova3;

public partial class MainPage : ContentPage
{
    

    public MainPage()
    {
        InitializeComponent();
        if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
        {
            MainGrid.Add(new MobileMainView());
        }

        else
        {
            MainGrid.Add(new DesktopMainView());
        }
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

