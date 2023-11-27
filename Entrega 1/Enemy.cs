using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Enemy : GameObject
    {
        public float timer { get; set; }
        public bool isActive { get; set; }
        public Renderer Renderer;
        public IntPtr image;
        public ICollider Collider;
        //Animation currentAnimation;
        //Animation idleAnimation;
        public Enemy(float x, float y, string image, bool isActive = true)
        {
            Position = new Vector2(x, y);

            radius = 43;
            width = 86;
            height = 86;
            timer = 1;
            mass = 1;
            this.isActive = isActive;
            Renderer = new Renderer();
            this.image = Engine.LoadImage(image);
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
            //currentAnimation.Update();
            timer += Program.DeltaTime;
        }
        public void AssignDependencies(ICollider newCollider)
        {
            Collider = newCollider;
            Collider.AssignProps(width,height,radius);
            
        }
    }
}
