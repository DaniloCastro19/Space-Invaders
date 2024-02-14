using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.ViewModel;

namespace SpaceInvader.Models;
public class Bullet: ViewModelBase
{ 
    public string IconRoute { get; set; }

    private int _positionX;
    public int _positionY;

    public int PositionX
    {
        get { return _positionX; }
        set
        {
            if (_positionX != value)
            {
                _positionX = value;
                OnPropertyChanged(nameof(PositionX));
            }
        }
    }

    public int PositionY
    {
        get { return _positionY; }
        set
        {
            if (_positionY != value)
            {
                _positionY = value;
                OnPropertyChanged(nameof(PositionY));
            }
        }
    }
}
