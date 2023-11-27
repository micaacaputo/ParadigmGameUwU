using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Bullet : GameObject
    {
        public bool reached { get; set; }
        public bool comingBack { get; set; }
        public bool isRight { get; set; }

        public bool isActive { get; set; }
        private int speed = 400;
        public BulletBehavior BulletBehavior;
        public Animation currentAnimation;
        public Animation moovingAnimationL;
        public Animation moovingAnimationR;
        public Animation backAnimationR;
        public Animation backAnimationL;
        
        private IntPtr image2;
        private IntPtr image3;

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
            image2 = Engine.LoadImage("assets/Bullet/axeFloorL.png");
            image3 = Engine.LoadImage("assets/Bullet/axeFloorR.png");
            BulletBehavior = new BulletBehavior();
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
             moovingAnimationL = new Animation("Moving Left Axes", moovingAxeL, 0.03f, true);

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
            backAnimationL = new Animation("Moving Back Left Axes", backAxeL, 0.03f, true);


            List<IntPtr> backAxeR = new List<IntPtr>();
            for (int i = 1; i < 10; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Animation/axe/rightAxe/back/{i}.png");
                backAxeR.Add(frame);
            }
            backAnimationR = new Animation("Moving Back Right Axes", backAxeR, 0.03f, true);


        }

        public void Update()
        {
            
            BulletBehavior.Update(this);
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
                        Engine.Draw(image3, Position.x - LevelController.camera.Position.x, Position.y - LevelController.camera.Position.y);
                    }
                    else
                    {
                        Engine.Draw(image2, Position.x - LevelController.camera.Position.x, Position.y - LevelController.camera.Position.y);
                    }
                    
                }
                else
                {
                    Engine.Draw(currentAnimation.CurrentFrame, Position.x - LevelController.camera.Position.x, Position.y - LevelController.camera.Position.y);
                }

            }
        }
       

    }
}
