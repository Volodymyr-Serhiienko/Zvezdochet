using System;
using System.Collections.Generic;
using System.Linq;

namespace Astro
{
    public class AstroObject
    {
        public DateTime Datetime { get; }
        public Coords coords;
        public DateInfo dateInfo;
        private double coord_correction 
        { 
            get
            {
                double result;
                DateTime millenium = new DateTime(2011, 9, 21);
                TimeSpan timeSpan; 
                double day_correction = 22.5 / (1620 * 365.25);
                if(Datetime < millenium)
                {
                    timeSpan = millenium - Datetime;
                    result = timeSpan.Days * day_correction;
                }
                else
                {
                    timeSpan = Datetime - millenium;
                    result = -(timeSpan.Days * day_correction);
                }
                return result;
            } 
        }

        public PlanetInfo sun;
        public PlanetInfo moon;
        public PlanetInfo earth;
        public PlanetInfo mercury;
        public PlanetInfo venus;
        public PlanetInfo mars;
        public PlanetInfo jupiter;
        public PlanetInfo saturn;
        public PlanetInfo uranus;
        public PlanetInfo neptune;
        public PlanetInfo pluto;

        public AstroObject(DateTime datetime)
        {
            Datetime = datetime;
            coords = new Coords(new AstroTime(Datetime), coord_correction);
            dateInfo = new DateInfo(Datetime);
            sun = new PlanetInfo(coords.sun);
            moon = new PlanetInfo(coords.moon);
            earth = new PlanetInfo(coords.earth);
            mercury = new PlanetInfo(coords.mercury.helio, coords.mercury.geo);
            venus = new PlanetInfo(coords.venus.helio, coords.venus.geo);
            mars = new PlanetInfo(coords.mars.helio, coords.mars.geo);
            jupiter = new PlanetInfo(coords.jupiter.helio, coords.jupiter.geo);
            saturn = new PlanetInfo(coords.saturn.helio, coords.saturn.geo);
            uranus = new PlanetInfo(coords.uranus.helio, coords.uranus.geo);
            neptune = new PlanetInfo(coords.neptune.helio, coords.neptune.geo);
            pluto = new PlanetInfo(coords.pluto.helio, coords.pluto.geo);
        }
        
        public string ShowInfo1(PlanetInfo planet_Info)
        {
            return "Экл. долг.: " + Math.Round(planet_Info.helio.coord, 2) + "\u00B0" + "\n" 
                   + "Чертог " + planet_Info.helio.chertog.name + ", " + planet_Info.helio.chertog.hall 
                        + $"({planet_Info.helio.chertog.ratio}%)," + planet_Info.helio.chertog.rune + "\n" 
                   + planet_Info.helio.zodiac.name + $"({planet_Info.helio.zodiac.ratio}%)";
        }
        public string ShowInfo2(PlanetInfo planet_Info)
        {
            return "Гелио: " + Math.Round(planet_Info.helio.coord, 2) + "\u00B0" + "\n"
                   + "Чертог " + planet_Info.helio.chertog.name + ", " + planet_Info.helio.chertog.hall
                        + $"({planet_Info.helio.chertog.ratio}%)," + planet_Info.helio.chertog.rune + "\n"
                   + planet_Info.helio.zodiac.name + $"({planet_Info.helio.zodiac.ratio}%)" + "\n" +
                   "Гео: " + Math.Round(planet_Info.geo.coord, 2) + "\u00B0" + "\n"
                   + "Чертог " + planet_Info.geo.chertog.name + ", " + planet_Info.geo.chertog.hall
                        + $"({planet_Info.geo.chertog.ratio}%)," + planet_Info.geo.chertog.rune + "\n"
                   + planet_Info.geo.zodiac.name + $"({planet_Info.geo.zodiac.ratio}%)";
        }
        public string ShowScopes(AstroObject astroObject)
        {
            List<string> scopes = new List<string> { "Душевная", "Духовная", "Земная", "Божественная" };
            List<string> active_scopes1 = new List<string>();
            List<string> chertogs = new List<string>();
            chertogs.Add(astroObject.sun.helio.chertog.name);
            chertogs.Add(astroObject.sun.helio.chertog.name);
            chertogs.Add(astroObject.earth.helio.chertog.name);
            chertogs.Add(astroObject.earth.helio.chertog.name);
            chertogs.Add(astroObject.moon.helio.chertog.name);
            chertogs.Add(astroObject.moon.helio.chertog.name);
            chertogs.Add(astroObject.mercury.helio.chertog.name);
            chertogs.Add(astroObject.mercury.geo.chertog.name);
            chertogs.Add(astroObject.venus.helio.chertog.name);
            chertogs.Add(astroObject.venus.geo.chertog.name);
            chertogs.Add(astroObject.mars.helio.chertog.name);
            chertogs.Add(astroObject.mars.geo.chertog.name);
            chertogs.Add(astroObject.jupiter.helio.chertog.name);
            chertogs.Add(astroObject.jupiter.geo.chertog.name);
            chertogs.Add(astroObject.saturn.helio.chertog.name);
            chertogs.Add(astroObject.saturn.geo.chertog.name);
            chertogs.Add(astroObject.uranus.helio.chertog.name);
            chertogs.Add(astroObject.uranus.geo.chertog.name);
            chertogs.Add(astroObject.neptune.helio.chertog.name);
            chertogs.Add(astroObject.neptune.geo.chertog.name);
            chertogs.Add(astroObject.pluto.helio.chertog.name);
            chertogs.Add(astroObject.pluto.geo.chertog.name);
            List<string> active_chertogs = chertogs.Distinct().ToList();

            List<int> number = new List<int>();
            int count1 = 0; int count2 = 0; int count3 = 0; int count4 = 0;
            foreach (var str in active_chertogs)
            {
                if (str == "Девы" || str == "Змия" || str == "Волка" || str == "Финиста") active_scopes1.Add("Душевная");
                if (str == "Вепря" || str == "Ворона" || str == "Лисы" || str == "Коня") active_scopes1.Add("Духовная");
                if (str == "Щуки" || str == "Медведя" || str == "Тура" || str == "Орла") active_scopes1.Add("Земная");
                if (str == "Лебедя" || str == "Бусла" || str == "Лося" || str == "Раса") active_scopes1.Add("Божественная");
            }
            List<string> active_scopes = active_scopes1.Distinct().ToList();
            Dictionary<string, int> Scopes = new Dictionary<string, int>();
            foreach (var str in chertogs)
            {
                if (str == "Девы" || str == "Змия" || str == "Волка" || str == "Финиста") count1++;
                if (str == "Вепря" || str == "Ворона" || str == "Лисы" || str == "Коня") count2++;
                if (str == "Щуки" || str == "Медведя" || str == "Тура" || str == "Орла") count3++;
                if (str == "Лебедя" || str == "Бусла" || str == "Лося" || str == "Раса") count4++;
            }
            number.Add(count1); number.Add(count2); number.Add(count3); number.Add(count4);
            for (int i = 0; i < active_scopes.Count; i++)
            {
                for (int j = 0; j < scopes.Count; j++)
                {
                    if (active_scopes[i] == scopes[j]) { Scopes.Add(active_scopes[i], number[j]); }
                }
            }
            string result = null;
            foreach (var item in Scopes)
            {
                result += item.Key + " - " + item.Value + "\n";
            }
            return result;
        }
        public string ShowHalls(AstroObject astroObject)
        {
            List<string> halls = new List<string>();
            List<string> planets = new List<string> { "Ярило", "Мидгард", "Месяц", "Хорс", "Мерцана", "Орей", "Перун", "Стрибог", "Варуна", "Ний", "Вий" };
            halls.Add(astroObject.sun.helio.chertog.hall);
            halls.Add(astroObject.sun.helio.chertog.hall);
            halls.Add(astroObject.earth.helio.chertog.hall);
            halls.Add(astroObject.earth.helio.chertog.hall);
            halls.Add(astroObject.moon.helio.chertog.hall);
            halls.Add(astroObject.moon.helio.chertog.hall);
            halls.Add(astroObject.mercury.helio.chertog.hall);
            halls.Add(astroObject.mercury.geo.chertog.hall);
            halls.Add(astroObject.venus.helio.chertog.hall);
            halls.Add(astroObject.venus.geo.chertog.hall);
            halls.Add(astroObject.mars.helio.chertog.hall);
            halls.Add(astroObject.mars.geo.chertog.hall);
            halls.Add(astroObject.jupiter.helio.chertog.hall);
            halls.Add(astroObject.jupiter.geo.chertog.hall);
            halls.Add(astroObject.saturn.helio.chertog.hall);
            halls.Add(astroObject.saturn.geo.chertog.hall);
            halls.Add(astroObject.uranus.helio.chertog.hall);
            halls.Add(astroObject.uranus.geo.chertog.hall);
            halls.Add(astroObject.neptune.helio.chertog.hall);
            halls.Add(astroObject.neptune.geo.chertog.hall);
            halls.Add(astroObject.pluto.helio.chertog.hall);
            halls.Add(astroObject.pluto.geo.chertog.hall);
            List<string> active_halls = halls.Distinct().ToList();

            List<int> number = new List<int>();
            foreach (var str in active_halls)
            {
                int count = 0;
                foreach (var str2 in halls)
                {
                    if (str == str2) count++;
                }
                number.Add(count);
            }
            string result = null;
            string planet;
            for (int i = 0; i < active_halls.Count; i++)
            {
                planet = null;
                if (active_halls[i] == astroObject.sun.helio.chertog.hall) planet += planets[0] + ", ";
                if (active_halls[i] == astroObject.earth.helio.chertog.hall) planet += planets[1] + ", ";
                if (active_halls[i] == astroObject.moon.helio.chertog.hall) planet += planets[2] + ", ";
                if (active_halls[i] == astroObject.mercury.helio.chertog.hall) planet += planets[3] + ", ";
                if (active_halls[i] == astroObject.mercury.geo.chertog.hall && active_halls[i] != astroObject.mercury.helio.chertog.hall) planet += planets[3] + ", ";
                if (active_halls[i] == astroObject.venus.helio.chertog.hall) planet += planets[4] + ", ";
                if (active_halls[i] == astroObject.venus.geo.chertog.hall && active_halls[i] != astroObject.venus.helio.chertog.hall) planet += planets[4] + ", ";
                if (active_halls[i] == astroObject.mars.helio.chertog.hall) planet += planets[5] + ", ";
                if (active_halls[i] == astroObject.mars.geo.chertog.hall && active_halls[i] != astroObject.mars.helio.chertog.hall) planet += planets[5] + ", ";
                if (active_halls[i] == astroObject.jupiter.helio.chertog.hall) planet += planets[6] + ", ";
                if (active_halls[i] == astroObject.jupiter.geo.chertog.hall && active_halls[i] != astroObject.jupiter.helio.chertog.hall) planet += planets[6] + ", ";
                if (active_halls[i] == astroObject.saturn.helio.chertog.hall) planet += planets[7] + ", ";
                if (active_halls[i] == astroObject.saturn.geo.chertog.hall && active_halls[i] != astroObject.saturn.helio.chertog.hall) planet += planets[7] + ", ";
                if (active_halls[i] == astroObject.uranus.helio.chertog.hall) planet += planets[8] + ", ";
                if (active_halls[i] == astroObject.uranus.geo.chertog.hall && active_halls[i] != astroObject.uranus.helio.chertog.hall) planet += planets[8] + ", ";
                if (active_halls[i] == astroObject.neptune.helio.chertog.hall) planet += planets[9] + ", ";
                if (active_halls[i] == astroObject.neptune.geo.chertog.hall && active_halls[i] != astroObject.neptune.helio.chertog.hall) planet += planets[9] + ", ";
                if (active_halls[i] == astroObject.pluto.helio.chertog.hall) planet += planets[10] + ", ";
                if (active_halls[i] == astroObject.pluto.geo.chertog.hall && active_halls[i] != astroObject.pluto.helio.chertog.hall) planet += planets[10] + ", ";
                string planet1 = planet.Substring(0, planet.Length - 2);
                result += active_halls[i] + " - " + number[i] + " (" + planet1 + ")\n";
            }
            return result;
        }
        public string ShowChertogs(AstroObject astroObject)
        {
            List<string> chertogs = new List<string>();
            List<string> planets = new List<string> { "Ярило", "Мидгард", "Месяц", "Хорс", "Мерцана", "Орей", "Перун", "Стрибог", "Варуна", "Ний", "Вий" };
            chertogs.Add(astroObject.sun.helio.chertog.name);
            chertogs.Add(astroObject.sun.helio.chertog.name);
            chertogs.Add(astroObject.earth.helio.chertog.name);
            chertogs.Add(astroObject.earth.helio.chertog.name);
            chertogs.Add(astroObject.moon.helio.chertog.name);
            chertogs.Add(astroObject.moon.helio.chertog.name);
            chertogs.Add(astroObject.mercury.helio.chertog.name);
            chertogs.Add(astroObject.mercury.geo.chertog.name);
            chertogs.Add(astroObject.venus.helio.chertog.name);
            chertogs.Add(astroObject.venus.geo.chertog.name);
            chertogs.Add(astroObject.mars.helio.chertog.name);
            chertogs.Add(astroObject.mars.geo.chertog.name);
            chertogs.Add(astroObject.jupiter.helio.chertog.name);
            chertogs.Add(astroObject.jupiter.geo.chertog.name);
            chertogs.Add(astroObject.saturn.helio.chertog.name);
            chertogs.Add(astroObject.saturn.geo.chertog.name);
            chertogs.Add(astroObject.uranus.helio.chertog.name);
            chertogs.Add(astroObject.uranus.geo.chertog.name);
            chertogs.Add(astroObject.neptune.helio.chertog.name);
            chertogs.Add(astroObject.neptune.geo.chertog.name);
            chertogs.Add(astroObject.pluto.helio.chertog.name);
            chertogs.Add(astroObject.pluto.geo.chertog.name);
            List<string> active_chertogs = chertogs.Distinct().ToList();

            List<int> number = new List<int>();
            foreach (var str in active_chertogs)
            {
                int count = 0;
                foreach (var str2 in chertogs)
                {
                    if (str == str2) count++;
                }
                number.Add(count);
            }
            string result = null;
            string planet;
            for (int i = 0; i < active_chertogs.Count; i++)
            {
                planet = null;
                if (active_chertogs[i] == astroObject.sun.helio.chertog.name) planet += planets[0] + ", ";
                if (active_chertogs[i] == astroObject.earth.helio.chertog.name) planet += planets[1] + ", ";
                if (active_chertogs[i] == astroObject.moon.helio.chertog.name) planet += planets[2] + ", ";
                if (active_chertogs[i] == astroObject.mercury.helio.chertog.name) planet += planets[3] + ", ";
                if (active_chertogs[i] == astroObject.mercury.geo.chertog.name && active_chertogs[i] != astroObject.mercury.helio.chertog.name) planet += planets[3] + ", ";
                if (active_chertogs[i] == astroObject.venus.helio.chertog.name) planet += planets[4] + ", ";
                if (active_chertogs[i] == astroObject.venus.geo.chertog.name && active_chertogs[i] != astroObject.venus.helio.chertog.name) planet += planets[4] + ", ";
                if (active_chertogs[i] == astroObject.mars.helio.chertog.name) planet += planets[5] + ", ";
                if (active_chertogs[i] == astroObject.mars.geo.chertog.name && active_chertogs[i] != astroObject.mars.helio.chertog.name) planet += planets[5] + ", ";
                if (active_chertogs[i] == astroObject.jupiter.helio.chertog.name) planet += planets[6] + ", ";
                if (active_chertogs[i] == astroObject.jupiter.geo.chertog.name && active_chertogs[i] != astroObject.jupiter.helio.chertog.name) planet += planets[6] + ", ";
                if (active_chertogs[i] == astroObject.saturn.helio.chertog.name) planet += planets[7] + ", ";
                if (active_chertogs[i] == astroObject.saturn.geo.chertog.name && active_chertogs[i] != astroObject.saturn.helio.chertog.name) planet += planets[7] + ", ";
                if (active_chertogs[i] == astroObject.uranus.helio.chertog.name) planet += planets[8] + ", ";
                if (active_chertogs[i] == astroObject.uranus.geo.chertog.name && active_chertogs[i] != astroObject.uranus.helio.chertog.name) planet += planets[8] + ", ";
                if (active_chertogs[i] == astroObject.neptune.helio.chertog.name) planet += planets[9] + ", ";
                if (active_chertogs[i] == astroObject.neptune.geo.chertog.name && active_chertogs[i] != astroObject.neptune.helio.chertog.name) planet += planets[9] + ", ";
                if (active_chertogs[i] == astroObject.pluto.helio.chertog.name) planet += planets[10] + ", ";
                if (active_chertogs[i] == astroObject.pluto.geo.chertog.name && active_chertogs[i] != astroObject.pluto.helio.chertog.name) planet += planets[10] + ", ";
                string planet1 = planet.Substring(0, planet.Length - 2);
                result += active_chertogs[i] + " - " + number[i] + " (" + planet1 + ")\n";
            }
            return result;
        }
        public string ShowZodiacs(AstroObject astroObject)
        {
            List<string> zodiacs = new List<string>();
            List<string> planets = new List<string> { "Солнце", "Земля", "Луна", "Меркурий", "Венера", "Марс", "Юпитер", "Сатурн", "Уран", "Нептун", "Плутон" };
            zodiacs.Add(astroObject.sun.helio.zodiac.name);
            zodiacs.Add(astroObject.sun.helio.zodiac.name);
            zodiacs.Add(astroObject.earth.helio.zodiac.name);
            zodiacs.Add(astroObject.earth.helio.zodiac.name);
            zodiacs.Add(astroObject.moon.helio.zodiac.name);
            zodiacs.Add(astroObject.moon.helio.zodiac.name);
            zodiacs.Add(astroObject.mercury.helio.zodiac.name);
            zodiacs.Add(astroObject.mercury.geo.zodiac.name);
            zodiacs.Add(astroObject.venus.helio.zodiac.name);
            zodiacs.Add(astroObject.venus.geo.zodiac.name);
            zodiacs.Add(astroObject.mars.helio.zodiac.name);
            zodiacs.Add(astroObject.mars.geo.zodiac.name);
            zodiacs.Add(astroObject.jupiter.helio.zodiac.name);
            zodiacs.Add(astroObject.jupiter.geo.zodiac.name);
            zodiacs.Add(astroObject.saturn.helio.zodiac.name);
            zodiacs.Add(astroObject.saturn.geo.zodiac.name);
            zodiacs.Add(astroObject.uranus.helio.zodiac.name);
            zodiacs.Add(astroObject.uranus.geo.zodiac.name);
            zodiacs.Add(astroObject.neptune.helio.zodiac.name);
            zodiacs.Add(astroObject.neptune.geo.zodiac.name);
            zodiacs.Add(astroObject.pluto.helio.zodiac.name);
            zodiacs.Add(astroObject.pluto.geo.zodiac.name);
            List<string> active_zodiacs = zodiacs.Distinct().ToList();

            List<int> number = new List<int>();
            foreach (var str in active_zodiacs)
            {
                int count = 0;
                foreach (var str2 in zodiacs)
                {
                    if (str == str2) count++;
                }
                number.Add(count);
            }
            string result = null;
            string planet;
            for (int i = 0; i < active_zodiacs.Count; i++)
            {
                planet = null;
                if (active_zodiacs[i] == astroObject.sun.helio.zodiac.name) planet += planets[0] + ", ";
                if (active_zodiacs[i] == astroObject.earth.helio.zodiac.name) planet += planets[1] + ", ";
                if (active_zodiacs[i] == astroObject.moon.helio.zodiac.name) planet += planets[2] + ", ";
                if (active_zodiacs[i] == astroObject.mercury.helio.zodiac.name) planet += planets[3] + ", ";
                if (active_zodiacs[i] == astroObject.mercury.geo.zodiac.name && active_zodiacs[i] != astroObject.mercury.helio.zodiac.name) planet += planets[3] + ", ";
                if (active_zodiacs[i] == astroObject.venus.helio.zodiac.name) planet += planets[4] + ", ";
                if (active_zodiacs[i] == astroObject.venus.geo.zodiac.name && active_zodiacs[i] != astroObject.venus.helio.zodiac.name) planet += planets[4] + ", ";
                if (active_zodiacs[i] == astroObject.mars.helio.zodiac.name) planet += planets[5] + ", ";
                if (active_zodiacs[i] == astroObject.mars.geo.zodiac.name && active_zodiacs[i] != astroObject.mars.helio.zodiac.name) planet += planets[5] + ", ";
                if (active_zodiacs[i] == astroObject.jupiter.helio.zodiac.name) planet += planets[6] + ", ";
                if (active_zodiacs[i] == astroObject.jupiter.geo.zodiac.name && active_zodiacs[i] != astroObject.jupiter.helio.zodiac.name) planet += planets[6] + ", ";
                if (active_zodiacs[i] == astroObject.saturn.helio.zodiac.name) planet += planets[7] + ", ";
                if (active_zodiacs[i] == astroObject.saturn.geo.zodiac.name && active_zodiacs[i] != astroObject.saturn.helio.zodiac.name) planet += planets[7] + ", ";
                if (active_zodiacs[i] == astroObject.uranus.helio.zodiac.name) planet += planets[8] + ", ";
                if (active_zodiacs[i] == astroObject.uranus.geo.zodiac.name && active_zodiacs[i] != astroObject.uranus.helio.zodiac.name) planet += planets[8] + ", ";
                if (active_zodiacs[i] == astroObject.neptune.helio.zodiac.name) planet += planets[9] + ", ";
                if (active_zodiacs[i] == astroObject.neptune.geo.zodiac.name && active_zodiacs[i] != astroObject.neptune.helio.zodiac.name) planet += planets[9] + ", ";
                if (active_zodiacs[i] == astroObject.pluto.helio.zodiac.name) planet += planets[10] + ", ";
                if (active_zodiacs[i] == astroObject.pluto.geo.zodiac.name && active_zodiacs[i] != astroObject.pluto.helio.zodiac.name) planet += planets[10] + ", ";
                string planet1 = planet.Substring(0, planet.Length - 2);
                result += active_zodiacs[i] + " - " + number[i] + " (" + planet1 + ")\n";
            }
            return result;
        }
    }
}
