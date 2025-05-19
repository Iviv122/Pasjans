
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Pasjans
{

    // Our column in game where we collect cards
    public class CardColumn : ITake, IPut
    {
        private int unknownCards = 0;
        LinkedList<Card> cards;

        public CardColumn(LinkedList<Card> cards)
        {
            this.cards = cards;
            unknownCards = cards.Count - 1; // index
        }
        public Tuple<LinkedList<Card>, int> GetListUnkown()
        {
            return new Tuple<LinkedList<Card>, int>(cards, unknownCards);
        }
        public void Put(LinkedList<Card> newCards)
        {
            if (cards.Count == 0)
            {
                cards = newCards;
                return; // "Cards were placed as first"
            }
            if (cards.Last?.Value.Color == newCards.First?.Value.Color)
            {
                return; // "Same color for first and last cards"
            }
            if (cards.Last?.Value.Value - 1 == newCards.First?.Value.Value)
            {
                return; // "Incorrect order"
            }

            // dodajemy karty do nowej kolumny
            foreach (Card card in newCards)
            {
                cards.AddLast(card);
            }

            return; // "Cards were added"
        }
        /// <summary>
        /// Get some cards from column
        /// </summary>
        /// <param name="startIndex"></param>
        /// <returns>Returns list or null and deny message</returns>
        public LinkedList<Card>? Take(int startIndex)
        {
            if (startIndex < unknownCards)
            {
                return null;
            }

            LinkedList<Card> newCards = new LinkedList<Card>(); // empty
            for (int i = 0; i < cards.Count; i++)
            {
                if (i < unknownCards)
                {
                    continue;
                }
                else
                {
                    newCards.AddLast(cards.ElementAt(i));
                }
            }
            return newCards;
        }
        public override string ToString()
        {
            string output = "| ";
            for (int i = 0; i < cards.Count; i++)
            {
                if (i < unknownCards)
                {
                    output += "##";
                }
                else
                {
                    output += cards.ElementAt(i);
                }

                if (i < cards.Count - 1)
                {
                    output += " -> ";
                }
            }
            return output;
        }
    }

}