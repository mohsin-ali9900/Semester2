using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacMan.GameGL;
using EZInput;
using PacManGUI.GameGL;

namespace PacManGUI
{
    public partial class Form1 : Form
    {
        GamePacManPlayer pacman;
        Ghost hg;
        Ghost vg;
        Ghost rg;
        Ghost sg;
        int score = 0;
        List<Ghost> listGhost = new List<Ghost>();
        public Form1()
        {
            InitializeComponent();
        }

       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            GameGrid grid = new GameGrid("maze.txt", 24, 71);
            Image pacManImage = Game.getGameObjectImage('P');
            Image HghostImage = Game.getGameObjectImage('H');
            Image VghostImage = Game.getGameObjectImage('V');
            Image RghostImage = Game.getGameObjectImage('R');
            Image SghostImage = Game.getGameObjectImage('S');
            GameCell startCell = grid.getCell(8, 10)   ;
            GameCell startCellGH = grid.getCell(4, 4)  ;
            GameCell startCellVG = grid.getCell(10, 20);
            GameCell startCellRG = grid.getCell(9, 56) ;
            GameCell startCellSG = grid.getCell(3, 3)  ;
            pacman = new GamePacManPlayer(pacManImage, startCell);
            hg = new HorizontalGhost(HghostImage, startCellGH)   ;
            vg = new VerticalGhost(VghostImage, startCellGH)     ;
            rg = new RandomGhost(RghostImage, startCellRG)       ;
            sg = new SmartGhost(SghostImage, startCellSG,pacman) ;
            printMaze(grid);
            listGhost.Add(hg);
            listGhost.Add(vg);
            listGhost.Add(rg);
            listGhost.Add(sg);
        }



        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
               
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);          
            //        printCell(cell);
                }

            }
        }

        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }
     

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyPressed(Key.LeftArrow)) 
            {
                GameCell c1 = pacman.move(GameDirection.Left);
                pacmanCollision(c1);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                GameCell c1 = pacman.move(GameDirection.Right);
                pacmanCollision(c1);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                GameCell c1 = pacman.move(GameDirection.Up);
                pacmanCollision(c1);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                GameCell c1 = pacman.move(GameDirection.Down);
                pacmanCollision(c1);
            }
            
            foreach (var g in listGhost)
            {
                GameCell cell = g.move();
                ghostCollision(cell);
            }
        }
        private void pacmanCollision(GameCell cell)
        {
            if(cell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                addScore();
            }
            if(cell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
            {
                gameLoop.Stop();
            }
        }
        private void ghostCollision(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                gameLoop.Stop();
            }
        }
        private void addScore()
        {
            score++;
            lblscore.Text = "Score : " + score;
        }
    }
}
