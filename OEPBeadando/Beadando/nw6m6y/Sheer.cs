namespace nw6m6y
{
    public class Sheer : LandType
    {
        public Sheer(Land l) : base(l) { }
        public override void Change(Weather w)
        {
            if (w == null)
            {
                throw new ArgumentException();
            }

            land.GetAtmosphere().AddHumidity(3);
            int wA = w.GetWater(this);
            land.AddWater(wA);
        }
    }
}