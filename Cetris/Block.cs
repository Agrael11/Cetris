using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris
{
    public abstract class Block
    {
        public enum Colors { CYAN, BLUE, ORANGE, YELLOW, GREEN, MAGENTA, RED}

        private static Dictionary<Colors, ConsoleColor> _colors = new Dictionary<Colors, ConsoleColor>
        {
            {Colors.CYAN, ConsoleColor.Cyan },
            {Colors.BLUE, ConsoleColor.Blue },
            {Colors.ORANGE, ConsoleColor.DarkYellow },
            {Colors.YELLOW, ConsoleColor.Yellow },
            {Colors.GREEN, ConsoleColor.Green },
            {Colors.MAGENTA, ConsoleColor.Magenta },
            {Colors.RED, ConsoleColor.Red }
        };

        public void Init(ConsoleColor color, byte rotation)
        {
            this.color = color;
            Rotation = rotation;
        }

        public ConsoleColor color;
        public enum BLOCKTYPE { I,J,L,O,Z,T,S};
        public static BLOCKTYPE RandomBlockType()
        {
            var v = Enum.GetValues(typeof(BLOCKTYPE));
            return (BLOCKTYPE)v.GetValue(Game.random.Next(v.Length));
        }
        public static Colors RandomColor()
        {
            var v = Enum.GetValues(typeof(Colors));
            return (Colors)v.GetValue(Game.random.Next(v.Length));
        }

        public static ConsoleColor ColorToColor(Colors color)
        {
            return _colors[color];
        }

        private static Dictionary<BLOCKTYPE, Type> _classes = new Dictionary<BLOCKTYPE, Type>
        {
            {BLOCKTYPE.I, typeof(Blocks.IBlock) },
            {BLOCKTYPE.J, typeof(Blocks.JBlock) },
            {BLOCKTYPE.L, typeof(Blocks.LBlock) },
            {BLOCKTYPE.O, typeof(Blocks.OBlock) },
            {BLOCKTYPE.Z, typeof(Blocks.ZBlock) },
            {BLOCKTYPE.T, typeof(Blocks.TBlock) },
            {BLOCKTYPE.S, typeof(Blocks.SBlock) },
        };

        public static Block GetBlock(BLOCKTYPE type, Colors color, byte rotation)
        {
            Type t = _classes[type];
            Block b = (Block)Activator.CreateInstance(t);
            b.Init(_colors[color], rotation);
            return b;
        }

        private byte _rotation;
        public byte Rotation
        {
            get { return _rotation; }
            set { _rotation = (byte)(value % 4); }
        }

        public void Rotate()
        {
            Rotation++;
        }


        public void RenderBlock(Vector2 position)
        {
            bool[,] map = GetMap();
            Vector2 size = GetSize();
            for (int mx = 0; mx < size.X; mx++)
            {
                for (int my = 0; my < size.Y; my++)
                {
                    if (map[mx, my])
                    {
                        Renderer.DrawPoint(new Vector2(position.X + (mx * 2), position.Y + my), color);
                        Renderer.DrawPoint(new Vector2(position.X + (mx * 2) + 1, position.Y + my), color);
                        Renderer.DrawString("[]", new Vector2(position.X + (mx * 2), position.Y + my), ConsoleColor.Black);
                    }
                }
            }
        }

        public abstract Vector2 GetSize();
        public abstract bool[,] GetMap();
    }
}
