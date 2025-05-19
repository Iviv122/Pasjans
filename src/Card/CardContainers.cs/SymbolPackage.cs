namespace Pasjans
{
    // Place where we collet our final cards
    public class SymbolPackage 
    {
        int nextValue = Card.MinValue;
        CardSymbol cardSymbol;
        public CardSymbol CardSymbol{
            get{ return cardSymbol;}
        }
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
        public int NextCardValue(){
            return nextValue;
        }
        public override string ToString()
        {
            if(nextValue == Card.MinValue){
                return "Empty:" + Card.SymbolToString(cardSymbol);
            }
            Card tmpCard = new Card(nextValue-1,cardSymbol);
            return tmpCard.ToString(); 
        }
    } 

}