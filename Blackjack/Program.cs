using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    //I created the cards in the Program.cs and fed them in to the deck.
    //Most other methods are created in GameMethods, and mostly called here, although some are used directly,
    //within other methods. Overall it's a bit messy, and only the ManageAces methods are cobbled together a bit.
    //I was looking into using a predicate and FindAllIndex to weed
    //out all aces but I couldn't figure it out, and was running out of time, so I resorted to 
    //lots of (possibly faulty) looping. I also ran out of time for an extra feature.

    public class Program
    {
        static void Main(string[] args)
        {
            //Calling the three methods below which have produced the card attributes

            string[] Cards = GetNames();

            string[] Suits = GetSuits();

            int[] Values = GetValues();

            //This array will hold all cards in the player's hand

            int[] Total = new int[52];

            //Likewise for the dealer

            int[] DealerTotal = new int[52];

            //This array holds all cards dealt in a game. I will use this array
            //to prevent the random function from giving the same card twice

            int[] DealtCards = new int[52];


            //Here I am passing the elements of the Cards array into the Deck class
            //through the creation of a new deck object

            Deck deck1 = new Deck(Cards, Suits, Values);

            //Create a player and set their hand to 0

            Player p1 = new Player();

            p1.PlayerHand = 0;

            //Likewise for the dealer

            Dealer d1 = new Dealer();

            d1.DealerHand = 0;

            //This boolean will allow me to loop the game

            bool playAgain = true;



            while (playAgain == true)
            {
                //Call on the methods in the GameMethods class

                GameMethods.GiveTwoCards(DealtCards, Total, deck1, p1);


                if (p1.PlayerHand < 22)
                {
                    GameMethods.GiveTwoCardsToDealer(DealtCards, DealerTotal, deck1, d1, p1);


                    GameMethods.GetAnotherDealerCard(DealtCards, DealerTotal, deck1, d1, p1);


                    GameMethods.CompareHands(p1, d1);
                }
                    playAgain = GameMethods.PlayAgain();


                
            }
        }

        //Method for entering card names into the Cards array

        public static string[] GetSuits()
        {
            string[] Suits = new string[52];

            int i;

            for (i = 0; i < 13; i++)
            { Suits[i] = "Hearts"; }

            for (i = 13; i < 26; i++)
            { Suits[i] = "Diamonds"; }

            for (i = 26; i < 39; i++)
            { Suits[i] = "Clubs"; }

            for (i = 39; i < 52; i++)
            { Suits[i] = "Spades"; }


            return Suits;

        }//End of method

        //Method to produce suits for the deck

        public static string[] GetNames()
        {
            string[] Cards = new string[52];

            int i;

            for (i = 1; i < 10; i++)
            { Cards[i] = $"{i + 1}"; }

            for (i = 14; i < 23; i++)
            { Cards[i] = $"{i - 12}"; }

            for (i = 27; i < 36; i++)
            { Cards[i] = $"{i - 25}"; }

            for (i = 40; i < 49; i++)
            { Cards[i] = $"{i - 38}"; }

            for (i = 0; i < 52; i++)
                if (i == 0 || i == 13 || i == 26 || i == 39)
                { Cards[i] = "Ace"; }

            for (i = 0; i < 52; i++)
                if (i == 10 || i == 23 || i == 36 || i == 49)
                { Cards[i] = "Jack"; }

            for (i = 0; i < 52; i++)
                if (i == 11 || i == 24 || i == 37 || i == 50)
                { Cards[i] = "Queen"; }

            for (i = 0; i < 52; i++)
                if (i == 12 || i == 25 || i == 38 || i == 51)
                { Cards[i] = "King"; }


            return Cards;
        }//End of method

        //A similar method to above, this time returning an array of the values of the cards

        public static int[] GetValues()
        {
            int[] Values = new int[52];

            int i;

            for (i = 1; i < 10; i++)
            { Values[i] = i + 1; }

            for (i = 14; i < 23; i++)
            { Values[i] = i - 12; }

            for (i = 27; i < 36; i++)
            { Values[i] = i - 25; }

            for (i = 40; i < 49; i++)
            { Values[i] = i - 38; }

            for (i = 0; i < 52; i++)
                if (i == 0 || i == 13 || i == 26 || i == 39)
                { Values[i] = 11; }

            for (i = 0; i < 52; i++)
                if (i == 10 || i == 11 || i == 12 || i == 23 || i == 24 || i == 25 ||
                    i == 36 || i == 37 || i == 38 || i == 49 || i == 50 || i == 51)
                { Values[i] = 10; }



            return Values;
        }//End of method
    }
}
