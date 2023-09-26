using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.assets;

namespace MyGame
{
    public class Character
    {
        public  Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Aceleration { get; set; }


        public float radio = 0;
        public float r;
        public float w;
        public float ar;
        public float mass;
        public int health = 5;
        private float timer = 1;

        IntPtr image;
        //Animation currentAnimation;
        //Animation idleAnimation;


        public Character(float x, float y, float radio, float r, float w, float ar, float mass, string image)
        {

            Position = new Vector2(x, y);
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
            timer += Program.DeltaTime;
            Shooting();
            if (Engine.KeyPress(Engine.KEY_LEFT)) 
            {
                Physics.AddForce(this , new Vector2(-100,0));
            }

            if (Engine.KeyPress(Engine.KEY_RIGHT)) 
            {
                Physics.AddForce(this, new Vector2(100,0));
            }

            if (Engine.KeyPress(Engine.KEY_UP)) 
            {
                Physics.AddForce(this, new Vector2(0,-100));
            }

            if (Engine.KeyPress(Engine.KEY_DOWN)) 
            {
                Physics.AddForce(this, new Vector2(0,100));
            }

            if (Engine.KeyPress(Engine.KEY_ESP))
            {
                // futuro powerup
            }

            //currentAnimation.Update();

           
        }

        public void Render()
        {
            //Engine.Draw(currentAnimation.CurrentFrame, x, y);
            Engine.Draw(image, Position.x,Position.y);
        }

        /*public void Lose()
        {
            if (health == 0)
            {
                pantalla derrota
            }
        }

        public void Win()
        {
            if (Program.EnemyList.Any())
            {
                pantalla victoria
                Engine.Debug("ganaste wachin");
            }
        }
        */


        public void Shot(Vector2 dir)
        {
            int widthPlayer = 101;
            int widthAxe = 15;
            int heightPlayer = 38;
            double heightAxe = 29.5;
            Vector2 newPosition =new Vector2(Position.x+widthPlayer-widthAxe,(float)(Position.y+heightPlayer-heightAxe));
            Program.BulletList.Add((new Bullet(newPosition, dir)));
        }

        public void Shooting()
        {
            foreach (Enemy enemy in Program.EnemyList)
            {
                if (enemy.isActive)
                {
                    Vector2 vec = Physics.Res(enemy.Position, Position);
                    Vector2 dir = Physics.Nor(vec);
                    float mag = Physics.Mag(vec);

                    if (mag < 300 && timer > 1)
                    {
                        timer = 0;
                        Shot(dir);
                    }
                }
            }
        }

    }
}
