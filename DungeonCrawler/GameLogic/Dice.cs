﻿namespace DungeonCrawler.GameLogic
{
    internal class Dice
    {
        public int NoOfDice { get; set; }
        public int NoOfSides { get; set; }
        public int Modifier { get; set; }
        public Dice(int numberOfDice, int numberOfSides, int modifier)
        {
            NoOfDice = numberOfDice;
            NoOfSides = numberOfSides;
            Modifier = modifier;
        }


        /// <summary>
        /// Throws the dice to calculate the outcome of combat.
        /// </summary>
        /// <returns>An int as result.</returns>
        public int ThrowDie()
        {
            Random rnd = new();
            int result = 0;
            
            for (int i = 1; i <= NoOfDice; i++)
            {
                result += rnd.Next(1, NoOfSides);
            }

            return result += Modifier;
        }


        /// <summary>
        /// ToString override for Dice object.
        /// </summary>
        /// <returns>A string with no of dices, no of sides and a modifier.</returns>
        public override string ToString()
        {
            return $"{NoOfDice}d{NoOfSides}+{Modifier}";
        }
    }
}
