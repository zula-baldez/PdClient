using UnityEngine;

namespace DefaultNamespace
{
    public class Card
    {
        public readonly int id;
        public readonly Sprite Logo;
        public int Attack;
        public Suit Suit;
        public bool isPenek = false;
        
        public Card(int id, string logoPath, int attack, int mast)
        {
            this.id = id;
            Logo = Resources.Load<Sprite>(logoPath);
            Attack = attack;
            if (mast == 1) Suit = Suit.KRESTI;
            if (mast == 2) Suit = Suit.BYBI;
            if (mast == 3) Suit = Suit.CHERVI;
            if (mast == 4) Suit = Suit.PICK;
            else Suit = Suit.KRESTI;
        }
    }
}