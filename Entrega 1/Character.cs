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
        Animation currentAnimation;
        Animation movingAnimation;
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
           currentAnimation = movingAnimation;
        }
       private void CreateAnimations()
        {
            List<IntPtr> movingTextures = new List<IntPtr>();
            for (int i = 1; i < 5; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Animation/character/{i}.png");
                movingTextures.Add(frame);
            }
            movingAnimation = new Animation("Move", movingTextures, 1, true);

        }
        public void Update()
        {
            ShootController.ShootUpdate();
            InputCharacterController.InputUpdate();
            movingAnimation.Update();
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
