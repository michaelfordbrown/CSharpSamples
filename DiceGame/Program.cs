using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            //Constants
            const int maxDice = 25;
            const int maxPlayers = 4;

            //Non Class Declarations
            int dice = 0;
            int players = 0;
            int[] diceRoll = { 1, 2, 3, 4, 5, 6 };

            //Class Declarations
            //Pseudo-Random Number Generator Class
            Random rnd = new Random();
            //Cryptographically strong sequence of random values.
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

            //Program Start
            Console.WriteLine("Random Dice Game Using Three Generation Techniques");

            //Determine the number of players
            do
            {
                Console.WriteLine("Enter the number of players (1 - {0})", maxPlayers);
                players = Int32.Parse(Console.ReadLine());
            }
            while ((players < 1) || (players > maxPlayers));


            //Determine number of dice player wants to use 
            do
            {
                Console.WriteLine("Enter the number of dice to play with (1 - {0})", maxDice);
                dice = Int32.Parse(Console.ReadLine());
            }
            while ((dice < 1) || (dice > maxDice));

            //Write out dice rolls using with Random.Next()
            Console.WriteLine("Technique" + "\t" + "Player" + "\t" + "Roll" + "\t" + "Dice");
            for (int ip = 0; ip < players; ip++)
            {
                for (int id = 0; id < dice; id++)
                {
                    //Get a random integer that is within a the range of the face of the dice.
                    Console.WriteLine("Next()" + "\t\t" + (ip + 1) + "\t" + (id + 1) + "\t" + diceRoll[rnd.Next(0, diceRoll.GetUpperBound(0))]);

                    //Write out dice rolls using with Random.Bytes()
                    byte roll = 0;
                    byte[] randomNumber = new byte[1];

                    rnd.NextBytes(randomNumber);
                    do
                    {
                        roll = (byte)(randomNumber[0] % Convert.ToByte(diceRoll.GetUpperBound(0)) + 1);
                    }
                    while (randomNumber[0] > (diceRoll.GetUpperBound(0) * (Byte.MaxValue / diceRoll.GetUpperBound(0))));

                    Console.WriteLine("NexBytes()" + "\t" + (ip + 1) + "\t" + (id + 1) + "\t" + roll);

                    //Write out dice rolls using with RNGCryptoServiceProvider.GetBytes()
                    byte crypoRoll = 0;
                    byte[] randomCrypNo = new byte[1];

                    rngCsp.GetBytes(randomCrypNo);
                    do
                    {
                        crypoRoll = (byte)(randomCrypNo[0] % Convert.ToByte(diceRoll.GetUpperBound(0)) + 1);
                    }
                    while (randomCrypNo[0] > (diceRoll.GetUpperBound(0) * (Byte.MaxValue / diceRoll.GetUpperBound(0))));

                    Console.WriteLine("RNGCrypto" + "\t" + (ip + 1) + "\t" + (id + 1) + "\t" + crypoRoll);
                }

            }
            Console.WriteLine("Press Any Key To Continue . . ");
            Console.ReadKey();
        }
    }
}
