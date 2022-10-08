namespace DefaultNamespace
{
    public class CardInfo
    {
        public int id;
        public int attack;
        public bool isPenek;
        public Suit suit;
        public CardInfo(){}
        public CardInfo(Card card)
        {
            this.id = card.id;
            this.attack = card.Attack;
            this.isPenek = card.isPenek;
            this.suit = card.Suit;
        }
    }

}