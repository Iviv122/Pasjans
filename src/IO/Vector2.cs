namespace IO
{
    using System;

    public struct Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }
        // Constructor
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        // Magnitude (Length) of the vector
        public float Magnitude => (float)Math.Sqrt(X * X + Y * Y);

        // Normalize the vector
        public Vector2 Normalized => this / Magnitude;

        // Operator overloading
        public static Vector2 operator +(Vector2 a, Vector2 b) =>
            new Vector2(a.X + b.X, a.Y + b.Y);

        public static Vector2 operator -(Vector2 a, Vector2 b) =>
            new Vector2(a.X - b.X, a.Y - b.Y);

        public static Vector2 operator *(Vector2 a, float scalar) =>
            new Vector2(a.X * scalar, a.Y * scalar);

        public static Vector2 operator *(float scalar, Vector2 a) =>
            a * scalar;

        public static Vector2 operator /(Vector2 a, float scalar) =>
            new Vector2(a.X / scalar, a.Y / scalar);

        // Dot product
        public static float Dot(Vector2 a, Vector2 b) =>
            a.X * b.X + a.Y * b.Y;

        // Override ToString
        public override string ToString() =>
            $"({X}, {Y})";
    }


}