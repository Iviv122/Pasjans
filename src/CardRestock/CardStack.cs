namespace Pasjans
{
    // place where we take new cards on table
    class CardStack{
        Stack<Card> stack = new();
        public CardStack(List<Card> deckRest,int takeAmount){
            foreach (Card card in deckRest)
            {
               stack.Push(card); 
            }
        }

        public bool IsEmpty(){
            return stack.Count == 0;
        }
        public ActionResponse<Card> TakeCard(){
            if(!IsEmpty()){
                return new ActionResponse<Card>("Card heap is empty");
            }
            return new ActionResponse<Card>(stack.Pop(),"You took card"); 
        }
        public Card PeekCard()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot peek an empty heap.");
            }

            return stack.Peek();
        }
        public void AddCards(List<Card> cards){
            foreach (var item in cards)
            {
                this.stack.Push(item);
            }
        }
    }
}