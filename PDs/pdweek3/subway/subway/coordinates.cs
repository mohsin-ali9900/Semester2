using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwaySurf
{
    internal class coordinates
    {
        public int JX = 20;
        public int JY = 20;
        public int GX = 100;
        public int GY = 5;

        public coordinates()
        {

        }

        public void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public void printJack(char[,] jack)
        {
            for (int row = 0; row < 3; row++)
            {
                gotoxy(JX, JY + row);
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(jack[row, col]);
                }
            }
        }
        public void printGlados(char[,] glados)
        {
            for (int rows = 0; rows < 4; rows++)
            {
                gotoxy(GX, GY + rows);
                for (int col = 0; col < 5; col++)
                {
                    Console.Write(glados[rows, col]);
                }
            }
        }
        public void erazeJack()
        {
            for (int row = 0; row < 3; row++)
            {
                gotoxy(JX, JY + row);
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" ");
                }
            }
        }
        public void erazeGlados()
        {
            for (int row = 0; row < 4; row++)
            {
                gotoxy(GX, GY + row);
                for (int col = 0; col < 5; col++)
                {
                    Console.Write(" ");
                }
            }
        }
        public void moveRight(char[,] maze, char[,] jack)
        {
            if (maze[JY, JX + 3] == ' ')
            {
                erazeJack();
                JX++;
                printJack(jack);
            }
        }

        public void moveLeft(char[,] maze, char[,] jack)
        {
            if (maze[JY - 0, JX - 1] == ' ')
            {
                erazeJack();
                JX--;
                printJack(jack);
            }
        }

        public void moveUp(char[,] maze, char[,] jack)
        {
            if (maze[JY - 1, JX - 0] == ' ')
            {
                erazeJack();
                JY--;
                printJack(jack);
            }
        }

        public void moveDown(char[,] maze, char[,] jack)
        {
            if (maze[JY + 3, JX + 0] == ' ')
            {
                erazeJack();
                JY++;
                printJack(jack);
            }
        }
        public void moveGlados(char[,] glados, char[,] maze, ref string gladosDirection)
        {
            if (gladosDirection == "down")
            {
                if (maze[GY + 4, GX] == ' ')
                {
                    erazeGlados();
                    GY++;
                    printGlados( glados);
                }
                else
                {
                    gladosDirection = "up";
                }
            }

            if (gladosDirection == "up")
            {
                if (maze[GY - 1,GX] == ' ')
                {
                    erazeGlados();
                    GY--;
                    printGlados(glados);
                }
                else
                {
                    gladosDirection = "down";
                }
            }
        }
        public void generateBullet(List<bullet> bb,  char[,] maze)
        {
            char next = maze[JY + 5, JX];
            if (next == ' ')
            {
                bullet bul = new bullet();
                bul.bulletX = JX + 5;
                bul.bulletY = JY;
                bul.isBulletActive = true;
                bb.Add(bul);
                gotoxy(JX + 5,JY + 1);
                Console.Write(".");
            }

        }
        public void printBullet(int x, int y)
        {
            gotoxy(x, y);
            Console.Write(".");
        }
        public void eraseBullet(int x, int y)
        {
            gotoxy(x, y);
            Console.Write(" ");
        }
        public void moveBullet(List<bullet> bul,  char[,] maze)
        {
            for (int i = 0; i < bul.Count; i++)
            {
                if (bul[i].isBulletActive == true)
                {
                    char nextlocation = maze[bul[i].bulletY + 1, bul[i].bulletX + 1];
                    if (nextlocation == ' ')
                    {
                        eraseBullet(bul[i].bulletX, bul[i].bulletY + 1);
                        bul[i].bulletX++;
                        printBullet(bul[i].bulletX, bul[i].bulletY + 1);
                    }
                    else
                    {
                        eraseBullet(bul[i].bulletX, bul[i].bulletY + 1);
                        bul[i].isBulletActive = false;
                    }
                }
            }
        }
        public void bulletCollisionWithGlados(char[,] maze, List<bullet> bul, ref int score)
        {
            for (int i = 0; i < bul.Count; i++)
            {
                if (bul[i].isBulletActive == true)
                {
                    if (bul[i].bulletX + 1 == GX && (bul[i].bulletY + 1 == GY || bul[i].bulletY + 1 == GY + 1 || bul[i].bulletY + 1 == GY + 2 || bul[i].bulletY + 1 == GY + 3))
                    {
                        score = score + 1;
                    }
                    printScore(ref score);
                }
            }
        }
        public void printScore(ref int score)
        {
            gotoxy(100, 35);
            Console.WriteLine("Score: {0}", score);
        }
    }

}
