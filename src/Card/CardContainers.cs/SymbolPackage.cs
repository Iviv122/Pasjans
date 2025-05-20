namespace Pasjans
{
    // Place where we collet our final cards
    public class SymbolPackage : IPut
    {
        int nextValue = Card.MinValue;
        CardSymbol cardSymbol;
        public CardSymbol CardSymbol
        {
            get { return cardSymbol; }
        }
        public SymbolPackage(CardSymbol symbol)
        {
            cardSymbol = symbol;
        }
        public SymbolPackage(CardSymbol symbol, int nextValue)
        {
            cardSymbol = symbol;
            this.nextValue = nextValue;
        }
        public SymbolPackage Clone()
        {
            return new SymbolPackage(cardSymbol,nextValue);
        }
        public void Put(LinkedList<Card> cards)
        {
            if (cards == null || cards.Count == 0 || cards.Count > 1)
            {
                return;
            }
            if (cardSymbol != cards.ElementAt(0).Symbol)
            {
                return;
            }
            if (cards.ElementAt(0).Value != nextValue)
            {
                return;
            }
            cards.Remove(cards.ElementAt(0));
            nextValue += 1;
        }
        public int NextCardValue()
        {
            return nextValue;
        }
        public int Value()
        {
            return nextValue - 1;
        }
        public override string ToString()
        {
            if (nextValue == Card.MinValue)
            {
                return "Empty:" + Card.SymbolToString(cardSymbol);
            }
            Card tmpCard = new Card(nextValue - 1, cardSymbol);
            return tmpCard.ToString();
        }
    }

}