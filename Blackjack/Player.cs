using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        public int PlayerHand { get; set; }

        public void UpdatePlayerHand(int[] Total, Player p1)

        {
            //The same as the method for the Dealer, adding up dealt cards to get the player's total

            p1.PlayerHand = 0;

            foreach (int val in Total)

            {
                p1.PlayerHand += val;
            }
        }
    }
}
