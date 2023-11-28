namespace MyGame.assets
{
    public interface ICollider
    {
        float radius { get; }
        int width { get; }
        int height { get; }

        void AssignProps(int width, int height, float radius);
    }
}