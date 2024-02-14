using System.Drawing;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;
using SpaceInvader.Models;
using SpaceInvader.ViewModel;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.System;

namespace SpaceInvader;

public sealed partial class Game : Page
{
    Image BulletImg;
    GameViewModel viewModel = new GameViewModel();
    private DispatcherTimer bulletTimer;
    public Game()
    {
        this.InitializeComponent();
    }

    private void Canvas_KeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        
        var Ship = ((GameViewModel)DataContext).Ship; 
        switch(e.Key) { 
            case VirtualKey.Right:
                if (Ship.PositionX + 10 > 1100) return; //Si llega al límite derecho establecido, no se seguirá moviendo.
                Ship.PositionX += 10;
                //ShipSoundEffect();
                break;
            case VirtualKey.Left:
                if (Ship.PositionX- 10 < 0) return;//Si llega al límite izquierdo establecido, no se seguirá moviendo.
                Ship.PositionX -= 10;
                ShipSoundEffect();

                break;
            case VirtualKey.Space:
                if (Ship.isShooting == true) return; // Si está disparando, no ejecutará ningún disparo
                ShootGenerator(Ship);
                break;
        }

    }
    public void ShootGenerator(Ship ship)
    {
        ship.isShooting = true;
        var bullet = ((GameViewModel)DataContext).Bullet;
        string imageSource = bullet.IconRoute;
        BulletImg = new Image
        {
            Width = 30,
            Height = 30,
            Source = new BitmapImage(new Uri(imageSource))
        };

        var positionX = ship.PositionX + 6;
        var positionY = ship.PositionY - 15;
        Canvas.SetLeft(BulletImg, positionX);
        Canvas.SetTop(BulletImg, positionY);
        GameCanvas.Children.Add(BulletImg);

        bulletTimer = new DispatcherTimer(); 
        bulletTimer.Tick += BulletTimer_Tick; //Subscripción al evento que ocurrirá.
        bulletTimer.Interval = TimeSpan.FromMilliseconds(100);//Intervalo de tiempo definido entre cada tick.
        bulletTimer.Start();

    }
    private void BulletTimer_Tick(object sender, object e)
    {
        MoveBullet();
    }
    public void MoveBullet()
    {
        var bulletShooted = ((GameViewModel)DataContext).Bullet;
        var Ship = ((GameViewModel)DataContext).Ship;
        bulletShooted.PositionY -= 10;
        Canvas.SetTop(BulletImg, bulletShooted.PositionY);

        if (bulletShooted.PositionY <= -30) //Si la bala ha llegado al límite establecido, se detendrá 
        {
            bulletTimer.Stop();
            GameCanvas.Children.Remove(BulletImg);
            ((GameViewModel)DataContext).Ship.isShooting = false;
            bulletShooted.PositionY = Ship.PositionY;

        }
        /*
        bulletTimer.Stop();
        GameCanvas.Children.Remove(BulletImg);
        ((GameViewModel)DataContext).Ship.isShooting = false;
        //bulletShooted.PositionY = Ship.PositionY;
        */
    }

    private void ShipSoundEffect()
    {
        MediaPlayer mediaPlayer = new MediaPlayer();
        MediaSource mediaSource = MediaSource.CreateFromUri(new Uri("D:\\Semestre III\\Programación III\\SpaceInvader\\SpaceInvader\\SpaceInvader\\Assets\\Sounds\\Ship_Shoot.mp3"));
        mediaPlayer.Source = mediaSource;
        mediaPlayer.Volume = 0.2f;
        mediaPlayer.Play();
    }

    /*
     * 
        while (bulletShooted.PositionY > -30) 
        {
            bulletShooted.PositionY -= 10;
            Canvas.SetTop(BulletImg, bulletShooted.PositionY);
        }

        if (bulletShooted.PositionY > -30) //Si la bala ha llegado al límite establecido, se detendrá 
        {
            bulletTimer.Stop();
            GameCanvas.Children.Remove(Bullet);
            ((GameViewModel)DataContext).Ship.isShooting = false;
        }   
    */

}
