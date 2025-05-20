namespace IO
{
    public class Cursor
    {
        public int X;
        public int Y;

        int jumpsizeX;
        int jumpsizeY;

        public event Action? OnUse;
        public event Action? OnUndo;

        public Cursor(int jumpsizeX, int jumpsizeY)
        {
            this.jumpsizeX = jumpsizeX;
            this.jumpsizeY = jumpsizeY;
        }

        public void GetInput()
        {
            var key = Console.ReadKey(true).Key;  // `true` to not display the keys on input
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    X -= jumpsizeX;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    X += jumpsizeX;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    Y -= jumpsizeY;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    Y += jumpsizeY;
                    break;
                case ConsoleKey.Enter:
                    Use();
                    break;
                case ConsoleKey.Z:
                    Undo();
                    break;
            }
        }
        void Use()
        {
            OnUse?.Invoke();
        }
        void Undo()
        {
            OnUndo?.Invoke();
        }
    }

}