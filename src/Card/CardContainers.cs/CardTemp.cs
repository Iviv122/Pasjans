
using System.Dynamic;

namespace Pasjans
{
    /// <summary>
    /// Place where we temporarly contain our cards
    /// </summary>
    public class CardTemp
    {
        LinkedList<Card> cards;

        // for render purposes
        public LinkedList<Card> Cards
        {
            get
            {
                return cards;
            }
        }

        public CardTemp()
        {
            cards = new();
        }

        public void Add(LinkedList<Card>? nCards)
        {
            if (nCards == null ||nCards.Count == 0) {
                return;
            }
            cards = nCards;
        }
        public LinkedList<Card> Take()
        {
            LinkedList<Card> taken = cards;
            cards = new();
            return taken;
        }
        public LinkedList<Card> Peek()
        {
            return cards;
        }
        public bool isEmpty()
        {
            if (cards == null)
            {
                return true;
            }
            else
            {
                return cards.Count == 0;
            }
        }
    }
}