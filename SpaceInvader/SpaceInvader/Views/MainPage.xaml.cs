namespace SpaceInvader;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
        StartGameButton.Click += StartGame;
    }

    private void StartGame(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(Game));
    }

}
