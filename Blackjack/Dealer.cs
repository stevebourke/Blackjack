using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer
    {
        public int DealerHand { get; set; }

        public void UpdateDealerHand(int[] DealerTotal, Dealer d1)

        {
            //This adds up all the cards in the DealerTotal to give the Dealer's hand - not very pretty
            //and very slow too! Step out of, not into!

            d1.DealerHand = 0;

            foreach (int val in DealerTotal)

            {
                d1.DealerHand += val;
            }
        }

    }
}
