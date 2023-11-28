namespace MyGame
{
    public class HealthController : IHealthControllerable
    {
        public Character Character { get; }

        public HealthController(Character character)
        {
            this.Character = character;
        }

        public void HealthDown()
        {
            Character.health--;
            Dead();
        }
        public void HealthUp()
        {
            Character.health++;
        }

        public void Dead()
        {
            if (Character.health <= 0)
            {
                GameManager.Instance.ChangeCondition(GameCondition.Defeat);
            }
            
        }
    }
}