using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
   //actually only adds Sprite to card info from server
    public class Action
    {
        public Action(ActionInfo actionInfo)
        {
            if (actionInfo.field != null)
                foreach (CardInfo cardInfo in actionInfo.field)
                {
                    Card card = CardManagerScript.GetCardById(cardInfo.id);
                    card.isPenek = cardInfo.isPenek;
                    field.Add(card);
                }

            if (actionInfo.playersHand != null)
                foreach (var i in actionInfo.playersHand)
                {
                    List<CardInfo> cardInfos = i.Value;
                    List<Card> cards = new List<Card>();
                    foreach (CardInfo cardInfo in cardInfos)
                    {
                        Card card = CardManagerScript.GetCardById(cardInfo.id);
                        card.isPenek = cardInfo.isPenek;
                        cards.Add(card);
                    }

                    playersHand[i.Key] = cards;
                }

            if (actionInfo.anotherCards != null)

                foreach (CardInfo cardInfo in actionInfo.anotherCards)
                {
                    Card card = CardManagerScript.GetCardById(cardInfo.id);
                    card.isPenek = cardInfo.isPenek;
                    anotherCards.Add(card); 
                }

            this.actionTypes = actionInfo.actionTypes;
            this.playerIdTurn = actionInfo.playerIdTurn;
            this.kozir = actionInfo.kozir;
        }

        public ActionTypes actionTypes;
        public Dictionary<int, List<Card>> playersHand = new Dictionary<int, List<Card>>();
        public List<Card> field = new List<Card>();
        public List<Card> anotherCards = new List<Card>();
        public int playerIdTurn;
        public Suit kozir;
    }


}