namespace nw6m6y
{
    public class Cloudy : Weather
    {
        private static Cloudy? _instance;

        public static Cloudy Instance { get { if (_instance == null) { _instance = new Cloudy(); } return _instance; } }
        public int GetWater(Sheer s)
        {
            return -1;
        }

        public int GetWater(Lake s)
        {
            return -3;
        }

        public int GetWater(Green s)
        {
            return -2;
        }
    }
}