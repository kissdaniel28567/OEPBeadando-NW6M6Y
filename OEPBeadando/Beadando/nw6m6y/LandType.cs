namespace nw6m6y
{
    public abstract class LandType
    {
        protected Land land;

        public LandType(Land land)
        {
            this.land = land;
        }

        public abstract void Change(Weather w);
    }
}