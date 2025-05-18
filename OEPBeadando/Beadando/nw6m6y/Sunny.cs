namespace nw6m6y
{
    public class Sunny : Weather
    {
        private static Sunny? _instance;

        public static Sunny Instance { get { if (_instance == null) { _instance = new Sunny(); } return _instance; } }

        public int GetWater(Sheer s)
        {
            return -3;
        }

        public int GetWater(Lake s)
        {
            return -10;
        }

        public int GetWater(Green s)
        {
            return -6;
        }

    }
}