using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris.Scenes
{
    public class HSScene
    {
        Highscores table;

        public void Init()
        {
            table = Highscores.Load();
        }

        public void Update()
        {
            if (ConsoleKeyboard.KeyAvailable)
            {
                if (ConsoleKeyboard.PressedKey == ConsoleKey.Escape)
                {
                    Program.game.SwitchScene(0);
                }
            }
        }

        public void Draw()
        {
            Renderer.Clean();
            Renderer.DrawRectangle(new Rectangle(11, 1, 32, 23), ConsoleColor.Yellow);
            Renderer.DrawString("╔══════════════════════════════╗", new Vector2(11, 1), ConsoleColor.Black);
            for (int i = 2; i < 23; i++)
            {
                Renderer.DrawString("║                              ║", new Vector2(11, i), ConsoleColor.Black);
            }
            Renderer.DrawString("╚══════════════════════════════╝", new Vector2(11, 23), ConsoleColor.Black);
            Renderer.DrawString("HIGHSCORES TABLE", new Vector2(27 - ("HIGHSCORES TABLE".Length / 2), 1), ConsoleColor.Black);
            Renderer.DrawRectangle(new Rectangle(12, 2, 30, 21), ConsoleColor.Cyan);
            for (int i = 0; i < 10; i++)
            {
                if (Program.game.Place == i)
                {
                    Renderer.DrawRectangle(new Rectangle(14, 3 + (i * 2), 26, 1), ConsoleColor.Blue);
                    Renderer.DrawString(table.names[i], new Vector2(15, 3 + (i * 2)), ConsoleColor.White);
                    Renderer.DrawString(table.scores[i].ToString(), new Vector2(39 - table.scores[i].ToString().Length, 3 + (i * 2)), ConsoleColor.White);
                }
                else
                {
                    Renderer.DrawRectangle(new Rectangle(14, 3 + (i * 2), 26, 1), ConsoleColor.Green);
                    Renderer.DrawString(table.names[i], new Vector2(15, 3 + (i * 2)), ConsoleColor.Black);
                    Renderer.DrawString(table.scores[i].ToString(), new Vector2(39 - table.scores[i].ToString().Length, 3 + (i * 2)), ConsoleColor.Black);
                }
            }
        }
        public void PlayMusic()
        {
            NotePlayer.PlayTune(new Tunes.ScoreTune());
        }
    }
}
