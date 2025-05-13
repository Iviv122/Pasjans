
namespace IO
{
    namespace IO
    {
        class Screen
        {
            // Create a 2D char array with dimensions height = 30, width = 100
            int width = 100;
            int height = 30;
            private Point[,] screen;
            public Screen()
            {
                screen = new Point[width, height];
            }
            public void ClearScreen()
            {
                for (int y = 0; y < 30; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        screen[y, x] = new Point(' ', ConsoleColor.White);
                    }
                }
            }

            public void Place(Vector2 pos, Point[,] content)
            {
                int rows = content.GetLength(0);
                int cols = content.GetLength(1);

                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        screen[(int)pos.X + x,(int)pos.Y+y] = content[y,x];
                    }
                }
            }

            public void Display()
            {
                for (int y = 0; y < 30; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        Console.Write(screen[y, x]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }

}