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
    public partial class MazeViewHome : Form
    {
        MazeController _controller;
        public MazeViewHome()
        {
            InitializeComponent();
            _controller = new MazeController(this);
        }
        //EVENTS

        //NEW GAME BUTTON
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            _controller.ShowConfig();
        }

        //LOAD BUTTON
        private void btnLoad_Click(object sender, EventArgs e)
        {
            _controller.LoadMaze();
        }

        //ABOUT BUTTON
        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application Conçue par Léo Pichat");
        }

        private void MazeViewHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
