using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Labyrinthe
{
    public class MazeController
    {
        //VARS - GETTER/SETTER
        MazeViewConfig _config;
        MazeModel _model;
        MazeViewGame _game;
        MazeViewHome _mazeViewHome;
        Panel panel;

        public Panel Panel
        {
            get { return panel; }
            set { panel = value; }
        }

        //CONSTRUCTOR

        public MazeController(MazeViewHome mazeViewHome)
        {
            _mazeViewHome = mazeViewHome;
        }

        public MazeController(MazeViewGame mazeViewGame)
        {
            _game = mazeViewGame;
        }

        //METHODS
            //CREATE THE ADAPTED MODEL FOR THE MAZE CREATION
        public void GenModel(bool border, int wid, int hei, Color cell, Color player)
        {
             this._model = new MazeModel();
             this._model.MazeWidth = wid;
             this._model.MazeHeight = hei;
             this._model.ColorCellWall = cell;
             this._model.ColorPlayer = player;
             this._model.Border = border;
        }

            //GENERATE THE MAZE AND SEND IT TO THE GAME FORM
        public void GenMaze()
        {
            _game = new MazeViewGame(this);
            Panel = _model.GenMaze();
            _game.Controls.Add(Panel);
            _game.Size = new Size(Panel.Width + 200, Panel.Height + 150);
            _game.ShowDialog();
            _game.Focus();
            
        }

            //MOVE THE PLAYER CELL BY CELL
        public Point MovePlayer(Keys input)
        {
            switch(input)
            {
                case Keys.Up: return _model.MovePlayer(Direction.Top);
                    break;
                case Keys.Down: return _model.MovePlayer(Direction.Bottom);
                    break;
                case Keys.Left: return _model.MovePlayer(Direction.Left);
                    break;
                case Keys.Right: return _model.MovePlayer(Direction.Right);
                    break;
                default: return new Point(0, 0);
            }
        }

        //WALLS MODIFICATION METHODS
        public void Toggle_ToWalls()
        {
            _model.Toggle_ToWalls();
        }

        public void Toggle_ToVoid()
        {
            _model.Toggle_ToVoid();
        }

        //SAVE A MAZE FROM BINARY FORMAT
        public void SaveMaze()
        {
            string g = Microsoft.VisualBasic.Interaction.InputBox("Entrez le nom du labyrinthe (Ne sauvegarde que la structure)");
            g += ".maze";
            FileStream file = File.Open(g, FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(file, this._model.ArrayOfPosition);
            file.Close();
            
        }
        //LOAD A MAZE FROM BINARY FORMAT
        public void LoadMaze()
        {
            string g = Microsoft.VisualBasic.Interaction.InputBox("Entrez le nom du labyrinthe à charger");
            g += ".maze";

            if (File.Exists(g))
            {
                FileStream fileOp = File.Open(g, FileMode.Open);
                BinaryFormatter serializer = new BinaryFormatter();
                byte[,] tmpArr = (byte[,])serializer.Deserialize(fileOp);

                //GET THE SELECTED MAZE STRUCTURE AND GENERATE IT WITH RANDOM COLOR
                Random _rand = new Random();
                Color _randCol = Color.FromArgb(_rand.Next(0, 255), _rand.Next(0, 255), _rand.Next(0, 255));
                this.GenModel(true, tmpArr.GetLength(0), tmpArr.GetLength(1), _randCol, Color.Red); 
                this._model.ArrayOfPosition = tmpArr;
                this.GenMaze();
                fileOp.Close();
            }
        }

        //CALL THE CONFIGURATION FORM
        internal void ShowConfig()
        {
            _config = new MazeViewConfig(this);
            _config.ShowDialog();
        }
    }
}
