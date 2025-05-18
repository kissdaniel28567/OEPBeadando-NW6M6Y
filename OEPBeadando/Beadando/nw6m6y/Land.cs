using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace nw6m6y
{
    public class Land
    {
        private String name;
        private int waterAmount;
        private Atmosphere atmosphere;
        public LandType type { get; private set; }


        public Land(String n, int w, Atmosphere a)
        {
            name = n;
            waterAmount = w;
            atmosphere = a;
            ChangeType();
        }

        public String GetName()
        {
            return name;
        }

        public int GetWater()
        {
            return waterAmount;
        }

        public void AddWater(int w)
        {
            waterAmount += w;
        }

        public Atmosphere GetAtmosphere()
        {
            return atmosphere;
        }

        public void ChangeType()
        {
            if (waterAmount > 50)
            {
                type = new Lake(this);
            }
            else if (waterAmount > 15)
            {
                type = new Green(this);
            }
            else
            {
                type = new Sheer(this);
            }
        }

        public void NextDay()
        {
            type.Change(atmosphere.GetWeather());
            ChangeType();
            atmosphere.ChangeWeather();
        }
    }
}