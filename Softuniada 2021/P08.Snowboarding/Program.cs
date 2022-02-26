using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.Snowboarding
{
    public class Track
    {
        public Track(string name, int endurance, int obstacles)
        {
            Name = name;
            Endurance = endurance;
            Obstacles = obstacles;
        }

        public string Name { get; set; }

        public int Endurance { get; set; }

        public int Obstacles { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var tracks = new List<Track>();

            var personEndurance = int.Parse(Console.ReadLine());

            var tracksNames = Console.ReadLine()
                .Split();

            var tracksEndurance = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var tracksObstacles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < tracksNames.Length; i++)
            {
                var trackName = tracksNames[i];
                var trackEndurance = tracksEndurance[i];
                var trackObstacle = tracksObstacles[i];

                var track = new Track(trackName, trackEndurance, trackObstacle);

                tracks.Add(track);
            }

            tracks = tracks.OrderBy(x => x.Obstacles).ToList();


            var passedTracks = new List<string>();

            var totalPassedObstacles = 0;
            while (true)
            {
                var currTrack = tracks.Where(x => x.Endurance <= personEndurance)
                    .ToList()
                    .OrderByDescending(x => x.Obstacles)
                    .ThenBy(x => x.Endurance)
                    .FirstOrDefault();

                if (currTrack == null || personEndurance < currTrack.Endurance)
                {
                    break;
                }

                passedTracks.Add(currTrack.Name);
                totalPassedObstacles += currTrack.Obstacles;
                personEndurance -= currTrack.Endurance;
                tracks.Remove(currTrack);
            }

            Console.WriteLine(string.Join(" ", passedTracks.OrderBy(x => x)));
            Console.WriteLine(totalPassedObstacles);
            Console.WriteLine(personEndurance);
        }
    }
}
