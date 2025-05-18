using System;

namespace nw6m6y
{
    public class Atmosphere
    {
        private int humidity;
        private List<Land> lands;
        private Weather weather;

        public Atmosphere(int h, List<(String, int)> l)
        {
            humidity = h;
            lands = new List<Land>();
            foreach ((String, int) land in l)
            {
                lands.Add(new Land(land.Item1, land.Item2, this));
            }
            ChangeWeather();
        }

        public void TurnDays(int dayCount)
        {
            for (int i = 0; i < dayCount; i++)
            {
                foreach (Land l in lands)
                {
                    l.NextDay();
                }
            }
        }

        public void ChangeWeather()
        {
            if (humidity > 70)
            {
                humidity = 30;
                weather = Rainy.Instance;
            }

            else if (humidity < 40)
            {
                weather = Sunny.Instance;
            }
            else
            {
                Random random = new Random();
                int rand = random.Next(1, 101);

                if (rand > (humidity - 40) * 3.3)
                {
                    weather = Cloudy.Instance;
                }

                else
                {
                    weather = Rainy.Instance;
                }
            }
        }
        public int GetHumidity()
        {
            return humidity;
        }

        //This is only important for testing
        public List<Land> GetLands()
        {
            return lands;
        }

        public (bool, Land?, int) MostWater()
        {
            if (lands.Count() == 0)
            {
                return (false, null, 0);
            }
            int maxWater = lands.Select(land => land.GetWater()).Max();
            return (true, lands.Where(land => land.GetWater() == maxWater).FirstOrDefault(), maxWater);
        }

        public Weather GetWeather()
        {
            if (weather == null)
            {
                throw new ArgumentException();
            }
            return weather;
        }

        public void AddHumidity(int amount)
        {
            humidity += amount;
        }
    }
}