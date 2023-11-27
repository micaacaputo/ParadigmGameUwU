using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.assets;

namespace MyGame
{
    public class Character : GameObject
    {
        public int health { get; set; }
        public int ammo { get; set; }
        private IInputeable InputCharacterController;
        private IShooteable ShootController;
        public HealthController HealthController;
        public IntPtr image;
        public IntPtr image2;
        //Animation currentAnimation;
        //Animation idleAnimation;
        public Character(float x, float y, float radius, int width, int height, int mass = 1, int ammo = 3)
        {

            Position = new Vector2(x, y);
            this.radius = radius;
            this.width = width;
            this.height = height;
            this.mass = mass;
            this.ammo = ammo;
            health = 1;
            HealthController = new HealthController(this);
    
            image = Engine.LoadImage("assets/Character/character.png");
            image2 = Engine.LoadImage("assets/Character/body.png");
           //CreateAnimations();
           //currentAnimation = idleAnimation;
        }
       /*private void CreateAnimations()
        {
            List<IntPtr> idleTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Ship/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);

        }*/
        public void Update()
        {
            ShootController.ShootUpdate();
            InputCharacterController.InputUpdate();
            //currentAnimation.Update();
        }

        public void AssignDependecies(IInputeable inputeable, IShooteable shooteable)
        {
            InputCharacterController = inputeable;
            ShootController = shooteable;
        }
    }
}
