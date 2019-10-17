using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_24
{
    /// <summary>
    /// class that handles logic of this problem
    /// </summary>
    class HeroRegister
    {
        private static Dictionary<Races, List<Hero> > Heroes = new Dictionary<Races, List<Hero>>();
        private static List<Classes> AllClasses = Enum.GetValues(typeof(Classes)).Cast<Classes>().ToList();
        private static List<Races> AllRaces = Enum.GetValues(typeof(Races)).Cast<Races>().ToList();

        /// <summary>
        /// Method that adds a race to the register
        /// </summary>
        /// <param name="race">Race type</param>
        /// <param name="heroes">list of heroes in that race</param>
        static public void AddRace(Races race, List<Hero> heroes)
        {
            Heroes.Add(race, heroes);
        }

        /// <summary>
        /// is used in InOutUtils
        /// to calculate how many lines of strings to make
        /// to ease the printing
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static public int GetNumberOfLinesToPrint(Dictionary<Races, List<Classes>> obj)
        {
            int sum = obj.Count;

            foreach (var o in obj)
            {
                sum += o.Value.Count;
                if (o.Value.Count == 0)
                    sum++;
            }

            return sum;
        }
        /// <summary>
        /// method that adds all heroes into 1 array
        /// </summary>
        /// <returns>all heroes</returns>
        static private List<Hero> GetAllHeroes()
        {
            List<Hero> allHeroes = new List<Hero>();

            foreach(var heroes in Heroes.Values)
            {
                foreach(var hero in heroes)
                {
                    allHeroes.Add(hero);
                }
            }
            return allHeroes;
        }
        /// <summary>
        /// Gets all existing classes inside heroes array
        /// </summary>
        /// <returns>unique classes</returns>
        static public List<Classes> GetAllClasses()
        {
            List<Classes> classes = new List<Classes>();

            foreach(var hero in GetAllHeroes())
            {
                if (!classes.Contains(hero.Class))
                    classes.Add(hero.Class);
            }
            return classes;
        }
        /// <summary>
        /// Does race constains given class
        /// </summary>
        /// <param name="race">given race</param>
        /// <param name="class">given  class</param>
        /// <returns>true if race constains class, otherwise flase</returns>
        static public bool HasClass(Races race, Classes @class)
        {
            // If Heroes dictionary doesn't have this race, then also it doesn't have any of the given classes
            if(!Heroes.Keys.Contains(race))
                return true;

            foreach(var hero in Heroes[race])
            {
                if (hero.Class == @class)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// finds missing classes
        /// </summary>
        /// <param name="race"></param>
        /// <returns>missing classes</returns>
        static public List<Classes> MissingClasses(Races race)
        {
            List<Classes> missingClasses = new List<Classes>();

            foreach(var @class in AllClasses)
            {
                if(!HasClass(race, @class))
                   missingClasses.Add(@class);
            }
            return missingClasses;
        }
        /// <summary>
        /// calculates missing classes from all races
        /// </summary>
        /// <returns>all missing classes from all races</returns>
        static public Dictionary<Races, List<Classes>> MissingClasses()
        {
            Dictionary<Races, List<Classes>> missing = new Dictionary<Races, List<Classes>>();

            foreach (var race in AllRaces)
            {
                missing.Add(race, MissingClasses(race));
            }
            return missing;
        }
        /// <summary>
        /// find strongest hero power
        /// </summary>
        /// <param name="heroes">heroes in which I'll find strongest power</param>
        /// <returns>strongest power integer</returns>
        public static int StrongestHeroPower(List<Hero> heroes)
        {
            int bestPower = -int.MaxValue;

            foreach(var hero in heroes)
            {
                if(hero.GetPower() > bestPower)
                {
                    bestPower = hero.GetPower();
                }
            }
            return bestPower;
        }
        /// <summary>
        /// finds strongest heroes from this race
        /// </summary>
        /// <param name="race">given race</param>
        /// <returns>strongest heroes</returns>
        public static List<Hero> StrongestRaceHero(Races race)
        {
            List<Hero> strongest = new List<Hero>();
            int strongestPower = StrongestHeroPower(Heroes[race]);
            foreach(var hero in Heroes[race])
            {
                if(hero.GetPower() == strongestPower)
                {
                    strongest.Add(hero);
                }
            }
            return strongest;
        }
        /// <summary>
        /// calculates strongest heroe from all races
        /// </summary>
        /// <returns>strongest heroe or heroes if there are multiple of them</returns>
        public static List<Hero> StrongestRaceHero()
        {
            List<Hero> strongestOverall = new List<Hero>();

            foreach(var hero in Heroes)
            {
                // gets strongest heroes from this race, there may be multiple ones with equal power
                List<Hero> strongestFromRace = StrongestRaceHero(hero.Key);
                
                if (strongestOverall.Count == 0)
                    strongestOverall = strongestFromRace;
                else
                {
                    // if previously found strongest hero is the same strenght as current, then add it to the list
                    if(strongestOverall.First() == strongestFromRace.First())
                        strongestOverall.AddRange(strongestFromRace);    
                    else
                        // overrite previous best
                        strongestOverall = strongestFromRace;
                }

            }

            return strongestOverall;
        }
    }
}
