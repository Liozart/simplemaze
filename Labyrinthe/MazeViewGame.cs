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
    public partial class MazeViewGame : Form
    {

        //VARS - GETTER/SETTER
        MazeController _controller;
        public MazeViewGame(MazeController control)
        {
            InitializeComponent();
            this._controller = control;
            this.KeyPreview = true;
            
        }

        //EVENTS : MENUBAR
            //QUIT
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter?", "Quitter", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
            //NEW GAME
        private void nouvelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ShowConfig();
        }
            //SAVE
        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.SaveMaze();
        }
            //LOAD
        private void chargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.LoadMaze();
        }

        //FILL THE PANEL WITH WALLS / EMPTY THE PANEL WITH 
        private void chxVoid_CheckedChanged(object sender, EventArgs e)
        {
            if (chxVoid.Checked) { _controller.Toggle_ToVoid(); }
            else { _controller.Toggle_ToWalls(); }
        }

        private void MazeViewGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //BUTTONS WILL REPLACE THE KEYPRESS EVENT WHO ISN'T ACTUALLY WORKING
        private void btnUp_Click(object sender, EventArgs e)
        {
            _controller.MovePlayer(Keys.Up);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            _controller.MovePlayer(Keys.Left);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            _controller.MovePlayer(Keys.Right);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            _controller.MovePlayer(Keys.Down);
        }

        //THE KEYPRESS EVENTS DIDN'T WORK ON GAME FORM, SO THIS CODE FOR KEYS HANDLE  WAS FOUND ON STACKOVERFLOW
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Up))
            {
                _controller.MovePlayer(Keys.Up);
                return true;
            }
            if (keyData == (Keys.Left))
            {
                _controller.MovePlayer(Keys.Left);
                return true;
            }
            if (keyData == (Keys.Right))
            {
                _controller.MovePlayer(Keys.Right);
                return true;
            }
            if (keyData == (Keys.Down))
            {
                _controller.MovePlayer(Keys.Down);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
