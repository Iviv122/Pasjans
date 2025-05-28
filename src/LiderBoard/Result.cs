using System;

namespace LiderBoard
{
    public class Result : IComparable
    {
        public readonly string Name;
        public readonly int turns;

        public Result(string name, int turns)
        {
            this.Name = name;
            this.turns = turns;
        }

        public override string ToString()
        {
            return Name + " " + turns; 
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            if (obj is Result otherResult)
            {
                return this.turns.CompareTo(otherResult.turns);
            }
            else
            {
                throw new ArgumentException("Object is not a Result");
            }
        }
    }   
}
