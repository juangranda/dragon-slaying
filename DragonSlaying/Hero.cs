﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlaying
{
    public class Hero
    {
        public string Name { get; set; }
        public int Offense { get; set; }
        public int Defense { get; set; }
        public int MaxHitPoints { get; set; }

        // TODO: Add any necessary fields
        public int Gold { get; set; }
        private int _hitPoints;
        
        /// <summary>
        /// Keeps track of the number of hit points a Hero has. Cannot be less than 0
        /// (if a negative number is passed in, HitPoints will be set to 0 instead).
        /// </summary>
        public int HitPoints
        {
            get
            {
                // TODO
                return _hitPoints;
                //throw new NotImplementedException();
            }
            set
            {
                if (value < 0)
                {
                    _hitPoints = 0;
                }
                else
                {
                    _hitPoints = value;
                }
            }
        }

        /// <summary>
        /// Returns a nicely formatted string that includes the current status of the Hero.
        /// <example><code>
        /// Brienne
        /// ==========
        /// Off: 4  Def: 2
        /// HP: 25/25
        /// Gold: 20
        /// </code></example>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // TODO
            var sb = new StringBuilder();

            sb.AppendLine(Name);
            sb.AppendLine("==========");
            sb.AppendFormat("Off: {0}\tDef: {1}\n", Offense, Defense);
            sb.AppendFormat("HP: {0}/{1}\n", HitPoints, MaxHitPoints);

            return sb.ToString();

            //throw new NotImplementedException();
        }


        /// <summary>
        /// Checks if the Hero is alive.
        /// <para>A Hero is alive if their <see cref="HitPoints"/> are greater than 0.</para>
        /// </summary>
        /// <returns>true if the Hero is alive, false if they are not</returns>
        public bool IsAlive()
        {
            // TODO
            if (HitPoints > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Runs an attack phase for the Hero.
        /// <para>Damage is calculated by taking the <paramref name="diceRoll"/> parameter, adding the Hero's <see cref="Offense"/>, and subtracting the <paramref name="opponent"/>'s Defense.</para>
        /// <para>The damage must be zero or positive - if it is calculated to be negative using the above formula, no damage is dealt.</para>
        /// <para>If the <paramref name="diceRoll"/> is 1, the attack fails and the damage dealt is 0, regardless of the above calculations.</para> If the <paramref name="diceRoll"/> is 20, the attack is a critical hit and automatically succeeds with a value that is three times the Hero's "natural" <see cref="Offense"/>.</para>
        /// <para>After damage is calculated according to the above rules, the Dragon receives the damage by having that amount subtracted from the Dragon's <see cref="Dragon.HitPoints"/></para>
        /// </summary>
        /// <param name="opponent">The Dragon to attack</param>
        /// <param name="diceRoll">A number (1-20) from a dice roll, relating to the effectiveness of the attack</param>
        public void Attack(Dragon opponent, int diceRoll)
        {

            int dragonDamage = diceRoll + Offense - opponent.Defense;
            if (dragonDamage < 0)
            {
                dragonDamage = 0;
            }
            if (diceRoll == 1)
            {
                dragonDamage = 0;
            }
            if (diceRoll == 20)
            {
                dragonDamage = Offense * 3;
            }
            opponent.HitPoints -= dragonDamage;
            // TODO
        }

        /// <summary>
        /// Runs a defend phase for the Hero.
        /// <para>Damage is calculated by taking the opponent's <see cref="Dragon.Offense"/>, subtracting the <paramref name="diceRoll"/> parameter, and subtracting the Hero's <see cref="Defense"/>.</para>
        /// <para>The damage must be zero or positive - if it is calculated to be negative using the above formula, no damage is dealt.</para>
        /// <para>If the <paramref name="diceRoll"/> is 1, the defense is a critical failure and the Hero takes damage equal to the Dragon's <see cref="Dragon.Offense"/>, regardless of the above calculations.</para> If the <paramref name="diceRoll"/> is 20, the attack is blocked and the Hero receives zero damage, regardless of the above calculations.</para>
        /// <para>After damage is calculated according to the above rules, the Hero receives the damage by having that amount subtracted from the Hero's <see cref="HitPoints"/></para>
        /// </summary>
        /// <param name="opponent">The Dragon to attack</param>
        /// <param name="diceRoll">A number (1-20) from a dice roll, relating to the effectiveness of the block</param>
        public void Defend(Dragon opponent, int diceRoll)
        {
            // TODO
            int heroDamage = opponent.Offense - diceRoll - Defense;
            if (heroDamage < 0)
            {
                heroDamage = 0;
            }
            if (diceRoll == 1)
            {
                heroDamage = opponent.Offense;
            }
            if (diceRoll == 20)
            {
                heroDamage = 0;
            }
            HitPoints -= heroDamage;
        }
    }
}
