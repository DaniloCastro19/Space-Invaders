using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.Models;

namespace SpaceInvader.ViewModel;
public class GameViewModel : ObservableObject
{
    private Ship _ship;
    private Bullet _bullet;
    private ObservableCollection<Enemy> _enemies;
    private ObservableCollection<Wall> _walls;
    public Ship Ship
    {
        get => _ship;
        set { SetProperty(ref _ship, value); }
    }

    public Bullet Bullet
    {
        get => _bullet;
        set { SetProperty(ref _bullet, value); }
    }
    public ObservableCollection<Wall> Walls
    {
        get => _walls;
        set { SetProperty(ref _walls, value); }
    }
    public ObservableCollection<Enemy> Enemies
    {
        get => _enemies;
        set { SetProperty(ref _enemies, value); }
    }
    public GameViewModel()
    {
        Ship = new Ship
        {
            IconRoute = "D:\\Semestre III\\Programación III\\SpaceInvader\\SpaceInvader\\SpaceInvader\\Assets\\Images\\baseshipa.ico",
            isShooting = false,
            PositionX = 550,
            PositionY = 450
        };

        Bullet = new Bullet
        {
            IconRoute = "D:\\Semestre III\\Programación III\\SpaceInvader\\SpaceInvader\\SpaceInvader\\Assets\\Images\\Bullet.png",
            PositionX = Ship.PositionX + 6,
            PositionY = Ship.PositionY - 10
        };

        EnemiesMatrixGenerator();
        WallsGenerator();
        
    }
    public void EnemiesMatrixGenerator() 
    {
        //Generación de la matriz de enemigos.
        Enemies = new ObservableCollection<Enemy>();

        int rows = 4;
        int cols = 11;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Enemies.Add(new Enemy
                {
                    IconRoute = "D:\\Semestre III\\Programación III\\SpaceInvader\\SpaceInvader\\SpaceInvader\\Assets\\Images\\saucer2a.ico",
                    PositionX = j * 80,//Acá se ajusta la posición en X y en cada iteración la distancia entre objetos se hace más grande.
                    PositionY = i * 60 //Acá se ajusta la posición en Y y mediante cada iteración del primer ciclo se aumenta la distancia entre objetos.
                });
            }
        }
    }
    public void WallsGenerator()
    {
        Walls = new ObservableCollection<Wall>();

        //Generación de barreras.
        for (int i = 0; i < 4; i++)
        {
            Walls.Add(new Wall
            {
                IconRoute = "D:\\Semestre III\\Programación III\\SpaceInvader\\SpaceInvader\\SpaceInvader\\Assets\\Images\\Barrier.jpeg",
                PositionX = i * 350, //Posición en el eje X (Aumenta en cada iteración dando más posición a la siguiente barrera)
                PositionY = 380
            });
        }
    }
}
