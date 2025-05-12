
using System.ComponentModel;

namespace Pasjans
{

    // Podstawowa klasa karty ktorej uzyjemy wszedzie
    public class Card
    {
        // symbole kart
        public const char SpadeSymbol = '\u2660';
        public const char ClubSymbol = '\u2663';
        public const char HeartSymbol = '\u2665';
        public const char DiamondSymbol = '\u2666';

        public const int MinValue = 1;
        public const int MaxValue = 13;

        public int Value { get; private set; }
        public CardSymbol Symbol { get; private set; }
        public CardColor Color // otrzymac kolor na podstawie symbola
        {
            get
            {
                return Symbol switch
                {
                    CardSymbol.Clubs => CardColor.Black,
                    CardSymbol.Spades => CardColor.Black,
                    CardSymbol.Hearts => CardColor.Red,
                    CardSymbol.Diamonds => CardColor.Red,
                    _ => throw new InvalidEnumArgumentException()
                };
            }
        }

        public Card(int Value, CardSymbol Symbol)
        {
            this.Value = Value;
            // gwarancja ze karta potrzebnej wartosci
            if (Value < MinValue || Value > MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.Symbol = Symbol;
        }

        public static char SymbolToString(CardSymbol Symbol)
        {
            switch (Symbol)
            {
                case CardSymbol.Clubs:
                    return ClubSymbol;
                case CardSymbol.Diamonds:
                    return DiamondSymbol;
                case CardSymbol.Hearts:
                    return HeartSymbol;
                case CardSymbol.Spades:
                    return SpadeSymbol;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        // sposob wypisywanja karty
        public override string ToString()
        {
            string output = "";
            switch (Value)
            {
                case MinValue:
                    output += "A";
                    break;
                case MaxValue - 2:
                    output += "J";
                    break;
                case MaxValue - 1:
                    output += "Q";
                    break;
                case MaxValue:
                    output += "K";
                    break;
                default:
                    output += Value.ToString();
                    break;
            }
            switch (Symbol)
            {
                case CardSymbol.Clubs:
                    output += ClubSymbol;
                    break;
                case CardSymbol.Diamonds:
                    output += DiamondSymbol;
                    break;
                case CardSymbol.Hearts:
                    output += HeartSymbol;
                    break;
                case CardSymbol.Spades:
                    output += SpadeSymbol;
                    break;
            }
            return output;
        }
    }
}