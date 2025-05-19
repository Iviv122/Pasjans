namespace IO
{
    class Cursor
    {
        public int X;
        public int Y;

        public Cursor()
        {

        }

        public void GetInput()
        {
            var key = Console.ReadKey(true).Key;  // `true` to not display the key
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    X -= 6;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    X += 6;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    Y -= 2;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    Y += 2;
                    break;
            }
        }
    }

}