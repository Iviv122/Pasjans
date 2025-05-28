namespace Menu
{
    public class Button
    {
        public event Action? OnUse;
        public string Label;
        public Button(string label)
        {
            this.Label = label;
        }
        public void Use()
        {
            OnUse?.Invoke();
        }
    }   
}