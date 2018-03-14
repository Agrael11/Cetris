using System;
using ConsoleGameUtilities;

namespace Cetris.Blocks
{
    class ZBlock : Block
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
                    return new bool[2, 3] { { false, true, true }, { true, true, false } };
                case 1:
                case 3:
                    return new bool[3, 2] { { true, false }, { true, true }, { false, true } };
                default: return null;
            }
        }
    }
}
