namespace MyGame
{
    public class HealthController
    {
        public Character Character;

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
                GameManager.Instance.ChangeCondition(3);
            }
            
        }
    }
}