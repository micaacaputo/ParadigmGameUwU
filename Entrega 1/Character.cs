using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.assets;

namespace MyGame
{
    public class Character : GameObject
    {
        public int health { get; set; }

        public int ammo { get; set; }
        public InputCharacterController InputCharacterController;
        public ShootController ShootController;

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
            InputCharacterController = new InputCharacterController();
            ShootController = new ShootController();

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
            ShootController.Update(this);
            InputCharacterController.Update(this, ShootController);
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
            if (health <= 0)
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


        

        

        

    }
}
