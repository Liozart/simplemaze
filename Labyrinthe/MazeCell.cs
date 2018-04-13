using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

enum ArianeThread
{
    None, Horizontal, Vertical
}

namespace Labyrinthe
{
    [System.Serializable]
    class MazeCell : Object
    {
        PictureBox _display;

        public PictureBox Display
        {
            get { return _display; }
            set { _display = value;
                _display.Width = 25;
                _display.Height = 25;
            }
        }

        Graphics g;
        Pen p;

        //VARS - GETTER SETTER
            //IS A WALL

        bool _isAWall;

        public bool IsAWall
        {
            get { return _isAWall; }
            set { _isAWall = value; }
        }

            //ARIANE THREAD
            //DON'T ACTUALLY WORL
        ArianeThread aria = ArianeThread.None;

        internal ArianeThread Aria
        {
            get { return aria; }
            set { aria = value;
                  switch (Aria)
                  {
                      case ArianeThread.Horizontal:
                          g.DrawLine(p, new Point(this._display.Location.X, this._display.Location.Y + 12), 
                              new Point(this._display.Location.X + 25, this._display.Location.Y + 12)); 
                          break;
                      case ArianeThread.Vertical:
                          g.DrawLine(p, new Point(this._display.Location.X + 12, this._display.Location.Y), 
                              new Point(this._display.Location.X + 12, this._display.Location.Y + 25)); 
                          break;
                  }
            }
        }
     
        //CONSTRUCTOR
        public MazeCell()
        {
            this.Display = new PictureBox();
            g = this.Display.CreateGraphics();
            p = new Pen(Brushes.Red);
        }
    }
}
