namespace nw6m6y
{
    public class Lake : LandType
    {
        public Lake(Land l) : base(l) { }
        public override void Change(Weather w)
        {
            if (w == null)
            {
                throw new ArgumentException();
            }

            land.GetAtmosphere().AddHumidity(10);
            int wA = w.GetWater(this);
            land.AddWater(wA);
        }
    }
}