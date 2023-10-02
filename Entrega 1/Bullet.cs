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

        Animation currentAnimation;
        Animation moovingAnimation;


        IntPtr image;
        IntPtr image2;
        IntPtr image3;

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
            image2 = Engine.LoadImage("assets/Bullet/axeFloorL.png");
            image3 = Engine.LoadImage("assets/Bullet/axeFloorR.png");

            CreateAnimations();
            currentAnimation = moovingAnimation;
        }
        private void CreateAnimations()
        {
            List<IntPtr> moovingAxe = new List<IntPtr>();
             for (int i = 1; i < 10; i++)
                {
                 IntPtr frame = Engine.LoadImage($"assets/Animation/axe/leftAxe/{i}.png");
                moovingAxe.Add(frame);
                 }
              moovingAnimation = new Animation("Moving Right Axes", moovingAxe, 0.01f, true);

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
            currentAnimation.Update();

        }

        public void Render()
        {
            if (isActive)
            {
                Engine.Draw(currentAnimation.CurrentFrame, Position.x, Position.y);
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
