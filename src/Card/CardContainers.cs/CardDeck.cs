namespace Pasjans
{
    /// <summary>
    /// Simple Standart 52 cards deck no jockers cardpile
    /// </summary>
    public class CardDeck
    {
        private List<Card> cards;
        int currentCardIndex = 0;
        public CardDeck()
        {
            cards = new List<Card>();

            foreach (CardSymbol symbol in Enum.GetValues(typeof(CardSymbol)))
            {
                for (int value = 1; value <= Card.MaxValue; value++) //add all cards from min to max 
                {
                    cards.Add(new Card(value, symbol));
                }
            }
        }
        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
        }
        public override string ToString()
        {
            string output = "";
            foreach (var item in cards)
            {
                output += item.ToString();
            }
            return output;
        }
        public Card TakeCard()
        {
            if (currentCardIndex >= cards.Count){
                throw new InvalidOperationException("No more cards in the deck.");
            }

            return cards[currentCardIndex++];
        }
        public List<Card> TakeRemainingCards()
        {
            if (currentCardIndex >= cards.Count){
                return new List<Card>(); 
            }

            var remainingCards = cards.GetRange(currentCardIndex, cards.Count - currentCardIndex);
            currentCardIndex = cards.Count;
            return remainingCards;
        }
    }

}