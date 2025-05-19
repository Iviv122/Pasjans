using IO;

namespace Pasjans
{
    class Player
    {
        Game game;
        Cursor cursor;
        Command[,] commands;
        int maxX;
        int maxY;
        public Player(Game game, Cursor cursor)
        {
            this.cursor = cursor;
            cursor.OnUse += Execute;

            maxX = game.ColumnsAmountExcluding - 2;
            maxY = game.DeepestColumn;
        }
        public void Input()
        {
            cursor.GetInput();
            if (cursor.X <= 0)
            {
                cursor.X = 0;
            }
            if (cursor.Y <= 0)
            {
                cursor.Y = 0;
            }
            if (cursor.X > maxX)
            {
                cursor.X = maxX;
            }
            if (cursor.Y > maxY)
            {
                cursor.Y = maxY;
            }
        }
        public void Execute()
        {
            game.ExecuteCommand(cursor.X,cursor.Y);
        }
    }
}