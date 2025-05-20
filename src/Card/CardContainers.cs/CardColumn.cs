
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
        public CardColumn(LinkedList<Card> cards,int uknown)
        {
            this.cards = cards;
            unknownCards = uknown; 
        }
        public Tuple<LinkedList<Card>, int> GetListUnkown()
        {
            return new Tuple<LinkedList<Card>, int>(cards, unknownCards);
        }
        public CardColumn Clone()
        {
            LinkedList<Card> Newcards = new();
            foreach (var item in cards)
            {
                Newcards.AddLast(item);
            }
            return new CardColumn(Newcards,unknownCards);
        }
        public void Put(LinkedList<Card> newCards)
        {
            if (newCards == null || newCards.Count == 0)
                return; // Nothing to add

            // If the stack is empty and the first new card is the starting card
            if (cards.Count == 0)
            {
                if (newCards.First.Value.Value == Card.MaxValue)
                {
                    cards = new LinkedList<Card>(newCards);
                    newCards.Clear(); // Empty the source after adding
                    return;
                }
                return; // Invalid first card
            }

            // Validate color
            if (cards.Last?.Value.Color == newCards.First?.Value.Color)
            {
                return; // Can't place card with same color
            }

            // Validate order
            if (cards.Last?.Value.Value - 1 != newCards.First?.Value.Value)
            {
                return; // Incorrect order
            }

            // Add cards
            foreach (Card card in newCards)
            {
                cards.AddLast(card);
            }
            newCards.Clear(); // Clear after transferring
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
            for (int i = startIndex; i < cards.Count; i++)
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
            foreach (var item in newCards)
            {
                cards.Remove(item);
            }
            if (startIndex == unknownCards && unknownCards > 0)
            {
                unknownCards--;
            }
            return newCards;
        }
        public override string ToString()
        {
            string output = "| ";
            for (int i = 0; i < cards.Count; i++)
            {
                    output += cards.ElementAt(i);

                if (i < cards.Count - 1)
                {
                    output += " -> ";
                }
            }
            return output;
        }
    }

}