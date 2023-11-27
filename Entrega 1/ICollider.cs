namespace MyGame.assets
{
    public interface ICollider
    {
        float radius { get; set;}
        int width { get; set;}
        int height { get; set;}

        void AssignProps(int width, int height, float radius);
    }
}