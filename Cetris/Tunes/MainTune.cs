using System;
using System.Collections.Generic;
using ConsoleGameUtilities;

namespace Cetris.Tunes
{
    public class MainTune : Tune
    {
        public MainTune()
        {
            #region old
            //    notes = new List<Note>
            //    {
            //        new Note("G",500,4),
            //        new Note("D",250,4),
            //        new Note("E",250,4),

            //        new Note("F",500,4),
            //        new Note("D#",250,4),
            //        new Note("D",250,4),

            //        new Note("C",500,4),
            //        new Note("C",250,4),
            //        new Note("E",250,4),

            //        new Note("G",500,4),
            //        new Note("F",250,4),
            //        new Note("E",250,4),

            //        new Note("D",500,4),
            //        new Note("D",250,4),
            //        new Note("E",250,4),

            //        new Note("F",500,4),
            //        new Note("G",500,4),

            //        new Note("E",500,4),
            //        new Note("C",500,4),

            //        new Note("C",500,4),
            //        new Note(500),

            //        new Note(100),
            //        new Note("F",400,4),
            //        new Note("F",250,4),
            //        new Note("A",250,4),

            //        new Note("C",500,5),
            //        new Note("B",250,4),
            //        new Note("A",250,4),

            //        new Note("G",500,4),
            //        new Note("G",250,4),
            //        new Note("E",250,4),

            //        new Note("G",500,4),
            //        new Note("F",250,4),
            //        new Note("E",250,4),

            //        new Note("D",500,4),
            //        new Note("D",250,4),
            //        new Note("E",250,4),

            //        new Note("F",500,4),
            //        new Note("G",500,4),

            //        new Note("E",500,4),
            //        new Note("C",500,4),

            //        new Note("C",500,4),
            //        new Note(500),
            //};
            #endregion
            string noteTr
                    = "44E 83B 84C 44D 84C 83B 43A 83A 84C 44E 84D 84C 43B 83B 84C 44D 44E 44C 43A 43A 4-";
            noteTr += "8- 84D 84D 84F 44A 84G 84F 44E 84E 84C 44E 84D 84C 43B 83B 84C 44D 44E 44C 43A 43A 4-";
            noteTr += "44E 4- 44C 44C 44D 4- 43B 43B 44C 4- 43A 43A 23G# 2-";
            noteTr += "44E 4- 44C 44C 44D 4- 43B 43B 84C 83A 84C 84E 44A 44A 24G 2-";
            notes = generateFromText(noteTr, 125);
            Loop = true;
        }
    }
}
