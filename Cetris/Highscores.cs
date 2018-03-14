using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cetris
{
    [Serializable]
    public class Highscores
    {
        public List<string> names = new List<string>();
        public List<ulong> scores = new List<ulong>();
        
        private void SetDefault()
        {
            names = new List<string>() { "", "", "", "", "", "", "", "", "", "" };
            scores = new List<ulong>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
    
        public bool TryPut(ulong score)
        {
            int putInd = -1;
            for (int i = 9; i >= 0; i--)
            {
                if (scores[i] <= score)
                {
                    putInd = i;
                }
            }
            if (putInd < 0) return false;
            return true;
        }

        public int PutScore(ulong score, string name)
        {
            int putInd = -1;
            for (int i = 9; i >= 0; i--)
            {
                if (scores[i] <= score)
                {
                    putInd = i;
                }
            }
            if (putInd < 0) return -1;
            else
            {
                scores.RemoveAt(9);
                scores.Insert(putInd, score);
                names.RemoveAt(9);
                names.Insert(putInd, name);
                return putInd;
            }
        }

        public static void Save(Highscores scoresTable)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Highscores));
            StreamWriter writer = new StreamWriter("Highscores.xml");
            serializer.Serialize(writer, scoresTable);
            writer.Close();
        }

        public static Highscores Load()
        {
            if (File.Exists("Highscores.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Highscores));
                StreamReader reader = new StreamReader("Highscores.xml");
                Highscores table = (Highscores)serializer.Deserialize(reader);
                reader.Close();
                return table;
            }
            else
            {
                Highscores table = new Cetris.Highscores();
                table.SetDefault();
                return table;
            }
        }
    }
}
