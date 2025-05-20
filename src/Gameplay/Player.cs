using IO;

namespace Pasjans
{
    class Player
    {
        GameTable game;
        Cursor cursor;
        int maxX;
        int maxY;
        public Player(GameTable game, Cursor cursor)
        {
            this.cursor = cursor;
            this.game = game;
            cursor.OnUse += Execute;
            cursor.OnUndo += Undo;

            // columns, packs, spaces, 
            maxX = game.ColumnsAmountExcluding + game.Packs.Count + 3;
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
            game.ExecuteCommand(cursor.X, cursor.Y);
        }
        public void Undo()
        {
            game.Undo();
        }
    }
}