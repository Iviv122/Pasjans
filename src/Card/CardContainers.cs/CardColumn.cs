namespace Pasjans
{

    // Our column in game where we collect cards
    public class CardColumn 
    {
        private int knownCards = 0;
        LinkedList<Card> cards;

        public CardColumn(LinkedList<Card> cards)
        {
            this.cards = cards;
            knownCards = cards.Count() - 1;
        }
        // simple case
        public ActionResponse<String> Append(Card card)
        {
            if(cards.Count == 0){
                cards.AddLast(card);
            return new ActionResponse<string>("Card was added as first");
            }
            if (cards.Last?.Value.Color == card.Color)
            {
                return new ActionResponse<string>("Same color for cards");
            }
            if (cards.Last?.Value.Value != card.Value + 1)
            {
                return new ActionResponse<string>("Incorrect order");
            }

            cards.AddLast(card);
            return new ActionResponse<string>("Card was added");
        }
        public ActionResponse<String> Append(LinkedList<Card> newCards)
        {
            if (cards.Count == 0)
            {
                cards = newCards;
                return new ActionResponse<string>("Cards were placed as first");
            }
            if (cards.Last?.Value.Color == newCards.First?.Value.Color)
            {
                return new ActionResponse<string>("Same color for first and last cards");
            }
            if (cards.Last?.Value.Value - 1 == newCards.First?.Value.Value)
            {
                return new ActionResponse<string>("Incorrect order");
            }

            // dodajemy karty do nowej kolumny
            foreach (Card card in newCards)
            {
                cards.AddLast(card);
            }

            return new ActionResponse<string>("Cards were added");
        }
        /// <summary>
        /// Get some cards from column
        /// </summary>
        /// <param name="firstIndex"></param>
        /// <returns>Returns list and confirm message or null and deny message</returns>
        public ActionResponse<LinkedList<Card>> GetCards(int firstIndex)
        {

            if (firstIndex < knownCards)
            {
                return new ActionResponse<LinkedList<Card>>("trying to move incorect card");
            }

            LinkedList<Card> newCards = new LinkedList<Card>();
            for (int i = firstIndex; i < cards.Count; i++)
            {
                Card pulled = cards.ElementAt(i);
                cards.Remove(pulled);
                newCards.AddLast(pulled);
            }

            return new ActionResponse<LinkedList<Card>>(newCards, "Got cards");
        }
        public override string ToString()
        {
            string output = "| ";
            for (int i = 0; i < cards.Count; i++)
            {
                if (i < knownCards)
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