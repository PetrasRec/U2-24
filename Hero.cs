using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_24
{
    /// <summary>
    /// describes entitity hero
    /// </summary>
    class Hero
    {
        public Races Race;
        public string City;
        public string Name;
        public Classes Class;
        public int Health;
        public int Mana;
        public int Damage;
        public int Defence;
        public int Strength;
        public int IQ;
        public string SpecialPower;

        public Hero(Races race, string city, string name, Classes @class, int health, int mana, int damage, int defence, int strength, int iQ, string specialPower)
        {
            Race = race;
            City = city;
            Name = name;
            this.Class = @class;
            this.Health = health;
            Mana = mana;
            Damage = damage;
            Defence = defence;
            Strength = strength;
            IQ = iQ;
            SpecialPower = specialPower;
        }
        /// <summary>
        /// overriting operator ==
        /// comparing hero powers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if powers are equal</returns>
        static public bool operator==(Hero a, Hero b)
        {
            return a.GetPower() == b.GetPower();
        }
        static public bool operator !=(Hero a, Hero b)
        {
            return !(a == b);
        }
        /// <summary>
        /// gets hero power
        /// </summary>
        /// <returns></returns>
        public int GetPower()
        {
            return Health + Defence - Damage;
        }
        /// <summary>
        /// returns hero information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Race, City, Name, Class, Health, Mana, Damage, Strength, IQ, SpecialPower);
        }
    }
}
