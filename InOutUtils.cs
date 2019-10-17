using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace U2_24
{
    /// <summary>
    /// inputs and output logic
    /// </summary>
    class InOutUtils
    {
        /// <summary>
        /// reads informations and saves it into Hero list
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>List of heroes</returns>
        static public List<Hero> ReadHeroesFromRace(string fileName)
        {
            List<Hero> heroes = new List<Hero>();
            string[] lines = File.ReadAllLines(fileName);
            
            foreach(var line in lines)
            {
                var inputs = line.Split(';');

                Hero h = new Hero((Races)Enum.Parse(typeof(Races), inputs[0]), inputs[1], 
                                    inputs[2], (Classes)Enum.Parse(typeof(Classes), inputs[3]), int.Parse(inputs[4]),
                                    int.Parse(inputs[5]), int.Parse(inputs[6]), int.Parse(inputs[7]), int.Parse(inputs[8]), int.Parse(inputs[9]),
                                    inputs[10]);
                heroes.Add(h);
            }
            return heroes;
        }


        static public void PrintInputToCsv(string fileName, List<Hero> heroes)
        {
            string[] lines = new string[heroes.Count * 2 + 3];
            lines[0] = new string('-', 196);
            lines[1] = String.Format("| {0, -15} | {1, -12} | {2, -15} | {3, -15} | {4, 15} | {5, 15} | {6, 15} | {7, 15} | {8, 15} | {9, 15} | {10, -15} |",
                "Race", "City", "Name", "Class", "Health", "Mana", "Damage", "Defence", "Strength", "IQ", "SpecialPower");
            lines[2] = new string('-', 196);
            for (int i = 0; i < heroes.Count; i++)
            {
                lines[2 * i + 3] = String.Format("| {0, -15} | {1, -12} | {2, -15} | {3, -15} | {4, 15} | {5, 15} | {6, 15} | {7, 15} | {8, 15} | {9, 15} | {10, -15} |",
                heroes[i].Race, heroes[i].City, heroes[i].Name, heroes[i].Class, heroes[i].Health, heroes[i].Mana, heroes[i].Damage, heroes[i].Defence, heroes[i].Strength, heroes[i].IQ, heroes[i].SpecialPower);
                lines[2 * i + 4] = new string('-', 196);
            }
            File.WriteAllLines(fileName, lines, Encoding.Unicode);
        }
        /// <summary>
        /// prints given classes to given csv
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="classes">given list of classes to print</param>
        static public void PrintClassesToCsv(string fileName, List<Classes> classes)
        {
            string[] lines = new string[classes.Count + 1];
            lines[0] = "Classes";
            for(int i = 0; i < classes.Count; i++)
            {
                lines[i+1] = classes[i].ToString();
            }
            File.WriteAllLines(fileName, lines);
        }
        /// <summary>
        /// prints missing classes from each race
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="missingClasses">missing classes</param>
        static public void PrintMissingClasses(string fileName, Dictionary<Races, List<Classes>> missingClasses)
        {
            string[] lines = new string[HeroRegister.GetNumberOfLinesToPrint(missingClasses)];
            int index = 0;

            foreach(var missingRaceClasses in missingClasses)
            {
                lines[index] = "Race: " + missingRaceClasses.Key.ToString();
                index++;
                foreach (var @class in missingRaceClasses.Value)
                {
                    lines[index] = @class.ToString();
                    index++;
                }
                if (missingRaceClasses.Value.Count == 0)
                    lines[index] = "Visi";
            }

            File.WriteAllLines(fileName, lines);
        }
        /// <summary>
        /// prints given list of heroes
        /// </summary>
        /// <param name="strongest"></param>
        static public void PrintStrongestHero(List<Hero> strongest)
        {
            if(strongest.Count == 0)
            {
                Console.WriteLine("There are no heroes in the database");
                return;
            }
            Console.WriteLine("Strongest " + (strongest.Count > 1 ? "heroes" : "hero") + ":");

            foreach(var hero in strongest)
            {
                Console.WriteLine(hero);
            }
        }
    }
}
