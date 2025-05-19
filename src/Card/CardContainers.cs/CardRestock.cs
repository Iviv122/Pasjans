namespace Pasjans
{
    public class CardRestock
    {
        readonly List<Card> _currentCards;
        readonly  LinkedList<Card> _leftedCards = new();

        public CardRestock(List<Card> leftover)
        {
            _currentCards = leftover;
        }

        public Card? PeekCardCurrent()
        {
            if (_currentCards.Count == 0)
            {
                return null;
            }
            return _currentCards[0];
        }
        public Card? PeekCardCurrent(int index)
        {
            if(_currentCards.Count-1 < index){
                return null;
            }
            return _currentCards[index];
        }
        public Card? PeekCardLefted()
        {
            if (_leftedCards.Count == 0) {
                return null;
            }
            return _leftedCards.ElementAt(0);
        }
        public Card? PeekCardLefted(int index)
        {
            if(index < 0 || index >= _leftedCards.Count){
                return null; 
            }
            return _leftedCards.ElementAt(index);
        }
        public void Next()
        {
            if (_currentCards.Count == 0)
            {
                return;
            }
            Card taken = _currentCards[0];
            _currentCards.RemoveAt(0);
            _leftedCards.AddFirst(taken);
        }
        public Card? TakeCard()
        {
            if (_leftedCards.Count == 0)
            {
                return null;
            }
            Card taken = _leftedCards.ElementAt(0);
            _leftedCards.RemoveFirst();
            return taken;
        }
        public void Shuffle()
        {
            // Move all cards from _leftedCards to _currentCards
            _currentCards.AddRange(_leftedCards);
            _leftedCards.Clear();

            // Shuffle _currentCards
            Random rng = new Random();
            int n = _currentCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card temp = _currentCards[k];
                _currentCards[k] = _currentCards[n];
                _currentCards[n] = temp;
            }
        }

        public override string ToString()
        {
            string output = "";
            foreach (var item in _currentCards)
            {
                output += item.ToString();
            }
            foreach (var item in _leftedCards)
            {
                output += item.ToString();
            }
            return output;
        }
    }
}