using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris.Scenes
{
    class ScoreInfo
    {
        Highscores scores;
        bool high = false;
        ulong score = 0;
        public void Init()
        {
            score = Program.game.Score;
            scores = Highscores.Load();
            high = scores.TryPut(score);
        }

        bool asked = false;
        bool drawed = false;
        string name = "";
        int place = -1;
        public void Update()
        {
            if (high)
            {
                if (drawed && !asked)
                {
                    Renderer.StopDrawing = true;
                    while (!Renderer.DrawEnded) ;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.CursorTop = 13;
                    Console.CursorLeft = 15;
                    name = Console.ReadLine();
                    Renderer.StopDrawing = false;
                    asked = true;
                    place = scores.PutScore(score, name);
                    Highscores.Save(scores);
                }
            }
            if (high && asked)
            {
                if (ConsoleKeyboard.KeyAvailable)
                {
                    if (ConsoleKeyboard.PressedKey == ConsoleKey.Escape)
                    {
                        Program.game.Place = place;
                        Program.game.SwitchScene(3);
                    }
                }
            }
        }

        public void Draw()
        {
            string info = "";
            Renderer.DrawRectangle(new Rectangle(11, 9, 32, 7), ConsoleColor.Yellow);
            Renderer.DrawString("╔══════════════════════════════╗", new Vector2(11, 9), ConsoleColor.Black);
            for (int i = 10; i < 15; i++)
            {
                Renderer.DrawString("║                              ║", new Vector2(11, i), ConsoleColor.Black);
            }
            Renderer.DrawString("╚══════════════════════════════╝", new Vector2(11, 15), ConsoleColor.Black);
            Renderer.DrawRectangle(new Rectangle(12, 10, 30, 5), ConsoleColor.Cyan);
            Renderer.DrawString("GAME OVER", new Vector2(23, 9), ConsoleColor.Black);
            if (!high)
            {
                info = "YOUR SCORE: " + score;
                Renderer.DrawString(info, new Vector2(27-(info.Length/2), 12), ConsoleColor.Black);
            }
            else
            {
                info = "YOU HAVE HIGHSCORE!";
                Renderer.DrawString(info, new Vector2(27 - (info.Length / 2), 11), ConsoleColor.Black);
                if (!asked)
                {
                    Renderer.DrawRectangle(new Rectangle(14, 13, 26, 1), ConsoleColor.Blue);
                    info = score.ToString();
                    Renderer.DrawString(info, new Vector2(39 - (info.Length), 13), ConsoleColor.White);
                }
                else
                {
                    Renderer.DrawRectangle(new Rectangle(14, 13, 26, 1), ConsoleColor.Green);
                    info = score.ToString();
                    Renderer.DrawString(name, new Vector2(15, 13), ConsoleColor.Black);
                    Renderer.DrawString(info, new Vector2(39 - (info.Length), 13), ConsoleColor.Black);
                }
            }
            drawed = true;
        }

        public void PlayMusic()
        {
            NotePlayer.PlayTune(new Tunes.EndTune());
        }
    }
}
