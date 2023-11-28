namespace MyGame.assets
{
    public struct Vector2
    {
        public float x { get; }
        public float y { get; }

        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }

        
        public static bool operator == (Vector2 a, Vector2 b)
        {
            return (a.x == b.x) && (a.y == b.y);
        }
        public static bool operator != (Vector2 a, Vector2 b)
        {
            return !(a==b);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

    }
}