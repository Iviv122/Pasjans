
namespace Pasjans
{
    public class CardRestock : ITake
    {
        readonly List<Card> _currentCards;
        readonly LinkedList<Card> _leftedCards = new();

        public CardRestock(List<Card> leftover)
        {
            _currentCards = leftover;
        }
        private CardRestock(List<Card> currentCards, LinkedList<Card> leftedCards)
        {

            _currentCards = new();
            foreach (var item in currentCards)
            {
                _currentCards.Add(item);
            }
            _leftedCards = new();
            foreach (var item in leftedCards)
            {
                _leftedCards.AddFirst(item);
            }
        }
        public CardRestock Clone()
        {
            return new CardRestock(_currentCards, _leftedCards);
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
            if (_currentCards.Count - 1 < index)
            {
                return null;
            }
            return _currentCards[index];
        }
        public Card? PeekCardLefted()
        {
            if (_leftedCards.Count == 0)
            {
                return null;
            }
            return _leftedCards.ElementAt(0);
        }
        public Card? PeekCardLefted(int index)
        {
            if (index < 0 || index >= _leftedCards.Count)
            {
                return null;
            }
            return _leftedCards.ElementAt(index);
        }
        public void Next()
        {
            if (_currentCards.Count == 0)
            {
                Shuffle();
                return;
            }
            Card taken = _currentCards[0];
            _currentCards.RemoveAt(0);
            _leftedCards.AddFirst(taken);
        }
        public LinkedList<Card>? Take(int index)
        {
            if (_leftedCards.Count == 0 || _leftedCards == null)
            {
                return null;
            }
            Card taken = _leftedCards.ElementAt(0);
            _leftedCards.RemoveFirst();
            LinkedList<Card> output = new();
            output.AddLast(taken);
            return output;
        }
        void Shuffle()
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