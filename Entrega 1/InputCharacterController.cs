using MyGame.assets;

namespace MyGame
{
    public class InputCharacterController : IInputeable
    {
        private Character character { get; }
        private IShooteable shootController { get; }
        private int moveSpeed = 850;
        public float reloadTimer { get; set;}

        public InputCharacterController(Character character, IShooteable shootController)
        {
            this.character = character;
            this.shootController = shootController;
        }
        public void InputUpdate()
        {
            
            reloadTimer += Program.DeltaTime;
            if (Engine.KeyPress(Engine.KEY_LEFT)) 
            {
                Physics.AddForce(character , new Vector2(-moveSpeed,0));
            }

            if (Engine.KeyPress(Engine.KEY_RIGHT)) 
            {
                Physics.AddForce(character, new Vector2(moveSpeed,0));
            }

            if (Engine.KeyPress(Engine.KEY_UP)) 
            {
                Physics.AddForce(character, new Vector2(0,-moveSpeed));
            }

            if (Engine.KeyPress(Engine.KEY_DOWN)) 
            {
                Physics.AddForce(character, new Vector2(0,moveSpeed));
            }

            if (Engine.KeyPress(Engine.KEY_ESP))
            {
                if (reloadTimer > 3)
                {
                    reloadTimer = 0;
                    shootController.Reload();
                }
                
            }
        }
    }
}