using System;

namespace HuntingTheManticore
{
    class Program
    {
        static void Main(string[] args)
        {
            int startManticoreHealth = 10;
            int startCityHealth = 15;
            int manticoreHealth = 10;
            int cityHealth = 15;
            int ManticorePosition = 0;
            int Round = 1;

            // Ask the first player to input the Manticores position
            Console.Write("Player 1, how far away from the city do you want to station the Manticore? (1 - 100)   ");
               ManticorePosition = int.Parse(Console.ReadLine());


            // Clear the console.
            Console.Clear();

            do
            {
                // prints the status of the round and asks for the range and shows what the damage should be based on the round
                Console.WriteLine($"Status: Round {Round}  City: {cityHealth}/{startCityHealth}   MantiCore: {manticoreHealth}/{startManticoreHealth}");
                int damage = CheckCannonDamage(Round);
                Console.WriteLine($"The cannon is expected to deal {damage} this round.");

                Console.WriteLine("Enter the desired canon range: ");
                int cannonRange = int.Parse(Console.ReadLine());


                // Checks to see where the cannon range in relation with the Manticore positon to calculate the damage.
                if (cannonRange == ManticorePosition)
                {
                    Console.WriteLine("That round was a DIRECT HIT!");
                    manticoreHealth = manticoreHealth - damage;
                }
                if (cannonRange < ManticorePosition)
                {
                    Console.WriteLine("That round FELL SHORT!");
                }
                if (cannonRange > ManticorePosition)
                {
                    Console.WriteLine("That round OVERSHOT the target!");
                }

                if (manticoreHealth > 0)
                {
                    cityHealth -= 1;
                }

              

                Round++;



            } while (manticoreHealth > 0 && cityHealth > 0);

            bool won = cityHealth > 0;
            WinorLose(won);
            
        }

        static int CheckCannonDamage(int round)
        {
            if (round % 3 == 0 && round % 5 == 0)
            {
                return 10;
            }
            if (round % 3 == 0 || round % 5 == 0)
            {
                return 3;
            }


            return 1;
        }

        static void WinorLose(bool won)
        {
            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Won! You defeated the Manticore!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The city has been destroyed. The Manticore won...");
            }
        }
    }
}
