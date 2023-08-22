using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    internal class GameGrid
    {
        public GameCell[,] Cells;
        public int Rows;
        public int Columns;

        public GameGrid(int Rows,int Columns,string path)
        {
            this.Rows = Rows;
            this.Columns = Columns;
            Cells = new GameCell[Rows, Columns];
            LoadGrid(path);
        }

        public GameCell GetCell(int Row,int Col)
        {
            return Cells[Row, Col];
        }

        public void LoadGrid(string path)
        {
            if(File.Exists(path))
            {
                int rows = 0; 
                string record = "";
                StreamReader file = new StreamReader(path);
                while((record = file.ReadLine()) != null)
                {
                    for (int i = 0; i < Columns; i++) 
                    {
                        GameCell C = new GameCell(rows,i,this);
                        GameObject gameObject = new GameObject(record[i], GameObject.GetObjectType(record[i]));
                        C.gameObject = gameObject;
                        if (C != null)
                        {
                            Cells[rows, i] = C;
                        }
                    }
                    rows++;
                }
                file.Close();
            }
        }
    }
}
