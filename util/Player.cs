using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Player
    {
        public string Name;
        public List<Card> playerHand;
        public int HuevieAmount = 0;
        public Transform Hand;
        public bool IsEnemy = true;
        public int AmountOfPenki = 2;
        public bool HasCardFromDeck = false;
        public Card BufCard;
        public int id;
    }

}