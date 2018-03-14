using System;
using ConsoleGameUtilities;

namespace Cetris.Blocks
{
    class JBlock : Block
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
                    return new bool[2, 3] { { false, false, true }, { true, true, true } };
                case 2:
                    return new bool[2, 3] { { true, true, true }, { true, false, false } };
                case 1:
                    return new bool[3, 2] { { true, false }, { true, false }, { true, true } };
                case 3:
                    return new bool[3, 2] { { true, true }, { false, true }, { false, true } };
                default: return null;
            }
        }
    }
}
