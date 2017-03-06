using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeckShuffle
{
    public enum CardSuit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public enum CardValue
    {
        Ace = 1,
        Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    public class Card : IComparable
    {
        public CardSuit CardSuit { get; private set; }
        public CardValue CardValue { get; private set; }

        public Card(CardSuit cardSuit, CardValue cardValue)
        {
            CardSuit = cardSuit;
            CardValue = cardValue;
        }

        //public Card(CardSuit cardSuit)
        //{
        //    CardSuit = cardSuit;
        //}
        public int CompareTo(object obj)
        {
            if (obj is Card)
            {
                int result = this.CardSuit.CompareTo((obj as Card).CardSuit);
                if (result == 0)
                {
                    result = this.CardValue.CompareTo((obj as Card).CardValue);
                }
                return result;
            }
            throw new ArgumentException("Object is not a Card");
        }
        
    }



    class Program
    {
        /*
         * The Fisher–Yates shuffle is an algorithm for generating a random permutation of a finite set—in plain terms, the algorithm shuffles the set. 
         * The algorithm effectively puts all the elements into a hat; it continually determines the next element by randomly drawing an element from the hat until no elements remain. 
         * The algorithm produces an unbiased permutation: every permutation is equally likely. 
         * The modern version of the algorithm is efficient: it takes time proportional to the number of items being shuffled and shuffles them in place.
         */
        public static void ShuffleDeck(ref Card[] d)
        {
            int n = d.Length;
            Random rng = new Random();
            Card temp = new Card(CardSuit.Spades, CardValue.Ace);

            while (n > 1)
            {
                int k = rng.Next(n--);
                temp = d[n];
                d[n] = d[k];
                d[k] = temp;
            }
        }

        public static void ShowDeck(Card[] d)
        {
            for (int l = 0; l < 52; l++)
            {
                Console.WriteLine(d[l].CardSuit + " " + d[l].CardValue);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {

            Card[] deck = new Card[52];
            int i = 0;

            Console.WriteLine("Card Deck Shuffle");
            for (CardSuit iSuite = CardSuit.Spades; iSuite <= CardSuit.Clubs; iSuite++)
            {
                for (CardValue iValue = CardValue.Ace; iValue <= CardValue.King; iValue++)
                {
                    deck[i] = new Card(iSuite, iValue);
                    if (i < 52)
                    {
                        i++;
                    }
                }
            }

            Console.WriteLine("Initial State of Card Deck");
            ShowDeck(deck);

            // Fisher–Yates shuffle
            ShuffleDeck(ref deck);
            Console.WriteLine("Shuffles State of Card Deck");
            ShowDeck(deck);

            // Sort By Value using IComparable.
            Console.WriteLine("Sort Deck By Value using IComparable");
            Array.Sort(deck);
            ShowDeck(deck);

            Console.WriteLine("Press Any Key To Continue . . ");
            Console.ReadKey();
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }
    }
}
