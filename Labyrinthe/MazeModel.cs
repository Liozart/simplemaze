using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

public enum Direction
{
    Top, Bottom, Left, Right
}

public enum Messages
{
    Generation, Limits, Ending
}
namespace Labyrinthe
{
    [System.Serializable]
    public class MazeModel
    {
        #region vars
        //VARS - GETTER/SETTER
        //CONST
        public const int _CELLSIZE = 25;

        public int CELLSIZE
        {
            get { return _CELLSIZE; }
        }

        //PROPS
        int _mazeHeight;

        public int MazeHeight
        {
            get { return _mazeHeight; }
            set { _mazeHeight = value; }
        }

        int _mazeWidth;

        public int MazeWidth
        {
            get { return _mazeWidth; }
            set { _mazeWidth = value; }
        }

        Label lblTimer;

        bool _border;

        public bool Border
        {
            get { return _border; }
            set { _border = value; }
        }

        bool _wallStates = true;

        public bool WallStates
        {
            get { return _wallStates; }
            set { _wallStates = value; }
        }

        //COLORS
        Color _colorCellWall;

        public Color ColorCellWall
        {
            get { return _colorCellWall; }
            set { _colorCellWall = value; }
        }

        Color _colorPlayer;

        public Color ColorPlayer
        {
            get { return _colorPlayer; }
            set { _colorPlayer = value; }
        }

        Color _colorCell = Color.LightGray;

        public Color ColorCell
        {
            get { return _colorCell; }
            set { _colorCell = value; }
        }

        //REQUIRED ARRAYS
        byte[,] _arrayOfPosition;

        public byte[,] ArrayOfPosition
        {
            get { return _arrayOfPosition; }
            set { _arrayOfPosition = value; }
        }

            //THE UTILITY ARRAYS
        MazeCell[,] _arrayOfCells;

        internal MazeCell[,] ArrayOfCells
        {
            get { return _arrayOfCells; }
            set { _arrayOfCells = value; }
        }

        MazeCell[,] _arrayOfCellsOld;

        internal MazeCell[,] ArrayOfCellsOld
        {
            get { return _arrayOfCellsOld; }
            set { _arrayOfCellsOld = value; }
        }

        MazeCell[,] _arrayOfVoid;

        internal MazeCell[,] ArrayOfVoid
        {
            get { return _arrayOfVoid; }
            set { _arrayOfVoid = value; }
        }

        //CLASSES
        MazePlayer _player;
        MazeCell _newCell;

        #endregion

        //CONSTRUCTOR
        public MazeModel(bool border, int wid, int hei, Color cC, Color cP)
        {
            this.MazeHeight = hei;
            this.MazeWidth = wid;
            this.ColorCellWall = cC;
            this.ColorPlayer = cP;
            this.Border = border;
        }

        public MazeModel()
        {
        }

        #region methods

        //METHODS
        //GENERATION OF THE MAZE
        public Panel GenMaze()
        {
            Panel panel = new Panel();
            try
            {
                ArrayOfCells = new MazeCell[MazeHeight, MazeWidth];
                ArrayOfCellsOld = new MazeCell[MazeHeight, MazeWidth];
                ArrayOfPosition = new byte[_mazeHeight, MazeWidth];

                panel.Width = this.MazeWidth * this.CELLSIZE;
                panel.Height = this.MazeHeight * this.CELLSIZE;
                panel.Location = new Point(140, 30);

                //CREATION OF THE ARRAY FOR PATHS AND WALLS
                MazeCreator creator = new MazeCreator(this.MazeHeight, this.MazeWidth, new Point(1, 1));
                ArrayOfPosition = creator.CreateMaze();

                //CREATE, DRAW AND PLACE THE PLAYER
                _player = this.DrawPlayer();
                _player.Display.Location = new Point(0, _mazeHeight * CELLSIZE - CELLSIZE);
                panel.Controls.Add(_player.Display);
                //_player.Position = new int[_mazeHeight, MazeWidth];
                //_player.Position[0, MazeWidth-1] = 1;

                for (int rangee = 0; rangee < ArrayOfPosition.GetLength(0); rangee++)
                {
                    for (int colonne = 0; colonne < ArrayOfPosition.GetLength(1); colonne++)
                    {
                        _newCell = new MazeCell();
                        //THESE FOUR EXCEPTIONS ARE THE BEGINNIG AND THE END OF THE MAZE
                        ArrayOfPosition[0, ArrayOfPosition.GetLength(0) - 1] = 2;
                        ArrayOfPosition[0, ArrayOfPosition.GetLength(0) - 2] = 0;
                        ArrayOfPosition[ArrayOfPosition.GetLength(1) - 1, 0] = 2;
                        ArrayOfPosition[ArrayOfPosition.GetLength(1) - 1, 1] = 0;


                        switch (ArrayOfPosition[rangee, colonne])
                        {
                            //IF THE ARRAY IS 0, THE CELL ISN'T A WALL
                            case 0:
                                _newCell.Display.BackColor = ColorCell;
                                break;
                            //ELSE THE CELL IS A WALL
                            case 1:
                                _newCell.IsAWall = true;
                                _newCell.Display.BackColor = this.ColorCellWall;
                                break;
                            //OR THE BEGINNING OR THE END OF THE MAZE
                            case 2:
                                _newCell.Display.BackColor = Color.Purple;
                                break;
                        }
                        //PLACE THE CELL IN THE PANEL
                        _newCell.Display.Location = new Point(rangee * CELLSIZE, colonne * CELLSIZE);
                        //IF THE BORDER WAS CHECKED
                        if (Border)
                        {
                            _newCell.Display.BorderStyle = BorderStyle.FixedSingle;
                        }
                        else
                        {
                            _newCell.Display.BorderStyle = BorderStyle.None;
                        }
                        //ADD THE GENERATED PICTUREBOX TO THE PANEL
                        panel.Controls.Add(_newCell.Display);

                        //ADD THE NEW CREATED CELL IN THE GENERAL ARRAY AND THE RECOVER ARRAY
                        ArrayOfCells[rangee, colonne] = _newCell;
                        ArrayOfCellsOld[rangee, colonne] = _newCell;
                    }
                }
            }
            catch (Exception e)
            {
                CallMessage(Messages.Generation);
            }
            return panel;
        }

            //THE PLAYER CAN NO LONGER GO THROUGH WALSS
        public void Toggle_ToWalls()
        {
            ArrayOfCells = ArrayOfCellsOld;
            _player.Display.BackColor = this.ColorPlayer;
        }
            //FOR THE PLAYER PASSING THROUGH THE WALLS
        public void Toggle_ToVoid()
        {
            this.ArrayOfVoid = new MazeCell[MazeHeight, MazeWidth];
            for (int rangee = 0; rangee < ArrayOfPosition.GetLength(0); rangee++)
            {
                for (int colonne = 0; colonne < ArrayOfPosition.GetLength(1); colonne++)
                {
                    _newCell.IsAWall = false;
                    ArrayOfVoid[rangee, colonne] = _newCell;
                }
            }
            ArrayOfCells = ArrayOfVoid;

            string newCol = "Light";
            newCol += this.ColorPlayer.Name;
            _player.Display.BackColor = Color.FromName(newCol);
        }

        //MOVE THE PLAYER AROUND THE PANEL
        public Point MovePlayer(Direction direction)
        {
            switch (direction)
            {
                case Direction.Bottom:
                    try
                    {
                        //TEST IF THE PLAYER IS ON THE BORDER OF THE PANEL
                        if (ArrayOfCells[_player.Display.Location.X / CELLSIZE,
                                _player.Display.Location.Y / CELLSIZE + 1] == null){}
                        else
                        {
                            if (!ArrayOfCells[_player.Display.Location.X / CELLSIZE,
                                    _player.Display.Location.Y / CELLSIZE + 1].IsAWall)
                            {
                                _player.Display.Location = new Point(_player.Display.Location.X, _player.Display.Location.Y + CELLSIZE);
                                ArrayOfCells[_player.Display.Location.X / CELLSIZE, _player.Display.Location.Y / CELLSIZE].Aria = ArianeThread.Vertical;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        CallMessage(Messages.Limits);
                    }
                    break;

                case Direction.Top:
                    try
                    {   
                        //TEST IF THE PLAYER IS ON THE BORDER OF THE PANEL
                        if (ArrayOfCells[_player.Display.Location.X / CELLSIZE,
                                _player.Display.Location.Y / CELLSIZE - 1] == null){}
                        else
                        {
                            if (!ArrayOfCells[_player.Display.Location.X / CELLSIZE,
                                   _player.Display.Location.Y / CELLSIZE - 1].IsAWall)
                            {
                                //IF THE PLAYER IS ON THE ENDING CELLS
                                if (ArrayOfPosition[_player.Display.Location.X / CELLSIZE,
                                    _player.Display.Location.Y / CELLSIZE - 1] == 2)
                                {
                                    CallMessage(Messages.Ending);
                                }
                                _player.Display.Location = new Point(_player.Display.Location.X, _player.Display.Location.Y - CELLSIZE);
                                ArrayOfCells[_player.Display.Location.X / CELLSIZE, _player.Display.Location.Y / CELLSIZE].Aria = ArianeThread.Vertical;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        CallMessage(Messages.Limits);
                    }
                    break;

                case Direction.Left:
                    try
                    { 
                        //TEST IF THE PLAYER IS ON THE BORDER OF THE PANEL
                        if (ArrayOfCells[_player.Display.Location.X / CELLSIZE -1,
                                _player.Display.Location.Y / CELLSIZE] == null){}
                        else
                        {
                            if (!ArrayOfCells[_player.Display.Location.X / CELLSIZE - 1,
                                    _player.Display.Location.Y / CELLSIZE].IsAWall)
                            {
                                _player.Display.Location = new Point(_player.Display.Location.X - CELLSIZE, _player.Display.Location.Y);
                                ArrayOfCells[_player.Display.Location.X / CELLSIZE, _player.Display.Location.Y / CELLSIZE].Aria = ArianeThread.Horizontal;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        CallMessage(Messages.Limits);
                    }
                    break;

                case Direction.Right:
                    try
                    {
                        //TEST IF THE PLAYER IS ON THE BORDER OF THE PANEL
                        if (ArrayOfCells[_player.Display.Location.X / CELLSIZE + 1,
                                _player.Display.Location.Y / CELLSIZE] == null){}
                        else
                        {
                            if (!ArrayOfCells[_player.Display.Location.X / CELLSIZE + 1,
                                    _player.Display.Location.Y / CELLSIZE].IsAWall)
                            {
                                //IF THE PLAYER IS ON THE ENDING CELLS
                                if (ArrayOfPosition[_player.Display.Location.X / CELLSIZE + 1,
                                    _player.Display.Location.Y / CELLSIZE] == 2)
                                {
                                    CallMessage(Messages.Ending);
                                }
                                _player.Display.Location = new Point(_player.Display.Location.X + CELLSIZE, _player.Display.Location.Y);
                                ArrayOfCells[_player.Display.Location.X / CELLSIZE, _player.Display.Location.Y / CELLSIZE].Aria = ArianeThread.Horizontal;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        CallMessage(Messages.Limits);
                    }
                    break;
            }
            return new Point(_player.Display.Location.X, _player.Display.Location.Y);
        }

        //DRAW THE PLAYER
        public MazePlayer DrawPlayer()
        {
            MazePlayer newPlayer = new MazePlayer();
            newPlayer.Display.BackColor = this.ColorPlayer;
            return newPlayer;
        }

        //CALL ERRORS MESSAGE
        public void CallMessage(Messages current)
        {
            switch (current)
            {
                case Messages.Generation:
                    MessageBox.Show("Erreur lors de la génération", "Erreur");
                    break;
                case Messages.Limits:
                    MessageBox.Show("Vous sortez des limites", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Messages.Ending:
                    MessageBox.Show("Vous avez fini le labyrinthe", "GoodGame");
                    break;
            }
        }

        #endregion
    }
}