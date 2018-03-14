using System;
using ConsoleGameUtilities;

namespace Cetris.Blocks
{
    class SBlock : Block
    {
        public override Vector2 GetSize()
        {
            switch (Rotation)
            {
                case 0:
                case 2:
                    return new Vector2(2, 3);
                case 1:
                case 3:
                    return new Vector2(3, 2);
                default: return null;
            }
        }
        public override bool[,] GetMap()
        {
            switch (Rotation)
            {
                case 0:
                case 2:
                    return new bool[2, 3] { { true, true, false }, { false, true, true } };
                case 1:
                case 3:
                    return new bool[3, 2] { { false, true }, { true, true }, { true, false } };
                default: return null;
            }
        }
    }
}
