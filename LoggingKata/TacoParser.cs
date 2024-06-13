namespace LoggingKata
{
  
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo($"the parsing has BEGUN! : {line}");

            
            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                
                logger.LogError("Should only be three lines");
                return null; 
            }

           
            var latitude = double.Parse(cells[0]);
           
            var longitude = double.Parse(cells[1]);

            // TODO: Grab the name from your array at index 2
            var store = cells[2];

            
            var location = new Point(latitude, longitude);
            var tacoBell = new TacoBell(store, location);

            return tacoBell;
        }
    }
}
