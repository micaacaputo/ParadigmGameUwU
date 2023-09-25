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

        public bool isActive = false;

        //private Character character;


        IntPtr image;

        public Bullet(float x, float y, /*Character character,*/ string image)
        {

            Position = new Vector2(x, y);
            //this.character = character;
            this.image = Engine.LoadImage(image);

            //CreateAnimations();
            //currentAnimation = idleAnimation;
        }

        public void IsActive(Character Position)
        {
            //asignarle al bullet la posicion del character
            //Bullet.Position = character.Position; o Vector2 characterPosition = character.Position;
            //isActive = true;
        }

        public void Update()
        {
            //Vector2 characterPosition = character.Position;
            //currentAnimation.Update();

            /*if (Engine.KeyPress(Engine.KEY_ESC))
            {
                isActive = true;

            }*/
        }

        public void Render() {

                Engine.Draw(image, Position.x, Position.y);
            
            
            }


}
}
