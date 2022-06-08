using System;

namespace Blackjack
{
    public class GameMethods
    {
        //A lot of code in here, I would have liked to use the same methods to give cards to the player
        //and dealer, manage aces etc. but time constraints meant that I didn't figure out a way, so
        //I have repeated methods, while applying the player or dealer depending on whose turn it is.
        //As mentioned in Program.cs the ManageAces method is a mess.


        //A method to deal the first two cards to the player
        public static void GiveTwoCards(int[] DealtCards, int[] Total, Deck deck1, Player p1)

        {
            //Clear the array for multiple games

            Array.Clear(Total, 0, 52);

            Random rand = new Random();

            //Pick the first random card for the player

            int c1 = rand.Next(51);

            //Get the card attributes for int c1 ; add to the DealtCards and Total arrays

            string card1Name = deck1.CardName[c1];

            string card1Suit = deck1.CardSuit[c1];

            int card1Value = deck1.CardValue[c1];

            DealtCards[0] = c1;


            Total[0] = deck1.CardValue[c1];

            //Pick the second random card for the player

            int c2 = rand.Next(51);

            //To avoid picking the same card again

            while (c1 == c2)

            { c2 = rand.Next(51); }

            //Same as above

            string card2Name = deck1.CardName[c2];

            string card2Suit = deck1.CardSuit[c2];

            int card2Value = deck1.CardValue[c2];

            DealtCards[1] = c2;

            Total[1] = deck1.CardValue[c2];


            //Update the value of the player's hand before displaying the total

            p1.UpdatePlayerHand(Total, p1);

            //Print out details to screen

            Console.WriteLine("Your first card is the {0} of {1}, value {2}\n" +
                "Your second card is the {3} of {4}, value {5}\n" +
                "Your total is {6}", card1Name, card1Suit, card1Value, card2Name, card2Suit, card2Value, p1.PlayerHand);

            if (p1.PlayerHand == 21)
            {
                Console.WriteLine("Blackjack!");
            }

            else
            {

                GetAnotherCard(DealtCards, Total, deck1, p1);

            }

        }
        //End of method



        //This will give a third card, and more, while the player wants more cards, and the total
        //hand is under 22
        public static void GetAnotherCard(int[] DealtCards, int[] Total, Deck deck1, Player p1)
        {

            while (p1.PlayerHand < 22)
            {
                Console.WriteLine("Do you want another card?\n" +
                            "Please enter Y/N");
                string answer = Console.ReadLine();

                if (answer == "N" || answer == "n" || answer == "no")
                { break; }

                if (answer == "Y" || answer == "y" || answer == "yes")
                {
                    //If answer is yes, give another card, same as above

                    Random rd = new Random();
                    int i = rd.Next(51);

                    DealtCards[i] = i;

                    //This stops the same card from being dealt twice - if chosen card is not already in array
                    //of DealtCards, -1 will be returned by IndexOf()

                    while (Array.IndexOf(DealtCards, i) != -1)
                    {
                        i = rd.Next(51);
                    }

                    string cardsName = deck1.CardName[i];

                    string cardsSuit = deck1.CardSuit[i];

                    int cardsValue = deck1.CardValue[i];

                    Total[i] = deck1.CardValue[i];

                    p1.UpdatePlayerHand(Total, p1);

                    //Here I try to take care of any aces in the hand

                    ManageAcesPlayer(Total, p1);

                    //Update total in case ace value has gone from 11 to 1, and display third card to screen

                    p1.UpdatePlayerHand(Total, p1);

                    Console.WriteLine("Your card is the {0} of {1}, value {2}\n" +
                        "Your total hand is {3}", deck1.CardName[i], deck1.CardSuit[i], deck1.CardValue[i], p1.PlayerHand);

                    if (p1.PlayerHand > 21)
                    {
                        { break; }

                    }



                }

            }

        }
        //End of method



        //This is basically the same method as above for the player - obviously one method to cover both
        //instances would be preferable
        public static void GiveTwoCardsToDealer(int[] DealtCards, int[] DealerTotal, Deck deck1, Dealer d1, Player p1)
        {
            Array.Clear(DealerTotal, 0, 52);

            Random rand = new Random();

            //Pick the first card for the dealer

            int c1 = rand.Next(51);

            string dealerCard1Name = deck1.CardName[c1];

            string dealerCard1Suit = deck1.CardSuit[c1];

            int dealerCard1Value = deck1.CardValue[c1];

            DealtCards[51] = c1;


            DealerTotal[50] = deck1.CardValue[c1];

            //Pick the second card for the player

            int c2 = rand.Next(51);

            //To avoid picking the same card again

            while (c1 == c2)

            { c2 = rand.Next(51); }


            string dealerCard2Name = deck1.CardName[c2];

            string dealerCard2Suit = deck1.CardSuit[c2];

            int dealerCard2Value = deck1.CardValue[c2];

            DealtCards[1] = c2;

            DealerTotal[1] = deck1.CardValue[c2];


            //Update the value of the dealer's hand

            d1.UpdateDealerHand(DealerTotal, d1);

            Console.WriteLine("Dealer's first card is the {0} of {1}, value {2}\n" +
                "Dealer's second card is the {3} of {4}, value {5}\n" +
                "The Dealer's total is {6}", dealerCard1Name, dealerCard1Suit, dealerCard1Value, dealerCard2Name, dealerCard2Suit, dealerCard2Value, d1.DealerHand);

            Console.ReadLine();

            if (d1.DealerHand == 21)
            { Console.WriteLine("Blackjack!"); }


            if (d1.DealerHand == p1.PlayerHand)
            { Console.WriteLine("It's a draw!"); }

            if (d1.DealerHand > p1.PlayerHand)
            { Console.WriteLine("Dealer wins!"); }



        }
        //End of method



        //Similar to the method for giving the player third and subsequent cards, but without asking if
        //more cards are wanted, and making sure that if the dealer is over 17 he doesn't get any more cards
        public static void GetAnotherDealerCard(int[] DealtCards, int[] DealerTotal, Deck deck1, Dealer d1, Player p1)
        {
            while (d1.DealerHand < 17)
            {
                //If dealer hand is under 17, but he has a better hand than the player then he wins

                if (d1.DealerHand > p1.PlayerHand)
                {
                    break;
                }

                //Again, giving a random card to the dealer, repeated while his hand < 17

                Random rd = new Random();
                int i = rd.Next(51);

                while (Array.IndexOf(DealtCards, i) != -1)
                {
                    i = rd.Next(51);
                }

                DealtCards[i] = i;

                string cardsName = deck1.CardName[i];

                string cardsSuit = deck1.CardSuit[i];

                int cardsValue = deck1.CardValue[i];

                DealerTotal[i] = deck1.CardValue[i];

                d1.UpdateDealerHand(DealerTotal, d1);

                //Manage the aces method called

                ManageAcesDealer(DealerTotal, d1);

                //Again update the dealer's total in case any aces were set to value of 1

                d1.UpdateDealerHand(DealerTotal, d1);

                Console.WriteLine("The dealer's next card is the {0} of {1}, value {2}\n" +
                    "The dealer total is {3}", deck1.CardName[i], deck1.CardSuit[i], deck1.CardValue[i], d1.DealerHand);

                //If dealer goes bust display message ; use PlayAgain() method

                if (d1.DealerHand > 21)
                {
                    Console.WriteLine("Dealer is bust. You win!");

                }
            }
        }
        //End of method



        //This method could possibly be called on more frequently,
        //taking out all other checks present throughout the methods, and directing to here
        public static void CompareHands(Player p1, Dealer d1)
        {
            if (d1.DealerHand > p1.PlayerHand && d1.DealerHand < 22)
            {
                Console.WriteLine("Dealer wins!");
            }

            if (d1.DealerHand == p1.PlayerHand && d1.DealerHand >= 17)
            {
                Console.WriteLine("It's a draw!");

            }

            if (d1.DealerHand < p1.PlayerHand && d1.DealerHand >= 17)
            {
                Console.WriteLine("You win!");

            }
        }
        //End of method



        //A predicate to find all aces could have then allowed to create a new array of aces
        //might have allowed me to reduce their value to 1 if hand was over 21
        public static void ManageAcesPlayer(int[] Total, Player p1)
        {
            //If hand is over 21...
            if (p1.PlayerHand > 21)
            {

                //...and it contains an ace
                if (Array.IndexOf(Total, 11) >= 0)
                {
                    int k = Array.IndexOf(Total, 11);
                    Total[k] = 1;

                    p1.UpdatePlayerHand(Total, p1);

                    if (p1.PlayerHand > 21)

                    {
                        if (Array.IndexOf(Total, 11) >= 0)

                        {
                            int m = Array.IndexOf(Total, 11);
                            Total[m] = 1;

                            p1.UpdatePlayerHand(Total, p1);

                            if (p1.PlayerHand > 21)

                            {
                                if (Array.IndexOf(Total, 11) >= 0)
                                {
                                    int n = Array.IndexOf(Total, 11);
                                    Total[n] = 1;

                                    p1.UpdatePlayerHand(Total, p1);
                                }

                            }
                        }

                    }



                }


            }
        }
        //End of method


            //Seems to be working better now - took out the while loops which were causing trouble
        public static void ManageAcesDealer(int[] DealerTotal, Dealer d1)
        {

            {


                if (d1.DealerHand > 21)
                {

                    if (Array.IndexOf(DealerTotal, 11) >= 0)
                    {

                        {
                            int k = Array.IndexOf(DealerTotal, 11);
                            DealerTotal[k] = 1;

                            if (d1.DealerHand > 21)

                            {

                                if (Array.IndexOf(DealerTotal, 11) >= 0)
                                {
                                    int m = Array.IndexOf(DealerTotal, 11);
                                    DealerTotal[m] = 1;

                                    if (d1.DealerHand > 21)

                                    {
                                        if (Array.IndexOf(DealerTotal, 11) >= 0)

                                        {
                                            int n = Array.IndexOf(DealerTotal, 11);
                                            DealerTotal[n] = 1;

                                        }

                                    }
                                }

                            }

                        }
                    }


                }
            }
        }
        //End of method



        //Check if player wants to play again and return a boolean which will be checked at the beginning
        //of Program.cs
        public static bool PlayAgain()
        {

            Console.WriteLine("Do you want to play again? Y/N");
            string playAgain = Console.ReadLine();
            Console.Clear();

            if (playAgain == "Y" || playAgain == "y" || playAgain == "yes")
            { return true; }

            else
            { return false; }


        }
        //End of method



    }
}
