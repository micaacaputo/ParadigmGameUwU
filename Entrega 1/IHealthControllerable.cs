namespace MyGame
{
    public interface IHealthControllerable
    {
        void HealthDown();
        void HealthUp();
        void Dead();
    }
}