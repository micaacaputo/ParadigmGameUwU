using MyGame.assets;

namespace MyGame
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Aceleration { get; set; }
        public float mass { get; set; }
        protected float radius { get; set;}
        protected int width { get; set;}
        protected int height { get; set;}

    }
}