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

        public int width { get; set; }
        public int height { get; set; }
        public float radio  { get; set; }
        public float r { get; set; }
        public float w { get; set; }
        public float ar { get; set; }
        public float mass { get; set; }
        public int health { get; set; }

        public int ammo { get; set; }
        private float timer = 1;

        IntPtr image;
        //Animation currentAnimation;
        //Animation idleAnimation;


        public Character(float x, float y, float radio,  string image, int width, int height, float mass = 1, int ammo = 3)
        {

            Position = new Vector2(x, y);
            this.radio = radio;
            this.width = width;
            this.height = height;
            this.mass = mass;
            this.ammo = ammo;

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
                Physics.AddForce(this , new Vector2(-300,0));
            }

            if (Engine.KeyPress(Engine.KEY_RIGHT)) 
            {
                Physics.AddForce(this, new Vector2(300,0));
            }

            if (Engine.KeyPress(Engine.KEY_UP)) 
            {
                Physics.AddForce(this, new Vector2(0,-300));
            }

            if (Engine.KeyPress(Engine.KEY_DOWN)) 
            {
                Physics.AddForce(this, new Vector2(0,300));
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
            if (Program.BulletListNotActive.Any())
            {
                var bullet = Program.BulletListNotActive[0];
                bullet.isActive = true;
                bullet.Position = newPosition;
                bullet.Velocity = Physics.Mul(dir, 500);
                Program.BulletListActive.Add(bullet);
                Program.BulletListNotActive.Remove(bullet);
            }
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
                        if (ammo > 0)
                        {
                            ammo--;
                            Shot(dir);
                        }
                    }
                }
            }
        }

        /*public void reload()
        {
            foreach (var bullet in Program.BulletList)
            {
                if (bullet.isActive)
                {
                    
                }
            }
        }*/

    }
}
