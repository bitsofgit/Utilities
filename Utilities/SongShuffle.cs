using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class SongShuffle
    {
        public static void Menu()
        {
            List<int> songs = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                songs.Add(i+1);
            }

            for(int i=0;i<20;i++)
            {
                Shuffle(songs);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private static List<int> alreadyPlayed = new List<int>();
        public static void Shuffle(List<int> songs)
        {
            if (songs == null)
                throw new ArgumentNullException("songs");

            List<int> workingSet = songs.Except(alreadyPlayed).ToList();
            if (workingSet.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (workingSet.Count == 1)
            {
                Console.WriteLine(1);
                alreadyPlayed.Clear();
                return;
            }

            int selected = new Random().Next(1, workingSet.Count - 1);
            alreadyPlayed.Add(selected);

            Console.WriteLine(selected);
        }
    }
}
