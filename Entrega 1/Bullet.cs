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
        public float radius { get; private set; }
        public bool reached { get; set; }
        public bool comingBack { get; set; }
        public bool isRight { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public bool isActive { get; set; }
        private int speed = 400;

        Animation currentAnimation;
        Animation moovingAnimationL;
        Animation moovingAnimationR;
        Animation backAnimationR;
        Animation backAnimationL;


        IntPtr image;
        IntPtr image2;
        IntPtr image3;

        public Bullet(Vector2 position, Vector2 dir)
        {
            Position = position;
            Velocity = Physics.Mul(dir, speed);
            radius = 27;
            reached = false;
            comingBack = false;
            isActive = false;
            width = 38;
            height = 38;
            mass = 1;
            image = Engine.LoadImage("assets/Bullet/hachad.png");
            image2 = Engine.LoadImage("assets/Bullet/axeFloorL.png");
            image3 = Engine.LoadImage("assets/Bullet/axeFloorR.png");

            CreateAnimations();

        }
        private void CreateAnimations()
        {
            List<IntPtr> moovingAxeL = new List<IntPtr>();
             for (int i = 1; i < 10; i++)
             {
                 IntPtr frame = Engine.LoadImage($"assets/Animation/axe/leftAxe/{i}.png");
                moovingAxeL.Add(frame);
             }
             moovingAnimationL = new Animation("Moving Right Axes", moovingAxeL, 0.03f, true);

            List<IntPtr> moovingAxeR = new List<IntPtr>();
            for (int i = 1; i < 10; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Animation/axe/rightAxe/{i}.png");
                moovingAxeR.Add(frame);
            }
            moovingAnimationR = new Animation("Moving Right Axes", moovingAxeR, 0.03f, true);


            List<IntPtr> backAxeL = new List<IntPtr>();
            for (int i = 1; i < 10; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Animation/axe/leftAxe/back/{i}.png");
                backAxeL.Add(frame);
            }
            backAnimationL = new Animation("Moving Right Axes", backAxeL, 0.03f, true);


            List<IntPtr> backAxeR = new List<IntPtr>();
            for (int i = 1; i < 10; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Animation/axe/rightAxe/back/{i}.png");
                backAxeR.Add(frame);
            }
            backAnimationR = new Animation("Moving Right Axes", backAxeR, 0.03f, true);


        }

        public void Update()
        {
            if (Physics.Mag(Velocity) < 0.1 & !reached)
            {
                reached = true;
            }

            if (comingBack)
            {
                var vec = Physics.Res(WaveController.CharacterList[0].Position, Position);
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

                if (Velocity.x > 0)
                {
                    currentAnimation = backAnimationR;
                }
                else if(Velocity.x < 0)
                {
                    currentAnimation = backAnimationL;
                }
            }
            if (!comingBack)
            {
                if (Velocity.x > 0)
                {
                    currentAnimation = moovingAnimationR;
                    
                }
                else if(Velocity.x < 0)
                {
                    currentAnimation = moovingAnimationL;
                    
                }
            }

            currentAnimation.Update();

        }

        public void Render()
        {
            if (isActive)
            {
                if (Velocity == new Vector2(0, 0))
                {
                    if (isRight)
                    {
                        Engine.Draw(image3, Position.x - WaveController.camera.Position.x, Position.y - WaveController.camera.Position.y);
                    }
                    else
                    {
                        Engine.Draw(image2, Position.x - WaveController.camera.Position.x, Position.y - WaveController.camera.Position.y);
                    }
                    
                }
                else
                {
                    Engine.Draw(currentAnimation.CurrentFrame, Position.x - WaveController.camera.Position.x, Position.y - WaveController.camera.Position.y);
                }

            }
        }
       

    }
}
