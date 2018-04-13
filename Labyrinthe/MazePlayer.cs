using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Labyrinthe
{
    [System.Serializable]
    public class MazePlayer : Object
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

        //CONSTRUCTOR
        public MazePlayer()
        {
            this.Display = new PictureBox();
        }
    }
}
