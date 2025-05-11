namespace Pasjans
{
    // Place where we collet our final cards
    class SymbolPackage 
    {
        int nextValue = Card.MinValue;
        CardSymbol cardSymbol;
        public SymbolPackage(CardSymbol symbol){
            cardSymbol = symbol;
        }
        public ActionResponse<String> AddCard(Card card){
            if(cardSymbol != card.Symbol){
                return new ActionResponse<string>("Incorrect Symbol");
            }
            if(card.Value != nextValue){
                return new ActionResponse<string>("Incorrect place order");
            }
            nextValue+=1;
            return new ActionResponse<string>("Card was submitted");
        }

    } 

}