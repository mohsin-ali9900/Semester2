using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EZInput;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Data;
using System.Xml.Linq;

namespace SubwaySurf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char bigbox = '#';
            char smallbox = '#';
            char upbox = '#';
            char top = '^';

            char[,] jack = { { ' ', top, ' ' }, { smallbox, bigbox, smallbox }, { ' ', upbox, ' ' } };
            char[,] glados = { { '(', '-', ' ', '-', ')' }, { '<', '|', ' ', '|', '>' }, { ' ', '\\', '_', '/', ' ' }, { ' ', ' ', '.', ' ', ' ' } };

            /*int[] bulletX = new int[100];
            int[] bulletY = new int[100];
            bool[] isBulletActive = new bool[100];*/

            /*int bulletCount = 0;
            int gladosBulletCount = 0;
            int score = 0;
            int scoreG = 0;
            string direction;
            int deadCount1 = 0;
            int deadCount2 = 0;
            char atrate = '@';*/
            //char bull = 17;



            int jackx = 20;
            int jacky = 20;
            int gladosX = 100;
            int gladosY = 30;
            /*int jackHealth = 1000;
            int gladosHealth = 100;
            string gladosDirection = "Right";*/
            /*int[] gladosBulletX = new int[10000];
            int[] gladosBulletY = new int[10000];
            bool[] isGladosBulletActive = new bool[10000];*/

            char[,] maze = new char[34, 129];

            /*char option;
            bool isRunning = true;*/


            Console.Clear();
            readMaze(maze);
            
            printMaze(maze);
            printJack(ref jackx, ref jacky, jack);
            printGlados(ref gladosX, ref gladosY, glados);
            Console.ReadKey();

            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveUp(maze, ref jackx, ref jacky, jack);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveDown(maze, ref jackx, ref jacky, jack);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveLeft(maze, ref jackx, ref jacky, jack);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveRight(maze, ref jackx, ref jacky, jack);
                }
                Thread.Sleep(100);
            }
        }
        
        static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        static void readMaze(char[,] maze)
        {
            StreamReader file = new StreamReader("E:\\oops\\lab1\\pdweek1\\SubwaySurf\\maze.txt");
            string record;
            int row = 0;
            while ((record = file.ReadLine()) != null)
            {
                for (int x = 0; x < 128; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            file.Close();
        }
        static void printMaze(char[,] maze)
        {
         
            for (int x = 0; x < 34; x++)
            {
                 
                for (int y = 0; y < 129; y++)
                {
                    Console.Write(maze[x, y]);
                }
              
                Console.WriteLine();
            }
        }
        static char getCharAtxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char charAtPos = keyInfo.KeyChar;
            return charAtPos;
        }
        static void printJack(ref int x, ref int y, char[,] jack)
        {
            for (int row = 0; row < 3; row++)
            {
                gotoxy(x, y + row);
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(jack[row, col]);
                }
            }
        }
        static void printGlados(ref int gladosX, ref int gladosY, char[,] glados)
        {
            for (int rows = 0; rows < 4; rows++)
            {
                gotoxy(gladosX, gladosY + rows);
                for (int col = 0; col < 5; col++)
                {
                    Console.Write(glados[rows, col]);
                }
            }
        }

        // this function will erase the jack.
        static void erazeJack(ref int x, ref int y)
        {
            for (int row = 0; row < 3; row++)
            {
                gotoxy(x, y + row);
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" ");
                }
            }
        }
        static void moveRight(char[,] maze, ref int jackX, ref int jackY, char[,] jack)
        {
            if (maze[jackX, jackY + 3] == ' ')
            {
                erazeJack(ref jackY, ref jackX);
                jackY++;
                printJack(ref jackY, ref jackX, jack);
            }
        }

        static void moveLeft(char[,] maze, ref int jackX, ref int jackY, char[,] jack)
        {
            if (maze[jackX - 0, jackY - 1] == ' ')
            {
                erazeJack(ref jackY, ref jackX);
                jackY--;
                printJack(ref jackY, ref jackX, jack);
            }
        }

        static void moveUp(char[,] maze, ref int jackX, ref int jackY, char[,] jack)
        {
            if (maze[jackX - 1, jackY - 0] == ' ')
            {
                erazeJack(ref jackY, ref jackX);
                jackX--;
                printJack(ref jackY, ref jackX, jack);
            }
        }

        static void moveDown(char[,] maze, ref int jackX, ref int jackY, char[,] jack)
        {
            if (maze[jackX + 3, jackY + 0] == ' ')
            {
                erazeJack(ref jackY, ref jackX);
                jackX++;
                printJack(ref jackY, ref jackX, jack);
            }
        }

        /*readBulletCount();
        Console.Clear();
        printHeader();
        if (bulletCount == 0)
        {
            menu();
            Console.WriteLine("Enter the Option number : ");
            option = char.Parse( Console.ReadLine());
            if (option == '1')
            {
                resetCoordinates();
                gamerunning(); // all operations of game are performed in this function.
            }
            else if (option == '2')
            {
                int number = -1;
                while (number != 3)
                {
                    Console.Clear();
                    printHeader();
                    options();
                    Console.WriteLine("Enter the option number : ");
                    number = int.Parse(Console.ReadLine());
                    if (number == 1)
                    {
                        Console.Clear();
                        printHeader();
                        keys(); // Show the controler keys of the game.
                    }
                    else if (number == 2)
                    {
                        Console.Clear();
                        printHeader();
                        Instructions(); // provide the instructions regarding game.
                    }
                    else if (number == 3)
                    {
                        break;
                    }
                }
            }
            else if (option == '3')
            {
                isRunning = false;
            }
        }
        else
        {
            option = resumeMenu(); // resume game will start game from the point where it had been left.
            if (option == '1')
            {
                readCoordinates();
                readHealth();
                gamerunning();
            }
            else if (option == '2')
            {
                resetCoordinates(); // itwill reset the coordinates and will start a new game.
                gamerunning();
            }
            else if (option == '3')
            {
                bool isRunningg = true;
                while (isRunningg)
                {
                    Console.Clear();
                    printHeader();
                    int number;
                    options();
                    Console.WriteLine("Enter the option number : ");
                    number = int.Parse( Console.ReadLine());
                    if (number == 1)
                    {
                        Console.Clear();
                        printHeader();
                        keys();
                    }
                    else if (number == 2)
                    {
                        Console.Clear();
                        printHeader();
                        Instructions();
                    }
                    else if (number == 3)
                    {
                        break;
                    }
                }
            }
            else if (option == '4')
            {
                break;
            }
        }
        }*/




        /*static void printHeader()
        {
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("@@                                                                                                              @@");
            Console.WriteLine("@@ ####### ##    ## ######  ##     ##  #####  ##    ##     ######  ##    ## ###    ## ###    ## ####### ######  @@");
            Console.WriteLine("@@ ##      ##    ## ##   ## ##     ## ##   ##  ##  ##      ##  ##  ##    ## ####   ## ####   ## ##      ##  ##  @@");
            Console.WriteLine("@@ ####### ##    ## ######  ##  #  ## #######   ####       ######  ##    ## ## ##  ## ## ##  ## #####   ######  @@");
            Console.WriteLine("@@      ## ##    ## ##   ## ## ### ## ##   ##    ##        ## ##   ##    ## ##  ## ## ##  ## ## ##      ## ##   @@");
            Console.WriteLine("@@ #######  ######  ######   ### ###  ##   ##    ##        ##   ##  ######  ##   #### ##   #### ####### ##   ## @@");
            Console.WriteLine("@@                                                                                                              @@");
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        }
        // it will print menu of the game.
        static void menu()
        {
            Console.WriteLine("   Menu");
            Console.WriteLine("____________________");
            Console.WriteLine("  ");
            Console.WriteLine("1. Start.");
            Console.WriteLine("2. Options.");
            Console.WriteLine("3. Exit.");
        }
        // it will provide the options to user.
        static void options()
        {

            Console.WriteLine("  ");
            Console.WriteLine("1. Keys.");
            Console.WriteLine("2. Instructions.");
            Console.WriteLine("3. Exit.");
        }

        // it give information regarding the keys used in game.
        static void keys()
        {
            Console.WriteLine("   Keys");
            Console.WriteLine("____________________");
            Console.WriteLine("  ");
            Console.WriteLine("1. Up                Go Up.");
            Console.WriteLine("2. Down              Go Down.");
            Console.WriteLine("3. Right             Go Right.");
            Console.WriteLine("1. Left              Go Left.");
            Console.WriteLine("2. Space             Fire.");
            Console.WriteLine("3. Esc               Resume.");
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }

        // it will give important instructions about the game.
        static void Instructions()
        {
            Console.WriteLine("Player can collect the coins and its score increases.");
            Console.WriteLine("Player can dough the hurdles. If player collide with ");
            Console.WriteLine("the hurdle he will die and if he collide with the bullets");
            Console.WriteLine("fired by Frank and Glados , his power reduces slowly ");
            Console.WriteLine("and he will gradually die.");
            Console.ReadKey();
        }
        // this function will print maze on the screen.
        *//*void printMaze()
        {
            Console.Clear();
            for (int row = 0; row < 34; row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    // Console.WriteLine(maze[row][0];
                }
            }
        }*/

        // ----------------------------- Jack Functions ------------------------------------

        // it will print main charater jack on screen.


        /* static string[,] maze = {
         {"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"},
         {"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"},
         {"@@                                                                                                                            @@"},
         {"@@                                                                                                                            @@"},
         {"@@                                                                                                                            @@"},
         {"@@                                                                                                                            @@"},
         {"@@         @@                                                                                                                 @@"},
         {"@@         @@                                                         @@                              @@@@@@@@@@@@            @@"},
         {"@@         @@                                                         @@                                                      @@"},
         {"@@         @@                                        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                     @@"},
         {"@@         @@                                                         @@                                                      @@"},
         {"@@         @@                                                         @@                                                      @@"},
         {"@@                                                                                                                            @@"},
         {"@@                                                                                                                            @@"},
         {"@@                                                                                                                            @@"},
         {"@@                      @@@@@@@@@@@@@@@@@@@@@                                                                                 @@"},
         {"@@                                         @@                                                                                 @@"},
         {"@@                                         @@                                                                                 @@"},
         {"@@                                         @@                                                                                 @@"},
         {"@@                                         @@                                                                                 @@"},
         {"@@                                         @@                                                  @@                             @@"},
         {"@@                                                                                             @@                             @@"},
         {"@@        @@                                                                                   @@                             @@"},
         {"@@        @@                                                                                   @@                             @@"},
         {"@@        @@                                                  @@@@@@@@@@@@@@@@@@@@             @@                             @@"},
         {"@@        @@                                                                                   @@                             @@"},
         {"@@        @@                                                                                   @@                             @@"},
         {"@@        @@@@@@@@@@@@@@@@@@@@@@@@                                                                                            @@"},
         {"@@                                                                                                                            @@"},
         {"@@                                                                                                                            @@"},
         {"@@                                                                                                                            @@"},
         {"@@                                                                                                                            @@"},
         {"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"},
         {"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"}};*/

        // this function is used to detect bullet collision of Glados with Jack.
        /*    static void bulletCollisionOfGladosWithJack(ref int gladosBulletCount,bool[] isGladosBulletActive, char bigbox,char smallbox,char upbox,char top,ref int jackHealth, int[] gladosBulletX,int[] gladosBulletY)
            {

                for (int i = 0; i < gladosBulletCount; i++)
                {
                    if (isGladosBulletActive[i] == true)
                    {
                        char next;
                        next = getCharAtxy(gladosBulletX[i], gladosBulletY[i] + 1);
                        if (next == bigbox || next == smallbox || next == upbox || next == top)
                        {
                            eraseJackHealth();
                            jackHealth = jackHealth - 5;
                            printJackHealth(ref jackHealth);
                        }
                    }
                }
            }
            static void printJackHealth(ref int jackHealth)
            {
                if (jackHealth >= 0)
                {
                    gotoxy(134, 10);
                    Console.WriteLine("Jack Health: {0}  ",jackHealth);
                }
            }

            // this function is used to erase Jack health.
            static void eraseJackHealth()
            {
                gotoxy(134, 10);
                Console.WriteLine("                  ");
            }

            // this function is used to generate bullets of Jack.
            static void generateBullet(ref int jackX,ref int jackY, int[] bulletX, int[] bulletY, bool[] isBulletActive,ref int bulletCount)
            {
                if ((jackX  != '@') && ((jackY - 1) != '@' ))
                {
                    bulletX[bulletCount] = jackX;
                    bulletY[bulletCount] = jackY - 1;
                    isBulletActive[bulletCount] = true;
                    gotoxy(jackY, jackY - 1);
                    Console.WriteLine('.');
                    bulletCount++;
                }
            }

            // This function is used to erase bullets of Jack
            static void eraseBullet(ref int x,ref int y)
            {

                gotoxy(x, y);
                Console.WriteLine(" ");
            }

            // This function  is used to move bullets of Jack.
            static void moveBullet(ref int bulletCount, bool[] isBulletActive, int[] bulletX, int[] bulletY)
            {
                for (int i = 0; i < bulletCount; i++)
                {
                    if (isBulletActive[i] == true)
                    {
                        char nextLocation = getCharAtxy(bulletX[i], bulletY[i] - 1);
                        if (nextLocation != ' ')
                        {
                            eraseBullet(bulletX[i], bulletY[i]);
                            bulletInactive(i);
                        }
                        else
                        {
                            eraseBullet(bulletX[i], bulletY[i]);
                            bulletY[i] = bulletY[i] - 1;
                            printBullet(bulletX[i], bulletY[i]);
                        }
                    }
                }
            }

            // this function is used to print bullets of Jack.
            static void printBullet(int bulletX, int bulletY)
            {
                gotoxy(bulletX, bulletY);
                Console.WriteLine(".");
            }

            // this function is used to make bullets of Jack inactive to remove it from screen.
            static void bulletInactive(int index)
            {
                isBulletActive[index] = false;
            }*/

        // this function will print the enemy named as Glados.
        /*  static void printGlados()
          {
              for (int rows = 0; rows < 4; rows++)
              {
                  gotoxy(gladosX, gladosY + rows);
                  for (int col = 0; col < 5; col++)
                  {
                      Console.WriteLine(glados[rows][col]);
                  }
              }
          }

          // this function will erase the enemy Glados.
          static void eraseGlados()
          {
              for (int rows = 0; rows < 4; rows++)
              {
                  gotoxy(gladosX, gladosY + rows);
                  for (int col = 0; col < 6; col++)
                  {
                      Console.WriteLine(" ");
                  }
              }
          }

          // this function is used to move Glados left and right horizontally.
          static void moveGlados()
          {
              if (gladosDirection == "Right")
              {
                  char next = getCharAtxy(gladosX + 6, gladosY);
                  if (next == ' ' || next == '.')
                  {
                      eraseGlados();
                      gladosX++;
                      printGlados();
                      generateGladosBullet();
                  }
                  if (gladosX > 40)
                  {
                      gladosDirection = "Left";
                  }
              }

              if (gladosDirection == "Left")
              {
                  char next = getCharAtxy(gladosX - 1, gladosY);
                  if (next == ' ' || next == '.')
                  {
                      eraseGlados();
                      gladosX--;
                      printGlados();
                      generateGladosBullet();
                  }
                  else if (gladosX < 15)
                  {
                      gladosDirection = "Right";
                  }
              }
          }

          // this function is used to move the bullets of Glados.
          static void moveGladosBullet()
          {
              for (int i = 0; i < gladosBulletCount; i++)
              {
                  if (isGladosBulletActive[i] == true)
                  {
                      char next = getCharAtxy(gladosBulletX[i] + 1, gladosBulletY[i] + 1);
                      // char next1 = getCharAtxy(gladosBulletX[i] + 1, gladosBulletY[i]);
                      if (next != ' ')
                      {
                          eraseGladosBullet(gladosBulletX[i], gladosBulletY[i]);
                          makeGladosBulletInactive(i);
                      }
                      else
                      {

                          eraseGladosBullet(gladosBulletX[i], gladosBulletY[i]);
                          gladosBulletY[i]++;
                          printGladosBullet(gladosBulletX[i], gladosBulletY[i]);
                      }
                  }
              }
          }

          // this function is used to generate the bullets of Glados.
          static void generateGladosBullet()
          {
              gladosBulletY[gladosBulletCount] = gladosY + 4;
              gladosBulletX[gladosBulletCount] = gladosX + 2;
              isGladosBulletActive[gladosBulletCount] = true;
              gotoxy(gladosX + 2, gladosY + 4);
              Console.WriteLine(" - ");
              gladosBulletCount++;
          }

          // this function is used to print the bullets of Glados.
          static void printGladosBullet(int x, int y)
          {
              gotoxy(x, y);
            */  //Console.WriteLine("-");



        // this function is used to erase the bullets of Glados.
        /* static void eraseGladosBullet(int x, int y)
         {
             gotoxy(x, y);
             Console.WriteLine("  ");
         }

         // this function is used to make the bullets of Glados inactive in order to remove it from screen.
         static void makeGladosBulletInactive(int index)
         {
             isGladosBulletActive[index] = false;
         }

         // this function is used to detect bullet collision with Glados.
         static void bulletCollisionWithGlados()
         {
             for (int i = 0; i < bulletCount; i++)
             {
                 if (isBulletActive[i] == true)
                 {
                     if (bulletY[i] - 1 == gladosY + 4 && (bulletX[i] == gladosX || bulletX[i] == gladosX + 1 || bulletX[i] == gladosX + 2 || bulletX[i] == gladosX + 3 || bulletX[i] == gladosX + 4 || bulletX[i] == gladosX + 5))
                     {
                         addScore();
                         // score++;
                         eraseGladosHealth();
                         gladosHealth = gladosHealth - 5;
                     }
                     if (gladosY + 5 == bulletY[i] && gladosX + 1 == bulletX[i])
                     {
                         addScore();
                         // score++;
                         eraseGladosHealth();
                         gladosHealth = gladosHealth - 5;
                     }
                 }
             }
         }

         // this function is used to detect bullet collision of Glados with grid.
         static void bulletCollisionOfGladosWithGrid()
         {

             for (int i = 0; i < gladosBulletCount; i++)
             {
                 if (isGladosBulletActive[i] == true)
                 {
                     char next;
                     next = getCharAtxy(gladosBulletX[i], gladosBulletY[i] + 1);
                     if (next == '@')
                     {
                         eraseGladosBullet(gladosBulletX[i], gladosBulletY[i]);
                         makeGladosBulletInactive(i);
                     }
                 }
             }
         }

         // this function is used to print Glados health.
         static void printGladosHealth()
         {
             if (gladosHealth >= 0)
             {
                 gotoxy(134, 30);
                 Console.WriteLine("Glados Health: {0}   ", gladosHealth);
             }
         }

         // this function is used to erase Glados health.
         static void eraseGladosHealth()
         {
             gotoxy(134, 30);
             Console.WriteLine("                        ");
         }
         // this function is used to add score.
         static void addScore()
         {   
             score++;
         }

         // this function is used to print score on screen.
         static void printScore()
         {
             gotoxy(134, 8);
             Console.WriteLine("Score: {0} ",score);
         }*/

        /*static void gamerunning()
        {
            Console.Clear();
            printMaze();
            printJack(jackx, jacky);
            gotoxy(40, 40);
            while (true)
            {

                printScore();
                //printFreshHealth();
                printJackHealth();
                printGladosHealth();

                // move Jack to Right.
                if ((Keyboard.IsKeyPressed(Key.R)))
                {
                    char nextlocation = getCharAtxy(jackx + 3, jacky);
                    char nextlocation1 = getCharAtxy(jackx + 3, jacky + 1);
                    char nextlocation2 = getCharAtxy(jackx + 3, jacky + 2);

                    if ((nextlocation == ' ' || nextlocation == '.' || nextlocation == '-') && (nextlocation1 == ' ' || nextlocation == '.' || nextlocation == '-') && (nextlocation2 == ' ' || nextlocation == '.' || nextlocation == '-'))
                    {
                        erazeJack(jackx, jacky);
                        jackx = jackx + 1;
                        printJack(jackx, jacky);
                    }
                    direction = "right";
                }

                // move Jack to Left.
                if ((Keyboard.IsKeyPressed(Key.LeftArrow)))
                {
                    char nextlocation = getCharAtxy(jackx - 1, jacky);
                    char nextlocation1 = getCharAtxy(jackx - 1, jacky + 1);
                    char nextlocation2 = getCharAtxy(jackx - 1, jacky + 2);
                    if ((nextlocation == ' ' || nextlocation == '.' || nextlocation == '-') && (nextlocation1 == ' ' || nextlocation == '.' || nextlocation == '-') && (nextlocation2 == ' ' || nextlocation == '.' || nextlocation == '-'))
                    {
                        erazeJack(jackx, jacky);
                        jackx = jackx - 1;
                        printJack(jackx, jacky);
                    }
                    direction = "left";
                }

                // move Jack Up.
                if ((Keyboard.IsKeyPressed(Key.UpArrow)))
                {
                    char nextlocation = getCharAtxy(jackx, jacky - 2);
                    char nextlocation1 = getCharAtxy(jackx + 1, jacky - 2);
                    char nextlocation2 = getCharAtxy(jackx + 2, jacky - 2);
                    if ((nextlocation == ' ' || nextlocation == '.' || nextlocation == '-') && (nextlocation1 == ' ' || nextlocation == '.' || nextlocation == '-') && (nextlocation2 == ' ' || nextlocation == '.' || nextlocation == '-'))
                    {
                        erazeJack(jackx, jacky);
                        jacky = jacky - 1;
                        printJack(jackx, jacky);
                    }
                    direction = "up";
                }

                // move Jack Down.
                if ((Keyboard.IsKeyPressed(Key.DownArrow)))
                {
                    char nextlocation = getCharAtxy(jackx, jacky + 3);
                    char nextlocation1 = getCharAtxy(jackx + 1, jacky + 3);
                    char nextlocation2 = getCharAtxy(jackx + 2, jacky + 3);
                    if ((nextlocation == ' ' || nextlocation == '.' || nextlocation == '-') && (nextlocation1 == ' ' || nextlocation == '.' || nextlocation == '-') && (nextlocation2 == ' ' || nextlocation == '.' || nextlocation == '-'))
                    {
                        erazeJack(jackx, jacky);
                        jacky = jacky + 1;
                        printJack(jackx, jacky);
                    }
                    direction = "down";
                }

                // space is used to generate bullets
                if ((Keyboard.IsKeyPressed(Key.Space)))
                {
                    generateBullet(jackx, jacky);
                    storeBulletCount();
                }

                //bulletCollisionOfFreshWithJack();
                bulletCollisionOfGladosWithJack();
                //moveFreshBullet();
                if (gladosHealth > 0 && timer == 0)
                {
                    printGlados();
                    moveGlados();
                    generateGladosBullet();
                    timer = 5;
                }
                if (freshHealth <= 0)
                {
                    eraseGlados();
                    gladosHealth = 0;
                    deadCount1 = 1;
                    flag = true;
                    Console.Clear();
                    char ch;
                    Console.WriteLine(" GAME OVER ");
                    Console.WriteLine("Press C to continue : ");
                    ch = char.Parse(Console.ReadLine());
                }
                *//*if (jackHealth <= 0)
                {
                    Console.Clear();
                    char ch;
                    Console.WriteLine(" GAME OVER ");
                    Console.WriteLine("Press C to continue : ");
                    ch = char.Parse(Console.ReadLine());
                }*//*
                moveGladosBullet();
                printGladosHealth();

                if (gladosHealth > 0)
                {
                    moveGlados();
                    if (timer == 0)
                    {
                        generateGladosBullet();
                    }
                    bulletCollisionWithGlados();
                    bulletCollisionOfGladosWithGrid();
                    timer1 = 5;
                }
                else if (gladosHealth <= 0)
                {
                    eraseGlados();
                    gladosHealth = 0;
                    deadCount2 = 1;
                }

                timer--;
                timer1--;
                if (freshHealth == 0 && gladosHealth == 0)
                {
                    deadCount = 1;
                }
                if ((deadCount1 == 1 && deadCount2 == 1) && jackHealth > 0)
                {
                    char character;
                    Console.Clear();
                    Console.WriteLine("Press any key to continue : ");
                    character = char.Parse(Console.ReadLine());
                    //level2();
                }
                //moveYutani();
                moveBullet();

                //bulletCollisionWithFresh();

                if ((Keyboard.IsKeyPressed(Key.Escape)))
                {
                    Console.Clear();
                    //storeCoordinates();
                    //storeBulletCount();
                    //storeHealth();
                    break;
                }

                Thread.Sleep(30);
            }
            Console.ReadKey();
        }*/
        /*static char resumeMenu()
        {
            char choice;
            Console.WriteLine("   Menu");
            Console.WriteLine("____________________");
            Console.WriteLine("  ");
            Console.WriteLine("1. Resume.");
            Console.WriteLine("2. Start.");
            Console.WriteLine("3. Options.");
            Console.WriteLine("4. Exit.");
            Console.WriteLine("Please Enter Your Choice : ");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }*/

        /*static void readBulletCount()
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    readBulletCount = parseData(record, 1);
                    gladosBulletCount = parseData(record, 2);
                    Count++;
                }
                fileVariable.Close();
            }
            else
            {
                Console.Write("Not Exists!");
            }
        }
        void storeBulletCount()
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(bulletCount + "," + gladsoBulletCount);
            file.Flush();
            file.Close();
        }*/



    } 
}

