using System;
using MyGame.assets;

namespace MyGame
{
    public class Renderer
    {
        public void RenderImage(IntPtr image, Vector2 position)
        {
            Engine.Draw(image, position.x ,position.y);
        }
        public void RenderImage(IntPtr image, float x, float y)
        {
            Engine.Draw(image, x ,y);
        }
    }
}