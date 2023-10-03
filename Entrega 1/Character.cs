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
        public int width { get; }
        public int height { get; }
        public float radius  { get; }
        public float mass { get; }
        public int health { get; set; }

        public int ammo { get; set; }
        private float timer = 1;
        private float timer2 = 1;

        IntPtr image;
        IntPtr image2;
        //Animation currentAnimation;
        //Animation idleAnimation;


        public Character(float x, float y, float radius, int width, int height, float mass = 1, int ammo = 3)
        {

            Position = new Vector2(x, y);
            this.radius = radius;
            this.width = width;
            this.height = height;
            this.mass = mass;
            this.ammo = ammo;
            health = 1;

            image = Engine.LoadImage("assets/Character/character.png");
            image2 = Engine.LoadImage("assets/Character/body.png");
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
            timer2 += Program.DeltaTime;
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
                if (timer2 > 3)
                {
                    timer2 = 0;
                    reload();
                }
                
            }

            //currentAnimation.Update();

           
        }

        public void Render()
        {
            //Engine.Draw(currentAnimation.CurrentFrame, x, y);
            Engine.Draw(image, Position.x - WaveController.camera.Position.x,Position.y - WaveController.camera.Position.y);
            Engine.Draw(image2,(Position.x - 26)- WaveController.camera.Position.x,(Position.y + 56)- WaveController.camera.Position.y);
        }

        public void HealthDown()
        {
                health--;
                Dead();
        }

        public void Dead()
        {
            if (health < 0)
            {
                GameManager.Instance.ChangeCondition(3);
            }
            
        }

        //public void Win()
        //{
        //    if (Program.EnemyList.Any())
        //    {
        //        GameManager.Instance.ChangeCondition(2);
        //    }
        //}


        public void Shot(Vector2 dir)
        {


            if (WaveController.BulletListNotActive.Any())
            {
                var bullet = WaveController.BulletListNotActive[0];
                Vector2 newPosition =new Vector2(Position.x+width-bullet.width, Position.y+height-bullet.height + 27);
                if (dir.x > 0)
                {
                    bullet.isRight = true;
                }
                else
                {
                    bullet.isRight = false;
                }
                bullet.isActive = true;
                bullet.Position = newPosition;
                bullet.Velocity = Physics.Mul(dir, 500);
                WaveController.BulletListActive.Add(bullet);
                WaveController.BulletListNotActive.Remove(bullet);
            }
        }

        public void Shooting()
        {
            foreach (Enemy enemy in WaveController.EnemyList)
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

        public void reload()
        {
            foreach (var bullet in WaveController.BulletListActive)
            {
                if (bullet.reached)
                {
                    bullet.comingBack = true;
                }
            }
        }

    }
}
