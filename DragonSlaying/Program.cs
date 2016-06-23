using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlaying
{
    class Program
    {
        static Hero MyHero = new Hero
        {
            Name = "Brienne",
            Offense = 4,
            Defense = 2,
            MaxHitPoints = 25,
            HitPoints = 25,
        };

        static Dragon MyEnemy = new Dragon
        {
            Name = "Dragon",
            Offense = 16,
            Defense = 12,
            MaxHitPoints = 60,
            HitPoints = 60
        };


        /// <summary>
        /// Runs a battle between a Hero and a Dragon. Ends when one of them has 0 HitPoints.
        /// </summary>
        /// <param name="hero">The Hero in the battle.</param>
        /// <param name="enemy">The Dragon in the battle.</param>
        static void Battle(Hero hero, Dragon enemy)
        {
            // TODO++: modify Battle to take a List<Dragon> of enemies, and have each of them attack every time through the loop.
            // You may want to have the Hero automatically attack the first enemy in the list that is still alive.
            Die myDie = new Die(20);
            Console.WriteLine(MyHero);

            Console.WriteLine("VERSUS");

            Console.WriteLine(MyEnemy);


            while (MyHero.IsAlive())
            {
                int attackRoll = myDie.Roll();
                Console.WriteLine("Rolled {0} for attack phase", attackRoll);
                MyHero.Attack(MyEnemy, attackRoll);
                Console.WriteLine(MyEnemy);

                if (!MyEnemy.IsAlive())
                {
                    Console.WriteLine("{0} slayed {1}!", MyHero.Name, MyEnemy.Name);
                    break;
                }
                int defenseRoll = myDie.Roll();
                Console.WriteLine("Rolled {0} for defense phase", defenseRoll);
                MyHero.Defend(MyEnemy, defenseRoll);
                Console.WriteLine(MyHero);
            }

            if (!MyHero.IsAlive())
            {
                Console.WriteLine("{0} was defeated by {1}. :(", MyHero.Name, MyEnemy.Name);
            }

        }

        static void Main(string[] args)
        {

            Console.WriteLine("{0} must slay {1} to continue on the journey.", MyHero.Name, MyEnemy.Name);

            Console.WriteLine(MyHero);

            Battle(MyHero, MyEnemy);

            Console.ReadLine();
        }
    }
}
