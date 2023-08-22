using EZInput;
namespace PacMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameGrid grid = new GameGrid(24, 71,"maze.txt");
            GameCell start = new GameCell(12, 22, grid);
            GameCell horizontalghost = new GameCell(4,4,grid);
            Ghost H1 = new HorizontalGhost('H', horizontalghost);
            GameCell verticalghost = new GameCell(6, 4, grid);
            Ghost V1 = new VerticalGhost('V', verticalghost);
            GameCell randomGhost = new GameCell(12, 30, grid);
            Ghost R1 = new RandomGhost('R', randomGhost);
            GameCell smartGhost = new GameCell(10, 42, grid);
            Ghost S1 = new SmartGhost('S', smartGhost);
            Pacman pacman = new Pacman('P', start);
            printMaze(grid);
            printGameObject(pacman);

            bool gameRunning = true;
            while (gameRunning)
            {
                Thread.Sleep(90);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveGameObject(pacman, GameDirection.UP);
                }

                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveGameObject(pacman, GameDirection.DOWN);
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveGameObject(pacman, GameDirection.RIGHT);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveGameObject(pacman, GameDirection.LEFT);
                }
                S1.SetCell(ref start);
                H1.Move();
                V1.Move();
                R1.Move();
                S1.Move();
            }
        }
        static void clearGameCellContent(GameCell gameCell, GameObject newGameObject)
        {
            gameCell.gameObject = newGameObject;
            Console.SetCursorPosition(gameCell.Y, gameCell.X);
            Console.Write(newGameObject.DisplayCharacter);
        }
        static void printGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.CurrentCell.Y, gameObject.CurrentCell.X);
            Console.Write(gameObject.DisplayCharacter);

        }

        static void moveGameObject(GameObject gameObject, GameDirection direction)
        {
            GameCell nextCell = gameObject.CurrentCell.NextCell(direction);
            if (nextCell != null)
            {
                if(nextCell.gameObject.DisplayCharacter == ' ' || nextCell.gameObject.DisplayCharacter == '.')
                {
                    GameObject newGO = new GameObject(' ', GameObjectType.None);
                    GameCell currentCell = gameObject.CurrentCell;
                    clearGameCellContent(currentCell, newGO);
                    gameObject.CurrentCell = nextCell;
                    printGameObject(gameObject);
                }   
            }
        }

        static void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Columns; y++)
                {
                    GameCell cell = grid.GetCell(x, y);
                    printCell(cell);
                }
            }
        }

        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.gameObject.DisplayCharacter);
        }
    }
}