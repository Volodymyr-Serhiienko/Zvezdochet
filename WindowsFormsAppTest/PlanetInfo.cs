namespace Astro
{
    public class Zodiac
    {
        public string name;
        public double ratio;

        public Zodiac(double Coord)
        {
            var tuple = SlavAstronomy.ZodiacPos(Coord);
            name = tuple.Item1;
            ratio = tuple.Item2;
        }
    }
    public class Chertog : Zodiac
    {
        public string hall;
        public string rune;

        public Chertog(double Coord)
            :base(Coord)
        {
            var tuple = SlavAstronomy.ChertogPos(Coord);
            name = tuple.Item1;
            hall = tuple.Item2;
            ratio = tuple.Item3;
            rune = tuple.Item4;
        }
    }
    
    public class PlanetPosition
    {
        public Chertog chertog;
        public Zodiac zodiac;
        public double coord { get; }

        public PlanetPosition(double coord)
        {
            this.coord = coord;
            chertog = new Chertog(coord);
            zodiac = new Zodiac(coord);
        }
    }

    public class PlanetInfo
    {
        public PlanetPosition helio;
        public PlanetPosition geo;

        public PlanetInfo(double helioCoord)
        {
            helio = new PlanetPosition(helioCoord);
        }
        public PlanetInfo(double helioCoord, double geoCoord)
        {
            helio = new PlanetPosition(helioCoord);
            geo = new PlanetPosition(geoCoord);
        }
    }
}
