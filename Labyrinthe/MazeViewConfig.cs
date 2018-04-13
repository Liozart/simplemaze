using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labyrinthe
{
    public partial class MazeViewConfig : Form
    {
        MazeController _controller;
        public MazeViewConfig(MazeController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        //VARS / GETTER/SETTER

        Panel _panelCell;

        public Panel PanelCell
        {
            get { return _panelCell; }
            set { _panelCell = value; }
        }

            //TIME LIMITE CHECKED
        bool _isTime = false;

        public bool IsTime
        {
            get { return _isTime; }
            set { _isTime = value; }
        }

            //BORDER OPTION CHECKED
        bool _border = false;

        public bool Border
        {
            get { return _border; }
            set { _border = value; }
        }
            //DIMENSIONS
        int _mazeHeight = 5;

        public int MazeHeight
        {
            get { return _mazeHeight; }
            set { _mazeHeight = value; }
        }

        int _mazeWidth = 5;

        public int MazeWidth
        {
            get { return _mazeWidth; }
            set { _mazeWidth = value; }
        }

            //TEXTURES
        Color _colorCell;

        public Color ColorCell
        {
            get { return _colorCell; }
            set { _colorCell = value; }
        }

        Color _colorPlayer;

        public Color ColorPlayer
        {
            get { return _colorPlayer; }
            set { _colorPlayer = value; }
        }

            //CLASSES

        //EVENTS
        //  CREATE BUTTON
        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Border = chxBorder.Checked;
            this.MazeWidth = (int)numHeight.Value;
            this.MazeHeight = (int)numHeight.Value;

            //CREATE THE MODEL FOR THE NEW MAZE
            _controller.GenModel(Border, MazeWidth, MazeHeight, pcbColorCell.BackColor, pcbColorPlayer.BackColor);
            //GENERATE
            _controller.GenMaze();
        }


        //COLOR PICKING
            //CELL
        private void pcbColorCell_Click(object sender, EventArgs e)
        {
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                pcbColorCell.BackColor = colorPicker.Color;
            }
        }
            //PLAYER
        private void pcbColorPlayer_Click(object sender, EventArgs e)
        {
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                pcbColorPlayer.BackColor = colorPicker.Color;
            }
        }

        //EXIT
        private void MazeViewConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
