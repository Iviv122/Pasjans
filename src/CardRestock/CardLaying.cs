namespace Pasjans
{
    // Place where we take new cards on table
    class CardLaying
    {
        private LinkedList<Card> stack = new();

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public ActionResponse<Card> TakeCard()
        {
            if (IsEmpty())
            {
                return new ActionResponse<Card>("Laying cards are empty");
            }

            Card card = stack.First.Value;
            stack.RemoveFirst();
            return new ActionResponse<Card>(card, "You took a card");
        }
        public void AddCard(Card card)
        {
            stack.AddFirst(card);
        }
        public Card PeekCard()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek an empty list.");
            }

            return stack.First.Value;
        }

        
    }
}
