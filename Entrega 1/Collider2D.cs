using MyGame.assets;

namespace MyGame
{
    public class Collider2D : ICollider
    {
        public float radius { get; set;}
        public int width { get; set;}
        public int height { get; set;}
        public void AssignProps(int width, int height, float radius)
        {
            this.width = width;
            this.height = height;
            this.radius = radius;
        }
    }
}