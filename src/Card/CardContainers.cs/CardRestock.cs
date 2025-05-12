namespace Pasjans
{
    public class CardRestock
    {
        readonly List<Card> _currentCards;
        readonly  List<Card> _leftedCards = new();

        public CardRestock(List<Card> leftover)
        {
            _currentCards = leftover;
        }

        public ActionResponse<Card> PeekCardCurrent()
        {
            if(_currentCards.Count == 0){
                return new ActionResponse<Card>("No cards left in current pile");
            }
            return new ActionResponse<Card>(_currentCards[0],$"It is {_currentCards[0]}");
        }
        public ActionResponse<Card> PeekCardCurrent(int index)
        {
            if(_currentCards.Count-1 < index){
                return new ActionResponse<Card>("No cards in such index");
            }
            return new ActionResponse<Card>(_currentCards[index],$"It is {_currentCards[index]}");
        }
        public ActionResponse<Card> PeekCardLefted()
        {
            return new ActionResponse<Card>(_currentCards[0],"Peeked Card ");
        }
        public ActionResponse<Card> PeekCardLefted(int index)
        {
            if(_currentCards.Count-1 < index){
                return new ActionResponse<Card>("No cards in such index");
            }
            return new ActionResponse<Card>(_currentCards[index],$"It is {_currentCards[index]}");
        }
        public ActionResponse<Card> TakeCard()
        {
            if(_currentCards.Count == 0){
                return new ActionResponse<Card>("No cards to take");
            }
            Card taken = _currentCards[0];
            _currentCards.RemoveAt(0);
            return new ActionResponse<Card>(taken,$"Took {taken}");
        }
        public void ReturnCard(Card card)
        {
            _leftedCards.Add(card);
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