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
        public IHealthControllerable HealthController;
        public Renderer Renderer;
        public ICollider Collider;
        public IntPtr image;
        public IntPtr image2;
        public Animation currentAnimationFeetArms;
        public Animation currentAnimationEyes;
        private Animation movingAnimationFeet;
        private Animation movingAnimationEyes;
        public Character(float x, float y, float radius, int width, int height, int mass = 1, int ammo = 3)
        {

            Position = new Vector2(x, y);
            this.radius = radius;
            this.width = width;
            this.height = height;
            this.mass = mass;
            this.ammo = ammo;
            health = 1;
            Renderer = new Renderer();
            image = Engine.LoadImage("assets/Character/character.png");
            image2 = Engine.LoadImage("assets/Character/body.png");
            CreateAnimations();
            currentAnimationFeetArms = movingAnimationFeet;
            currentAnimationEyes = movingAnimationEyes;
        }
       private void CreateAnimations()
        {
            List<IntPtr> movingFeet = new List<IntPtr>();
            for (int i = 1; i < 3; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Animation/character/{i}.png");
                movingFeet.Add(frame);
            }
            movingAnimationFeet = new Animation("Move feet and arms", movingFeet, 0.5f, true);
            
            List<IntPtr> movingEyes = new List<IntPtr>();
            for (int i = 1; i < 7; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Animation/character/eyes/{i}.png");
                movingEyes.Add(frame);
            }
            movingAnimationEyes = new Animation("Move eyes", movingEyes, 0.4f, true);

        }
        public void Update()
        {
            ShootController.ShootUpdate();
            InputCharacterController.InputUpdate();
            currentAnimationFeetArms.Update();
            currentAnimationEyes.Update();
        }

        public void AssignDependencies(IInputeable inputeable, IShooteable shooteable, IHealthControllerable healthControllerable, ICollider newCollider)
        {
            InputCharacterController = inputeable;
            ShootController = shooteable;
            HealthController = healthControllerable;
            Collider = newCollider;
            Collider.AssignProps(width,height,radius);
            
        }
    }
}
