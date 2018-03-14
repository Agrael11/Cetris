using System;
using ConsoleGameUtilities;

namespace Cetris.Blocks
{
    class OBlock : Block
    {
        public override Vector2 GetSize()
        {
            switch (Rotation)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return new Vector2(2, 2);
                default: return null;
            }
        }
        public override bool[,] GetMap()
        {
            switch (Rotation)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return new bool[2, 2] { { true, true }, { true, true }};
                default: return null;
            }
        }
    }
}
