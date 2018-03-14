using System;
using System.Collections.Generic;
using ConsoleGameUtilities;

namespace Cetris.Tunes
{
    public class EndTune : Tune
    {
        public EndTune()
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
                    = "F- 44E 83B 84C 43A";
            notes = generateFromText(noteTr, 250);
        }
    }
}
