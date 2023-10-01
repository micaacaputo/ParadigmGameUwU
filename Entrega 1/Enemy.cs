using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Enemy
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Aceleration { get; set;}
        public int width { get; set; }
        public int height { get; set; }
        public float r { get; set; }
        public float w { get; set; }
        public float ar { get; set; }
        public float mass { get; set; }
        public float radio { get; private set; }
        public int health { get; set; }

        public bool isActive = true;
        

        IntPtr image;
        //Animation currentAnimation;
        //Animation idleAnimation;

        public Enemy(float x, float y, float radio, string image, int width, int height, float mass = 1)
        {
            Position = new Vector2(x, y);

            this.radio = radio;
            this.mass = mass;
            this.width = width;
            this.height = height;

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
        }
        public void Render()
        {
            //Engine.Draw(currentAnimation.CurrentFrame, x, y);
            if(isActive)
            {
                Engine.Draw(image, Position.x- Program.camara.Position.x, Position.y- Program.camara.Position.y);
            }
            
        }

    }
}
