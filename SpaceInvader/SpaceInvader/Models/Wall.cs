using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvader.ViewModel;

namespace SpaceInvader.Models;
public class Wall: ViewModelBase
{
    private int _positionX;
    private int _positionY;
    public string IconRoute { get; set; }

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
