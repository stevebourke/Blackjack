using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack

{
    public class Deck
    {

        //Three array which will hold the names, suits and values of the cards in the deck

        public string[] CardName { get; set; }

        public string[] CardSuit { get; set; }

        public int[] CardValue { get; set; }


        /**I am using this constructor to pass in my arrays from Program.cs and assign them
        to my Deck properties. There is probably a better way of creating an array in this class,
        but I kept running into problems, so this will have to suffice!**/

        public Deck(string[] Cards, string[] Suits, int[] Values)

        {
            CardName = Cards;

            CardSuit = Suits;

            CardValue = Values;
        }


        //An empty constructor which could be useful to have

        public Deck()

        {

        }

    }
}
