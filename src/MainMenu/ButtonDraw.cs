
using IO;

namespace Menu.ButtonDrawer
{
    public class ButtonDraw
    {
        Screen screen;
        public ButtonDraw(Screen screen)
        {
            this.screen = screen;
        }
        public void DrawButton(Vector2 pos, Vector2 sizes)
        {
            ConsoleColor color = ConsoleColor.White;
            Point[,] content = new Point[(int)sizes.Y, (int)sizes.X];
            int width = (int)sizes.X;
            int height = (int)sizes.Y;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if ((x == 0 || x == width - 1) && (y == 0 || y == height - 1))
                    {
                        content[y, x] = new Point('+', color);
                    }
                    // Vertical borders
                    else if (x == 0 || x == width - 1)
                    {
                        content[y, x] = new Point('|', color);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == height - 1)
                    {
                        content[y, x] = new Point('-', color);
                    }
                    else
                    {
                        content[y, x] = new Point(' ', color);
                    }
                }
            }
            screen.Place(pos, content);
        }
        public void DrawButton(Vector2 pos, Vector2 sizes, string label)
        {
            ConsoleColor color = ConsoleColor.White;
            Point[,] content = new Point[(int)sizes.Y, (int)sizes.X];
            int width = (int)sizes.X;
            int height = (int)sizes.Y;
            int stringIndex = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y == height / 2 && x > 0 && stringIndex < label.Length)
                    {
                        content[y, x] = new Point(label[stringIndex], color);
                        stringIndex++;
                    }
                    else if ((x == 0 || x == width - 1) && (y == 0 || y == height - 1))
                    {
                        content[y, x] = new Point('+', color);
                    }
                    // Vertical borders
                    else if (x == 0 || x == width - 1)
                    {
                        content[y, x] = new Point('|', color);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == height - 1)
                    {
                        content[y, x] = new Point('-', color);
                    }
                    else
                    {
                        content[y, x] = new Point(' ', color);
                    }
                }
            }
            screen.Place(pos, content);
        }
        public void DrawButton(Vector2 pos, Vector2 sizes, ConsoleColor color)
        {
            Point[,] content = new Point[(int)sizes.Y, (int)sizes.X];
            int width = (int)sizes.X;
            int height = (int)sizes.Y;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if ((x == 0 || x == width - 1) && (y == 0 || y == height - 1))
                    {
                        content[y, x] = new Point('+', color);
                    }
                    // Vertical borders
                    else if (x == 0 || x == width - 1)
                    {
                        content[y, x] = new Point('|', color);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == height - 1)
                    {
                        content[y, x] = new Point('-', color);
                    }
                    else
                    {
                        content[y, x] = new Point(' ', color);
                    }
                }
            }
            screen.Place(pos, content);
        }
        public void DrawButton(Vector2 pos, Vector2 sizes, string label, ConsoleColor color)
        {
            Point[,] content = new Point[(int)sizes.Y, (int)sizes.X];
            int width = (int)sizes.X;
            int height = (int)sizes.Y;
            int stringIndex = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y == height / 2 && x > 0 && stringIndex < label.Length)
                    {
                        content[y, x] = new Point(label[stringIndex], color);
                        stringIndex++;
                    }
                    else if ((x == 0 || x == width - 1) && (y == 0 || y == height - 1))
                    {
                        content[y, x] = new Point('+', color);
                    }
                    // Vertical borders
                    else if (x == 0 || x == width - 1)
                    {
                        content[y, x] = new Point('|', color);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == height - 1)
                    {
                        content[y, x] = new Point('-', color);
                    }
                    else
                    {
                        content[y, x] = new Point(' ', color);
                    }
                }
            }
            screen.Place(pos, content);
        }
    }
}