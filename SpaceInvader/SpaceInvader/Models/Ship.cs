using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.ViewModel;

namespace SpaceInvader.Models;
public class Ship: ViewModelBase
{
    public int Lives { get; set; }
    public string IconRoute { get; set; }
    private int _positionX;
    public int PositionY { get; set; }
    public bool isShooting { get; set; }

    
    public int PositionX
    {
        get { return _positionX; }
        set
        {
            if(_positionX != value)
            {
                _positionX = value;
                OnPropertyChanged(nameof(PositionX));
            }
        }
    }
}
