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
        public float mass { get; set; }
        public float radio { get; private set; }
        public bool reached { get; set; }
        public bool comingBack { get; set; }

        public bool isActive;
        private int speed = 400;


        IntPtr image;

        public Bullet(Vector2 position, Vector2 dir)
        {
            Position = position;
            Velocity = Physics.Mul(dir, speed);
            radio = 29.5f;
            reached = false;
            comingBack = false;
            isActive = false;
            mass = 1;
            image = Engine.LoadImage("assets/Bullet/hachad.png");

            //CreateAnimations();
            //currentAnimation = idleAnimation;
        }

        public void Update()
        {
            if (Physics.Mag(Velocity) < 0.1 & !reached)
            {
                reached = true;
            }

            if (comingBack)
            {
                var vec = Physics.Res(Program.CharacterList[0].Position, Position);
                var mag = Physics.Mag(vec);
                if ( mag > 100)
                {
                    Velocity = Physics.Mul(vec, 3.5f);   
                }
                else
                {
                    var nor = Physics.Nor(vec);
                    Velocity = Physics.Mul(nor, 1250);
                }
            }
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
