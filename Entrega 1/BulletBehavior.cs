namespace MyGame
{
    public class BulletBehavior
    {
        public void Update(Bullet bullet)
        {
            if (Physics.Mag(bullet.Velocity) < 0.01 & !bullet.reached)
            {
                bullet.reached = true;
            }

            if (bullet.comingBack)
            {
                var vec = Physics.Res(WaveController.CharacterList[0].Position, bullet.Position);
                var mag = Physics.Mag(vec);
                if ( mag > 300)
                {
                    bullet.Velocity = Physics.Mul(vec, 3.5f);   
                }
                else if ( mag > 200)
                {
                    bullet.Velocity = Physics.Mul(vec, 5f);   
                }
                else
                {
                    var nor = Physics.Nor(vec);
                    bullet.Velocity = Physics.Mul(nor, 1250);
                }

                if (bullet.Velocity.x > 0)
                {
                    bullet.currentAnimation = bullet.backAnimationR;
                }
                else if(bullet.Velocity.x < 0)
                {
                    bullet.currentAnimation = bullet.backAnimationL;
                }
            }
            if (!bullet.comingBack)
            {
                if (bullet.Velocity.x > 0)
                {
                    bullet.currentAnimation = bullet.moovingAnimationR;
                    
                }
                else if(bullet.Velocity.x < 0)
                {
                    bullet.currentAnimation = bullet.moovingAnimationL;
                    
                }
            }
        }
    }
}