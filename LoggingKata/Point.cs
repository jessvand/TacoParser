namespace LoggingKata
{
    public struct Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public Point(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
