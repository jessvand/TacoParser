using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacoBellUno = null;
            ITrackable tacoBellDos = null;

           
            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var cordA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for(int x= 0; x < locations.Length; x++)
                {
                    var locB = locations[x];
                    var cordB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    var distanceBx = cordA.GetDistanceTo(cordB);

                    if(distanceBx > distance)
                    {
                        distance = distanceBx;
                        tacoBellUno = locA;
                        tacoBellDos = locB;

                    }
                }
            }

            //logger.LogInfo($"{tacoBellDos.Name} and {tacoBellUno.Name}are the furthest away from each other.\\n The greatest distance in meters is {distance}, so approximately {Math.Round(distance * 0.0062)} in miles");

            Console.WriteLine($"{tacoBellUno.Name} and {tacoBellDos.Name} are the furthest away from each other.\n The greatest distance in meters is {distance}, so approximately {Math.Round(distance*0.0062)}in miles");

       


        }
    }
}
