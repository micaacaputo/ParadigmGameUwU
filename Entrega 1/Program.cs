

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using MyGame.assets;
using Tao.Sdl;

namespace MyGame
{

    class Program
    {
        private static DateTime _startTime;
        private static float _lastTimeFrame;
        public static float DeltaTime;

        private static void Main(string[] args)
        {
            _startTime = DateTime.Now;
            GameManager.Instance.Initialize();

            while (true)
            {
                CalculateDeltaTime();
                GameManager.Instance.Update();

                GameManager.Instance.Render();

                Sdl.SDL_Delay(5);
            }
        }
        private static void CalculateDeltaTime()
        {
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;
        }
    }
}
        