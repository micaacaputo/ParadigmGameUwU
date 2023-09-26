using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Bullet
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Aceleration { get; set; }

        public float radio { get; set; }

        public bool isActive;
        private int speed = 400;


        IntPtr image;

        public Bullet(Vector2 position, Vector2 dir)
        {
            Position = position;
            Velocity = Physics.Mul(dir, speed);
            radio = 29.5f;
            
            isActive = true;
            image = Engine.LoadImage("assets/Bullet/hachad.png");

            //CreateAnimations();
            //currentAnimation = idleAnimation;
        }

        public void Update()
        {
            
            //currentAnimation.Update();

        }

        public void Render() 
        {
            if (isActive)
            {
                Engine.Draw(image, Position.x, Position.y);
            }
            
        }
        /*
        public void Autodestroy()
        {
            if (timer > 3)
            {
                //Destroy
            }
        }
        */

}
}
