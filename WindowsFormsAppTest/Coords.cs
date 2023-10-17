namespace Astro
{
    public class Position
    {
        public double helio { get; set; }
        public double geo { get; set; }
    }

    public class Coords
    {
        private AstroTime Astrotime { get; set; }
        private double coord_correction { get; set; }
        public Coords(AstroTime astrotime, double coord_correction)
        {
            Astrotime = astrotime;
            this.coord_correction = coord_correction;
            mercury.helio = Normalize(Astronomy.EclipticLongitude(Body.Mercury, Astrotime) + coord_correction);
            mercury.geo = Normalize(Astronomy.EquatorialToEcliptic(Astronomy.GeoVector(Body.Mercury, Astrotime, Aberration.None)).elon + coord_correction);
            venus.helio = Normalize(Astronomy.EclipticLongitude(Body.Venus, Astrotime) + coord_correction);
            venus.geo = Normalize(Astronomy.EquatorialToEcliptic(Astronomy.GeoVector(Body.Venus, Astrotime, Aberration.None)).elon + coord_correction);
            mars.helio = Normalize(Astronomy.EclipticLongitude(Body.Mars, Astrotime) + coord_correction);
            mars.geo = Normalize(Astronomy.EquatorialToEcliptic(Astronomy.GeoVector(Body.Mars, Astrotime, Aberration.None)).elon + coord_correction);
            jupiter.helio = Normalize(Astronomy.EclipticLongitude(Body.Jupiter, Astrotime) + coord_correction);
            jupiter.geo = Normalize(Astronomy.EquatorialToEcliptic(Astronomy.GeoVector(Body.Jupiter, Astrotime, Aberration.None)).elon + coord_correction);
            saturn.helio = Normalize(Astronomy.EclipticLongitude(Body.Saturn, Astrotime) + coord_correction);
            saturn.geo = Normalize(Astronomy.EquatorialToEcliptic(Astronomy.GeoVector(Body.Saturn, Astrotime, Aberration.None)).elon + coord_correction);
            uranus.helio = Normalize(Astronomy.EclipticLongitude(Body.Uranus, Astrotime) + coord_correction);
            uranus.geo = Normalize(Astronomy.EquatorialToEcliptic(Astronomy.GeoVector(Body.Uranus, Astrotime, Aberration.None)).elon + coord_correction);
            neptune.helio = Normalize(Astronomy.EclipticLongitude(Body.Neptune, Astrotime) + coord_correction);
            neptune.geo = Normalize(Astronomy.EquatorialToEcliptic(Astronomy.GeoVector(Body.Neptune, Astrotime, Aberration.None)).elon + coord_correction);
            pluto.helio = Normalize(Astronomy.EclipticLongitude(Body.Pluto, Astrotime) + coord_correction);
            pluto.geo = Normalize(Astronomy.EquatorialToEcliptic(Astronomy.GeoVector(Body.Pluto, Astrotime, Aberration.None)).elon + coord_correction);
        }
        
        public double sun
        {
            get
            {
                //double result = Normalize(Astronomy.SunPosition(Astrotime).elon);
                double result = Normalize(Astronomy.SunPosition(Astrotime).elon + coord_correction);
                return result;
            }
        }
        public double earth
        {
            get
            {
                double result = sun + 180;
                if (result > 360) result -= 360;
                return result;
            }
        }
        public double moon
        {
            get
            {
                double result = Normalize((Astronomy.EquatorialToEcliptic(Astronomy.GeoVector(Body.Moon, Astrotime, Aberration.Corrected))).elon + coord_correction);
                return result;
            }
        }
        
        public Position mercury = new Position();
        public Position venus = new Position();
        public Position mars = new Position();
        public Position jupiter = new Position();
        public Position saturn = new Position();
        public Position uranus = new Position();
        public Position neptune = new Position();
        public Position pluto = new Position();
    
        private static double Normalize(double coord)
        {
            if (coord < 0) { coord += 360; }
            if (coord > 360) { coord -= 360; }
            return coord;
        }
    }
}
