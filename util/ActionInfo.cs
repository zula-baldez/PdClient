using System.Collections.Generic;

namespace DefaultNamespace
{
    public class ActionInfo
    {
        public ActionTypes actionTypes;
        public Dictionary<int, List<CardInfo>> playersHand;
        public List<CardInfo> field;
        public List<CardInfo> anotherCards;
        public int playerIdTurn;
        public Suit kozir;
    }
}