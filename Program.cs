using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_24
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes1 = InOutUtils.ReadHeroesFromRace("Elfs3.csv");
            List<Hero> heroes2 = InOutUtils.ReadHeroesFromRace("Humans3.csv");
            InOutUtils.PrintInputToCsv("Pradiniai1.txt", heroes1);
            InOutUtils.PrintInputToCsv("Pradiniai2.txt", heroes2);


            HeroRegister.AddRace(Races.Elf, heroes1);
            HeroRegister.AddRace(Races.Human, heroes2);
            InOutUtils.PrintClassesToCsv("Klases.csv", HeroRegister.GetAllClasses());
            InOutUtils.PrintMissingClasses("Trukstami.csv", HeroRegister.MissingClasses());
            InOutUtils.PrintStrongestHero(HeroRegister.StrongestRaceHero());


            Console.ReadKey();
        }
    }
}
