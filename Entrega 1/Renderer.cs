using System;
using MyGame.assets;

namespace MyGame
{
    public static class Renderer
    {
        public static void RenderImage(IntPtr image, Vector2 position)
        {
            Engine.Draw(image, position.x ,position.y);
        }
    }
}