using System.Text;

namespace IO
{
    public class Screen
    {
        // Create a 2D char array with dimensions height = 30, width = 100
        int width = 140;
        int height = 35;
        private Point[,] screen;

        public int Width
        {
            get
            {
                return width;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
        }
        public Screen()
        {
            width = 120;
            height = 35;

            screen = new Point[height, width];
            Start();
        }
        public Screen(int Width, int Height)
        {
            width = Width;
            height = Height;
            screen = new Point[height, width];
            Start();
        }
        ~Screen()
        {
            Console.CursorVisible = true;
        }
        void Start()
        {
            Console.CursorVisible = false;
            ClearScreen();
        }
        public void ClearScreen()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    screen[y, x] = new Point(' ', ConsoleColor.White);
                }
            }
        }
        public void ClearConsole()
        {
            Console.Clear();
        }
        public void Place(Vector2 pos, Point[,] content)
        {
            int height = content.GetLength(0); // Y
            int width = content.GetLength(1);  // X

            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    int targetY = (int)pos.Y + y;
                    int targetX = (int)pos.X + x;

                    if (targetY >= 0 && targetY < this.height && targetX >= 0 && targetX < this.width)
                    {
                        if (content[y, x].Value != '\0')
                        {
                            screen[targetY, targetX] = content[y, x];
                        }
                    }
                }
            }
        }

        public Point Get(Vector2 pos)
        {
            return screen[(int)pos.Y, (int)pos.X];
        }

        public void Display()
        {
            var output = new StringBuilder(); // Buffer for output text
            ConsoleColor? currentColor = null;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var cell = screen[y, x];
                    if (cell.Color != currentColor)
                    {
                        // Flush buffer to console when color changes
                        Console.Write(output.ToString());
                        output.Clear();

                        Console.ForegroundColor = cell.Color;
                        currentColor = cell.Color;
                    }
                    output.Append(cell.Value);
                }
                output.AppendLine(); // Add newline after each row
            }

            // Flush remaining output
            Console.Write(output.ToString());

            Console.ResetColor();
        }

    }
}
