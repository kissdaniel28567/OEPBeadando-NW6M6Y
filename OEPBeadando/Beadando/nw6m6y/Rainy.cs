namespace nw6m6y
{
    public class Rainy : Weather
    {

        private static Rainy? _instance;

        public static Rainy Instance { get { if (_instance == null) { _instance = new Rainy(); } return _instance; } }
        public int GetWater(Sheer s)
        {
            return 15;
        }

        public int GetWater(Lake s)
        {
            return 10;
        }

        public int GetWater(Green s)
        {
            return 5;
        }

    }
}