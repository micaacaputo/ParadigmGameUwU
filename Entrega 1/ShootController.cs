﻿using System.Linq;
using MyGame.assets;

namespace MyGame
{
    public class ShootController
    {
        private float timer = 1;

        public void Update(Character character)
        {
            timer += Program.DeltaTime;
            Shooting(character);
        }
        public void reload()
        {
            foreach (var bullet in LevelController.BulletListActive)
            {
                if (bullet.reached)
                {
                    bullet.comingBack = true;
                }
            }
        }
        public void Shooting(Character character)
        {
            foreach (Enemy enemy in LevelController.EnemyList)
            {
                if (enemy.isActive)
                {
                    Vector2 vec = Physics.Res(enemy.Position, character.Position);
                    Vector2 dir = Physics.Nor(vec);
                    float mag = Physics.Mag(vec);

                    if (mag < 300 && timer > 1)
                    {
                        timer = 0;
                        if (character.ammo > 0)
                        {
                            character.ammo--;
                            Shot(dir, character);

                        }
                    }
                }
            }
        }
        public void Shot(Vector2 dir, Character character)
        {


            if (LevelController.BulletListNotActive.Any())
            {
                var bullet = LevelController.BulletListNotActive[0];
                Vector2 newPosition =new Vector2(character.Position.x+character.width-bullet.width, character.Position.y+character.height-bullet.height + 27);
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
                LevelController.BulletListActive.Add(bullet);
                LevelController.BulletListNotActive.Remove(bullet);
            }
        }
    }
}