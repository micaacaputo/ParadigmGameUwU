using MyGame.assets;

namespace MyGame
{
    public class InputCharacterController : IInputeable
    {
        private Character character;
        private IShooteable shootController;
        private float timer2 = 1;

        public InputCharacterController(Character character, IShooteable shootController)
        {
            this.character = character;
            this.shootController = shootController;
        }
        public void InputUpdate()
        {
            
            timer2 += Program.DeltaTime;
            if (Engine.KeyPress(Engine.KEY_LEFT)) 
            {
                Physics.AddForce(character , new Vector2(-400,0));
            }

            if (Engine.KeyPress(Engine.KEY_RIGHT)) 
            {
                Physics.AddForce(character, new Vector2(400,0));
            }

            if (Engine.KeyPress(Engine.KEY_UP)) 
            {
                Physics.AddForce(character, new Vector2(0,-400));
            }

            if (Engine.KeyPress(Engine.KEY_DOWN)) 
            {
                Physics.AddForce(character, new Vector2(0,400));
            }

            if (Engine.KeyPress(Engine.KEY_ESP))
            {
                if (timer2 > 3)
                {
                    timer2 = 0;
                    shootController.Reload();
                }
                
            }
        }
    }
}