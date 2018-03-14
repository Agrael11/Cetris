using System;
using ConsoleGameUtilities;

namespace Cetris.Blocks
{
    class IBlock : Block
    {
        public override Vector2 GetSize()
        {
            switch (Rotation)
            {
                case 0:
                case 2:
                    return new Vector2(1, 4);
                case 1:
                case 3:
                    return new Vector2(4, 1);
                default: return null;
            }
        }
        public override bool[,] GetMap()
        {
            switch (Rotation)
            {
                case 0:
                case 2:
                    return new bool[1, 4] { { true, true, true, true} };
                case 1:
                case 3:
                    return new bool[4, 1] { { true}, { true }, { true }, { true } };
                default: return null;
            }
        }
    }
}
