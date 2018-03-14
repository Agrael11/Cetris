using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris
{
    class Game
    {
        public static Random random;
        public int Scene =-1;
        Scenes.GameScene gameScene = new Scenes.GameScene();
        Scenes.MainMenu mainMenu = new Scenes.MainMenu();
        Scenes.ScoreInfo scoreInfo = new Scenes.ScoreInfo();
        Scenes.HSScene hsScene = new Scenes.HSScene();
        Scenes.IntroLogo logoScene = new Scenes.IntroLogo();

        public int Place = -1;

        private ulong _scoreValue;
        public ulong Score
        {
            get { return _scoreValue; }
            set { if (value > 9999999999) _scoreValue = 9999999999; else _scoreValue = value; }
        }

        public void SwitchScene(int scn)
        {
            Scene = scn;
            switch (scn)
            {
                case -1: logoScene.Init(); PlayMusic(); break;
                case 0: mainMenu.Init(); PlayMusic(); break;
                case 1: gameScene.Init(); PlayMusic(); break;
                case 2: scoreInfo.Init(); PlayMusic(); break;
                case 3: hsScene.Init(); PlayMusic(); break;
            }
        }

        public void Init()
        {
            logoScene.Init();
            PlayMusic();
        }

        public void Update()
        {
            switch (Scene)
            {
                case -1: logoScene.Update(); break;
                case 0: mainMenu.Update(); break;
                case 1: gameScene.Update(); break;
                case 2: scoreInfo.Update(); break;
                case 3: hsScene.Update(); break;
            }
        }

        public bool drawingDone = false;

        public void Draw()
        {
            Renderer.DrawBegin();
            switch (Scene)
            {
                case -1: logoScene.Draw(); break;
                case 0: mainMenu.Draw(); break;
                case 1: gameScene.Draw(); break;
                case 2: gameScene.Draw(); scoreInfo.Draw(); break;
                case 3: hsScene.Draw(); break;
            }
            Renderer.DrawEnd();
        }

        public void PlayMusic()
        {
            switch (Scene)
            {
                case -1: logoScene.PlayMusic(); break;
                case 0: mainMenu.PlayMusic(); break;
                case 1: gameScene.PlayMusic(); break;
                case 2: scoreInfo.PlayMusic(); break;
                case 3: hsScene.PlayMusic(); break;
            }
        }
    }
}
