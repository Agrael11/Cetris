using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris.Scenes
{
    class GameScene
    {
        private uint _lives;
        private uint _level;

        private Block _nextBlock;
        private Block _currentBlock;
        private Vector2 _currentPos;

        private Bit[,] _map = new Bit[10, 20];

        private int _timer = 0;
        private float _timerMax = 80;

        private int _fails = 0;

        private bool _linePause = false;
        private List<int> linesToRemove;




        private void DrawBasicGUI()
        {
            Renderer.DrawRectangle(new Rectangle(4, 2, 24, 21), ConsoleColor.White);
            for (int i = 2; i < 25; i++)
            {
                Renderer.DrawString("║║                    ║║", new Vector2(4, i), ConsoleColor.Black);
            }
            Renderer.DrawString("╚╩════════════════════╩╝", new Vector2(4, 22), ConsoleColor.Black);
            Renderer.DrawRectangle(new Rectangle(6, 2, 20, 20), ConsoleColor.Black);
            for (int i = 2; i < 22; i++)
            {
                Renderer.DrawString("░░░░░░░░░░░░░░░░░░░░", new Vector2(6, i), ConsoleColor.DarkBlue);
            }
            Renderer.DrawString("NEXT", new Vector2(40, 2), ConsoleColor.White);
            Renderer.DrawRectangle(new Rectangle(34, 4, 16, 8), ConsoleColor.White);
            Renderer.DrawRectangle(new Rectangle(36, 5, 12, 6), ConsoleColor.Black);
            Renderer.DrawString("╔╦════════════╦╗", new Vector2(34, 4), ConsoleColor.Black);
            for (int i = 5; i < 11; i++)
            {
                Renderer.DrawString("║║            ║║", new Vector2(34, i), ConsoleColor.Black);
            }
            Renderer.DrawString("╚╩════════════╩╝", new Vector2(34, 11), ConsoleColor.Black);
            Renderer.DrawString("LIVES:", new Vector2(34, 17), ConsoleColor.White);
            Renderer.DrawString("LINES:", new Vector2(34, 19), ConsoleColor.White);
            Renderer.DrawString("SCORE:", new Vector2(34, 21), ConsoleColor.White);
        }
        private void DrawGUIStats()
        {
            ConsoleGameUtilities.Renderer.DrawString(_lives.ToString(), new ConsoleGameUtilities.Vector2(40, 17), ConsoleColor.White);
            ConsoleGameUtilities.Renderer.DrawString(_level.ToString(), new ConsoleGameUtilities.Vector2(40, 19), ConsoleColor.White);
            ConsoleGameUtilities.Renderer.DrawString(Program.game.Score.ToString(), new ConsoleGameUtilities.Vector2(40, 21), ConsoleColor.White);
        }
        private void DrawNextBlock(Block block)
        {
            Renderer.DrawRectangle(new Rectangle(36, 5, 12, 6), ConsoleColor.Black);
            int x = 38;
            int y = 6;
            Vector2 size = block.GetSize();
            x += (8 - (size.X * 2)) / 2;
            y += (4 - size.Y) / 2;
            block.RenderBlock(new Vector2(x, y));
        }



        private void GenerateNextBlock()
        {
            Block.BLOCKTYPE type = Block.RandomBlockType();
            Block.Colors color = Block.RandomColor();
            byte rotation = (byte)Game.random.Next(0, 4);
            _nextBlock = Block.GetBlock(type, color, rotation);
        }

        private void CleanMap()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    _map[x, y] = new Bit();
                    _map[x, y].Exists = false;
                    _map[x, y].Color = ConsoleColor.Black;
                }
            }
        }

        private void PlaceIntoMap(Block block, Vector2 position)
        {
            bool[,] bmap = block.GetMap();
            ConsoleColor color = block.color;
            for (int x = 0; x < block.GetSize().X; x++)
            {
                for (int y = 0; y < block.GetSize().Y; y++)
                {
                    if (bmap[x, y])
                    {
                        _map[position.X + x, position.Y + y].Exists = true;
                        _map[position.X + x, position.Y + y].Color = color;
                    }
                }
            }
        }

        private void DrawMap()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (_map[x, y].Exists)
                    {
                        Renderer.DrawPoint(new Vector2(x * 2 + 6, y + 2), _map[x, y].Color);
                        Renderer.DrawPoint(new Vector2(x * 2 + 7, y + 2), _map[x, y].Color);
                        if (!_map[x,y].Special) Renderer.DrawString("▓▓", new Vector2(x * 2 + 6, y + 2), ConsoleColor.Gray);
                        else Renderer.DrawString("▒▒", new Vector2(x * 2 + 6, y + 2), ConsoleColor.Gray);
                    }
                    else
                    {
                        Renderer.DrawPoint(new Vector2(x * 2 + 6, y + 2), ConsoleColor.Black);
                        Renderer.DrawPoint(new Vector2(x * 2 + 7, y + 2), ConsoleColor.Black);
                        Renderer.DrawString("░░", new Vector2(x * 2 + 6, y + 2), ConsoleColor.DarkBlue);
                    }
                }
            }
        }

        private void RotateCheck()
        {
            _currentBlock.Rotate();
            bool[,] bmap = _currentBlock.GetMap();

            //VERTICAL
            bool blocked = false;
            if ((_currentPos.Y < 0) || (_currentPos.Y + _currentBlock.GetSize().Y > 20))
            {
                blocked = true;
            }
            for (int x = 0; x < _currentBlock.GetSize().X; x++)
            {
                for (int y = 0; y < _currentBlock.GetSize().Y; y++)
                {
                    if ((_currentPos.X + x >= 0) && (_currentPos.X + x < 10) && (_currentPos.Y + y >= 0) && (_currentPos.Y + y < 20))
                        if ((bmap[x, y]) && (_map[_currentPos.X + x, _currentPos.Y + y].Exists))
                        {
                            blocked = true;
                        }
                }
            }

            if (blocked)
            {
                _currentBlock.Rotate();
                _currentBlock.Rotate();
                _currentBlock.Rotate();
            }
            else
            {
                //HORIZONTAL
                if ((_currentPos.X < 0) || (_currentPos.X + _currentBlock.GetSize().X > 10))
                {
                    _currentPos.X = 10 - _currentBlock.GetSize().X;
                }

                for (int x = 0; x < _currentBlock.GetSize().X; x++)
                {
                    for (int y = 0; y < _currentBlock.GetSize().Y; y++)
                    {
                        if ((_currentPos.X + x >= 0) && (_currentPos.X + x < 10) && (_currentPos.Y + y >= 0) && (_currentPos.Y + y < 20))
                            if ((bmap[x, y]) && (_map[_currentPos.X + x, _currentPos.Y + y].Exists))
                            {
                                _currentPos.X = _currentPos.X + x - _currentBlock.GetSize().X;
                            }
                    }
                }
            }
        }

        private bool CheckMoveHorizontal(int move)
        {
            bool blocked = false;

            _currentPos.X += move;
            //BOUNDS
            if ((_currentPos.X < 0) || (_currentPos.X + _currentBlock.GetSize().X > 10))
            {
                blocked = true;
            }
            //COLISIONS
            bool[,] bmap = _currentBlock.GetMap();
            for (int x = 0; x < _currentBlock.GetSize().X; x++)
            {
                for (int y = 0; y < _currentBlock.GetSize().Y; y++)
                {
                    if ((_currentPos.X + x >= 0) && (_currentPos.X + x < 10) && (_currentPos.Y + y >= 0) && (_currentPos.Y + y < 20))
                        if ((bmap[x, y]) && (_map[_currentPos.X + x, _currentPos.Y + y].Exists))
                        {
                            blocked = true;
                        }
                }
            }

            if (blocked)
            {
                _currentPos.X -= move;
            }

            return blocked;
        }
        private bool CheckMoveVertical(int move)
        {
            bool blocked = false;

            _currentPos.Y += move;
            //BOUNDS
            if ((_currentPos.Y < 0) || (_currentPos.Y + _currentBlock.GetSize().Y > 20))
            {
                blocked = true;
            }

            //COLISIONS
            bool[,] bmap = _currentBlock.GetMap();
            for (int x = 0; x < _currentBlock.GetSize().X; x++)
            {
                for (int y = 0; y < _currentBlock.GetSize().Y; y++)
                {
                    if ((_currentPos.X + x >= 0) && (_currentPos.X + x < 10) && (_currentPos.Y + y >= 0) && (_currentPos.Y + y < 20))
                        if ((bmap[x, y]) && (_map[_currentPos.X + x, _currentPos.Y + y].Exists))
                        {
                            blocked = true;
                        }
                }
            }

            if (blocked)
            {
                _currentPos.Y -= move;
            }
            return blocked;
        }

        private void GetNextCurrent()
        {
            _currentBlock = _nextBlock;
            _currentPos = new Vector2(4, 0);
            bool[,] bmap = _currentBlock.GetMap();
            for (int x = 0; x < _currentBlock.GetSize().X; x++)
            {
                for (int y = 0; y < _currentBlock.GetSize().Y; y++)
                {
                    if ((_currentPos.X + x >= 0) && (_currentPos.X + x < 10) && (_currentPos.Y + y >= 0) && (_currentPos.Y + y < 20))
                        if ((bmap[x, y]) && (_map[_currentPos.X + x, _currentPos.Y + y].Exists))
                        {
                            Program.game.SwitchScene(2);
                        }
                }
            }
        }






        public void Init()
        {
            Program.game.Score = 0;
            _lives = 5;
            _level = 0;

            Game.random = new Random();

            Renderer.DrawBegin();
            Renderer.Clean();
            DrawBasicGUI();
            DrawGUIStats();
            CleanMap();
            GenerateNextBlock();
            GetNextCurrent();
            GenerateNextBlock();
            DrawMap();
            DrawNextBlock(_nextBlock);
            Renderer.DrawEnd();
        }

        public void Update()
        {
            if (!_linePause)
            {
                int tempMax = (int)_timerMax;
                if (ConsoleKeyboard.KeyAvailable)
                {
                    ConsoleKey key = ConsoleKeyboard.PressedKey;
                    switch (key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.Spacebar: RotateCheck(); break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow: CheckMoveHorizontal(-1); break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow: CheckMoveHorizontal(+1); break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow: tempMax = 4; break;
                        default: break;
                    }
                }
                _timer++;
                if (_timer >= (int)((tempMax-_level)/5))
                {
                    _timer = 0;
                    if (CheckMoveVertical(1)) _fails++;
                    else Program.game.Score += 10;
                    if (_fails == 3)
                    {
                        _fails = 0;
                        PlaceIntoMap(_currentBlock, _currentPos);
                        GetNextCurrent();
                        GenerateNextBlock();
                    }
                }

                linesToRemove = new List<int>();

                for (int y = 0; y < 20; y++)
                {
                    bool mapLine = true;
                    for (int x = 0; x < 10; x++)
                    {
                        if (!_map[x, y].Exists) mapLine = false;
                    }
                    if (mapLine)
                    {
                        linesToRemove.Add(y);
                        _linePause = true;
                        for (int x = 0; x < 10; x++)
                        {
                            _map[x, y].Color = Block.ColorToColor(Block.RandomColor());
                            _map[x, y].Special = true;
                            _timer = 0;
                        }
                    }
                }
            }
            else
            {
                if (!played)
                {
                    NotePlayer.PlayTuneSec(new Tunes.LineTune());
                    played = true;
                }
                ConsoleColor c = Block.ColorToColor(Block.RandomColor());
                _timer++;
                foreach (int y in linesToRemove)
                {
                    for (int x = 0; x < 10; x++)
                        _map[x, y].Color = c;
                }
                if (_timer == 20)
                {
                    _linePause = false;
                    _level += (uint)linesToRemove.Count;
                    Program.game.Score += 1000 * (ulong)Math.Pow(2, linesToRemove.Count);
                    foreach (int y in linesToRemove)
                    {
                        for (int ry = y; ry >= 1; ry--)
                        {
                            for (int x = 0; x < 10; x++)
                            {
                                _map[x, ry] = new Cetris.Bit() { Color = _map[x, ry - 1].Color, Exists = _map[x, ry - 1].Exists, Special = _map[x, ry - 1].Special };
                            }
                        }
                    }
                    played = false;
                    linesToRemove.Clear();
                }
            }
        }

        bool played = false;

        public void Draw()
        {
            Renderer.Clean();
            DrawBasicGUI();
            DrawGUIStats();
            DrawNextBlock(_nextBlock);
            DrawMap();
            _currentBlock.RenderBlock(new Vector2(6 + _currentPos.X * 2, 2 + _currentPos.Y));
        }
        public void PlayMusic()
        {
            NotePlayer.PlayTune(new Tunes.MainTune());
        }
    }
}
