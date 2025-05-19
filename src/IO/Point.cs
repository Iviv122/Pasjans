namespace IO
{
    public struct Point 
    {
        public char Value;
        public ConsoleColor Color;
        public Point(char Symbol, ConsoleColor color = ConsoleColor.White){
            Value =Symbol;
            Color = color;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}