using System;
using System.Collections.Generic;
using ConsoleGameUtilities;

namespace Cetris.Tunes
{
    public class MiniTune : Tune
    {
        public MiniTune()
        {
            string noteTr
                    = "44E 83B 84C 44D 84C 83B 43A 83A 84C 44E 84D 84C 43B 83B 84C 44D 44E 44C 43A 43A 4-";
            notes = generateFromText(noteTr, 125);
        }
    }
}
