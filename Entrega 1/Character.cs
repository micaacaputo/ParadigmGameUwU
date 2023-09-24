using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Character
    {

        public float x;
        public float y;
        public float velX = 0;
        public float velY = 0;
        public float aceX = 0;
        public float aceY = 0;
        public float radio = 0;
        public float r;
        public float w;
        public float ar;
        public float mass;
        public int health = 5;

        IntPtr image;
        //Animation currentAnimation;
        //Animation idleAnimation;


        public Character(float x, float y, float velX, float velY, float aceX, float aceY, float radio, float r, float w, float ar, float mass, string image)
        {
            this.x = x;
            this.y = y;
            this.velX = velX;
            this.velY = velY;
            this.aceX = aceX;
            this.aceY = aceY;
            this.radio = radio;
            this.r = r;
            this.w = w;
            this.ar = ar;
            this.mass = mass;

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
            if (Engine.KeyPress(Engine.KEY_LEFT)) 
            {
                Physics.AddForce(this , -100, 0);
            }

            if (Engine.KeyPress(Engine.KEY_RIGHT)) 
            {
                Physics.AddForce(this, 100, 0);
            }

            if (Engine.KeyPress(Engine.KEY_UP)) 
            {
                Physics.AddForce(this, 0, -100);
            }

            if (Engine.KeyPress(Engine.KEY_DOWN)) 
            {
                Physics.AddForce(this, 0, 100);
            }

            if (Engine.KeyPress(Engine.KEY_ESC)) 
            { 
                //que dispare ??
            }

            //currentAnimation.Update();

           
        }

        public void Render()
        {
            //Engine.Draw(currentAnimation.CurrentFrame, x, y);
            Engine.Draw(image, x,y);
        }

    }
}
