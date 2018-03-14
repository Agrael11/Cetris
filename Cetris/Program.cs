using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cetris
{
    class Program
    {
        public static bool Running = true;

        private static Thread keyThread;
        private static Thread render;

        public static Game game;

        private static void Main(string[] args)
        {
            Console.Clear();
            Renderer.Init();
            Renderer.WindowSize = new ConsoleGameUtilities.Vector2(54,25);
            NotePlayer.Init();
            game = new Game();
            game.Init();
            keyThread = new Thread(ConsoleKeyboard.CheckKey);
            render = new Thread(RenderDraw);
            keyThread.Start();
            render.Start();
            while (Running)
            {
                Thread.Sleep(33);
                game.Update();
                game.Draw();
            }
            NotePlayer.Stop = true;
            keyThread.Abort();
            render.Abort();
        }

        private static void RenderDraw()
        {
            while (Running)
            {
                Renderer.Draw();
            }
        }
    }
}
