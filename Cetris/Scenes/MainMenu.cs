using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris.Scenes
{
    class MainMenu
    {
        int selectedItem = 0;

        public void Init()
        {
            selectedItem = 0;
        }

        public void Update()
        {
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow: selectedItem = (selectedItem + 1) % 3; break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow: selectedItem = selectedItem - 1; if (selectedItem < 0) selectedItem = 2; break;
                    case ConsoleKey.Enter:
                        switch (selectedItem)
                        {
                            case 0: Program.game.SwitchScene(1); break;
                            case 1: Program.game.Place = -1; Program.game.SwitchScene(3); break;
                            case 2: Program.Running = false; break;
                        }
                        break;
                }
            }
        }

        public void DrawLogo()
        {
            int moveX = 2;
            int moveY = -1;

            
            Renderer.DrawRectangle(new Rectangle(8 + moveX, 2 + moveY, 3, 1), ConsoleColor.Yellow);
            Renderer.DrawRectangle(new Rectangle(8 + moveX, 6 + moveY, 3, 1), ConsoleColor.Yellow);
            Renderer.DrawRectangle(new Rectangle(7 + moveX, 3 + moveY, 1, 3), ConsoleColor.Yellow);
            Renderer.DrawRectangle(new Rectangle(11 + moveX, 3 + moveY, 1, 1), ConsoleColor.Yellow);
            Renderer.DrawRectangle(new Rectangle(11 + moveX, 5 + moveY, 1, 1), ConsoleColor.Yellow);

            Renderer.DrawRectangle(new Rectangle(13 + moveX, 2 + moveY, 5, 1), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(13 + moveX, 4 + moveY, 3, 1), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(13 + moveX, 6 + moveY, 5, 1), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(13 + moveX, 2 + moveY, 1, 4), ConsoleColor.Cyan);

            Renderer.DrawRectangle(new Rectangle(22 + moveX, 2 + moveY, 1, 5), ConsoleColor.Red);
            Renderer.DrawRectangle(new Rectangle(20 + moveX, 2 + moveY, 5, 1), ConsoleColor.Red);

            Renderer.DrawRectangle(new Rectangle(27 + moveX, 2 + moveY, 4, 1), ConsoleColor.Blue);
            Renderer.DrawRectangle(new Rectangle(27 + moveX, 2 + moveY, 1, 5), ConsoleColor.Blue);
            Renderer.DrawRectangle(new Rectangle(31 + moveX, 3 + moveY, 1, 1), ConsoleColor.Blue);
            Renderer.DrawRectangle(new Rectangle(27 + moveX, 4 + moveY, 4, 1), ConsoleColor.Blue);
            Renderer.DrawRectangle(new Rectangle(30 + moveX, 5 + moveY, 1, 1), ConsoleColor.Blue);
            Renderer.DrawRectangle(new Rectangle(31 + moveX, 6 + moveY, 1, 1), ConsoleColor.Blue);

            Renderer.DrawRectangle(new Rectangle(34 + moveX, 2 + moveY, 1, 5), ConsoleColor.Green);

            Renderer.DrawRectangle(new Rectangle(38 + moveX, 2 + moveY, 3, 1), ConsoleColor.Magenta);
            Renderer.DrawRectangle(new Rectangle(37 + moveX, 3 + moveY, 1, 1), ConsoleColor.Magenta);
            Renderer.DrawRectangle(new Rectangle(38 + moveX, 4 + moveY, 3, 1), ConsoleColor.Magenta);
            Renderer.DrawRectangle(new Rectangle(41 + moveX, 5 + moveY, 1, 1), ConsoleColor.Magenta);
            Renderer.DrawRectangle(new Rectangle(38 + moveX, 6 + moveY, 3, 1), ConsoleColor.Magenta);
            Renderer.DrawString(" ▓▓▓  ▓▓▓▓▓  ▓▓▓▓▓  ▓▓▓▓   ▓   ▓▓▓", new Vector2(7 + moveX, 2 + moveY), ConsoleColor.DarkGray);
            Renderer.DrawString("▒   ▒ ▒        ▒    ▒   ▒  ▒  ▒", new Vector2(7 + moveX, 3 + moveY), ConsoleColor.Black);
            Renderer.DrawString("▒     ▒▒▒      ▒    ▒▒▒▒   ▒   ▒▒▒", new Vector2(7 + moveX, 4 + moveY), ConsoleColor.Black);
            Renderer.DrawString("░   ░ ░        ░    ░  ░   ░      ░", new Vector2(7 + moveX, 5 + moveY), ConsoleColor.Black);
            Renderer.DrawString(" ░░░  ░░░░░    ░    ░   ░  ░   ░░░", new Vector2(7 + moveX, 6 + moveY), ConsoleColor.Black);
        }

        public void Draw()
        {
            Renderer.Clean();
            DrawLogo();
            Renderer.DrawRectangle(new Rectangle(14, 7, 25, 15), ConsoleColor.Yellow);
            Renderer.DrawString("╔═══════════════════════╗", new Vector2(14, 7),ConsoleColor.Black);
            for (int i = 8; i < 21; i++)
            {
                Renderer.DrawString("║                       ║", new Vector2(14, i), ConsoleColor.Black);
            }
            Renderer.DrawString("╚═══════════════════════╝", new Vector2(14, 21), ConsoleColor.Black);
            Renderer.DrawString("MAIN MENU", new Vector2(22, 7), ConsoleColor.Black);
            Renderer.DrawRectangle(new Rectangle(15, 8, 23, 13), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(17, 9, 19, 3), (selectedItem==0)? ConsoleColor.Blue: ConsoleColor.Green);
            Renderer.DrawString("╔═════════════════╗", new Vector2(17, 9), (selectedItem == 0) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawString("║                 ║", new Vector2(17, 10), (selectedItem == 0) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawString("╚═════════════════╝", new Vector2(17, 11), (selectedItem == 0) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawString("  NEW GAME", new Vector2(21, 10), (selectedItem == 0) ? ConsoleColor.White: ConsoleColor.Black);
            Renderer.DrawRectangle(new Rectangle(17, 13, 19, 3), (selectedItem == 1) ? ConsoleColor.Blue : ConsoleColor.Green);
            Renderer.DrawString("╔═════════════════╗", new Vector2(17, 13), (selectedItem == 1) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawString("║                 ║", new Vector2(17, 14), (selectedItem == 1) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawString("╚═════════════════╝", new Vector2(17, 15), (selectedItem == 1) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawString("HIGH SCORES", new Vector2(21, 14), (selectedItem == 1) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawRectangle(new Rectangle(17, 17, 19, 3), (selectedItem == 2) ? ConsoleColor.Blue : ConsoleColor.Green);

            Renderer.DrawString("╔═════════════════╗", new Vector2(17, 17), (selectedItem == 2) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawString("║                 ║", new Vector2(17, 18), (selectedItem == 2) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawString("╚═════════════════╝", new Vector2(17, 19), (selectedItem == 2) ? ConsoleColor.White : ConsoleColor.Black);
            Renderer.DrawString(" QUIT GAME", new Vector2(22, 18), (selectedItem == 2) ? ConsoleColor.White : ConsoleColor.Black);
            string[] info1 = "Cetris 1.1\nby Tachi23 (c)2016".Split('\n');
            string[] info2 = Renderer.GetVerInfo().Split('\n');
            for (int i = 0; i < info1.Length; i++)
            {
                Renderer.DrawString(info1[i], new Vector2(0, 23+i), ConsoleColor.White);
            }
            for (int i = 0; i < info2.Length; i++)
            {
                Renderer.DrawString(info2[i], new Vector2(54 - info2[i].Length, 23 + i), ConsoleColor.White);
            }
        }

        public void PlayMusic()
        {
                NotePlayer.PlayTune(new Tunes.MiniTune());
        }
    }
}
