using MyGame.assets;

namespace MyGame
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Aceleration { get; set; }
        public float mass { get; set; }
        public float radius { get; set;}
        public int width { get; set;}
        public int height { get; set;}

    }
}