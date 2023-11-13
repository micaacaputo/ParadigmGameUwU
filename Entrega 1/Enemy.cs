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
        public IntPtr image;
        //Animation currentAnimation;
        //Animation idleAnimation;
        public Enemy(float x, float y, float radius, string image, int width, int height, bool isActive = true)
        {
            Position = new Vector2(x, y);

            this.radius = radius;
            this.width = width;
            this.height = height;
            timer = 1;
            mass = 1;
            this.isActive = isActive;

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
    }
}
