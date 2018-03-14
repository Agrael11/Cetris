using System;
using ConsoleGameUtilities;

namespace Cetris.Blocks
{
    class LBlock : Block
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
                    return new bool[2, 3] { { true, true, true }, { false, false, true } };
                case 2:
                    return new bool[2, 3] { { true, false, false }, { true, true, true } };
                case 1:
                    return new bool[3, 2] { { false, true }, { false, true }, { true, true } };
                case 3:
                    return new bool[3, 2] { { true, true }, { true, false }, { true, false } };
                default: return null;
            }
        }
    }
}
