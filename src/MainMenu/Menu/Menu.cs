using IO;

namespace Menu
{
    abstract public class Menu
    {
        public Menu()
        {
            buttons = new();
        }
        protected List<Button> buttons;
        public List<Button> Buttons => buttons; 
        abstract public void Draw();
        abstract public void DrawCursor(Cursor cursor);
        abstract public void CreateButtons();
        abstract public void Exit();
    }
}