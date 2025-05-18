namespace nw6m6y
{
    public class Green : LandType
    {
        public Green(Land l) : base(l) { }
        public override void Change(Weather w)
        {
            if (w == null)
            {
                throw new ArgumentException();
            }

            land.GetAtmosphere().AddHumidity(7);
            int wA = w.GetWater(this);
            land.AddWater(wA);
        }
    }
}