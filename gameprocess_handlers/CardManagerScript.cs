using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public enum Suit
{
    KRESTI,
    BYBI,
    CHERVI,
    PICK
}




public static class CardManager
{
    public static readonly Dictionary<int, Card> AllCards= new Dictionary<int, Card>();
}

public class CardManagerScript : MonoBehaviour
{
    

    public static Card GetCardById(int id)
    {
        if (CardManager.AllCards.ContainsKey(id))
        {
            return CardManager.AllCards[id];
        }

        return null;
    }

    private void Awake()
    {
        CardManager.AllCards.Add(21, new Card(21, "Sprites/Cards/2_kresti", 2, 1));
        CardManager.AllCards.Add(22, new Card(22, "Sprites/Cards/2_bybi", 2, 2));
        CardManager.AllCards.Add(23, new Card(23, "Sprites/Cards/2_chervi", 2, 3));
        CardManager.AllCards.Add(24, new Card(24, "Sprites/Cards/2_pick", 2, 4));

        CardManager.AllCards.Add(31, new Card(31, "Sprites/Cards/3_kresti", 3, 1));
        CardManager.AllCards.Add(32, new Card(32, "Sprites/Cards/3_bybi", 3, 2));
        CardManager.AllCards.Add(33, new Card(33, "Sprites/Cards/3_chervi", 3, 3));
        CardManager.AllCards.Add(34, new Card(34, "Sprites/Cards/3_pick", 3, 4));

        CardManager.AllCards.Add(41, new Card(41, "Sprites/Cards/4_kresti", 4, 1));
        CardManager.AllCards.Add(42, new Card(42, "Sprites/Cards/4_bybi", 4, 2));
        CardManager.AllCards.Add(43, new Card(43, "Sprites/Cards/4_chervi", 4, 3));
        CardManager.AllCards.Add(44, new Card(44, "Sprites/Cards/4_pick", 4, 4));

        CardManager.AllCards.Add(51, new Card(51, "Sprites/Cards/5_kresti", 5, 1));
        CardManager.AllCards.Add(52, new Card(52, "Sprites/Cards/5_bybi", 5, 2));
        CardManager.AllCards.Add(53, new Card(53, "Sprites/Cards/5_chervi", 5, 3));
        CardManager.AllCards.Add(54, new Card(54, "Sprites/Cards/5_pick", 5, 4));

        CardManager.AllCards.Add(61, new Card(61, "Sprites/Cards/6_kresti", 6, 1));
        CardManager.AllCards.Add(62, new Card(62, "Sprites/Cards/6_bybi", 6, 2));
        CardManager.AllCards.Add(63, new Card(63, "Sprites/Cards/6_chervi", 6, 3));
        CardManager.AllCards.Add(64, new Card(64, "Sprites/Cards/6_pick", 6, 4));

        CardManager.AllCards.Add(71, new Card(71, "Sprites/Cards/7_kresti", 7, 1));
        CardManager.AllCards.Add(72, new Card(72, "Sprites/Cards/7_bybi", 7, 2));
        CardManager.AllCards.Add(73, new Card(73, "Sprites/Cards/7_chervi", 7, 3));
        CardManager.AllCards.Add(74, new Card(74, "Sprites/Cards/7_pick", 7, 4));

        CardManager.AllCards.Add(81, new Card(81, "Sprites/Cards/8_kresti", 8, 1));
        CardManager.AllCards.Add(82, new Card(82, "Sprites/Cards/8_bybi", 8, 2));
        CardManager.AllCards.Add(83, new Card(83, "Sprites/Cards/8_chervi", 8, 3));
        CardManager.AllCards.Add(84, new Card(84, "Sprites/Cards/8_pick", 8, 4));

        CardManager.AllCards.Add(91, new Card(91, "Sprites/Cards/9_kresti", 9, 1));
        CardManager.AllCards.Add(92, new Card(92, "Sprites/Cards/9_bybi", 9, 2));
        CardManager.AllCards.Add(93, new Card(93, "Sprites/Cards/9_chervi", 9, 3));
        CardManager.AllCards.Add(94, new Card(94, "Sprites/Cards/9_pick", 9, 4));
    
        CardManager.AllCards.Add(101, new Card(101, "Sprites/Cards/10_kresti", 10, 1));
        CardManager.AllCards.Add(102, new Card(102, "Sprites/Cards/10_bybi", 10, 2));
        CardManager.AllCards.Add(103, new Card(103, "Sprites/Cards/10_chervi", 10, 3));
        CardManager.AllCards.Add(104, new Card(104, "Sprites/Cards/10_pick", 10, 4));

        CardManager.AllCards.Add(111, new Card(111, "Sprites/Cards/11_kresti", 11, 1));
        CardManager.AllCards.Add(112, new Card(112, "Sprites/Cards/11_bybi", 11, 2));
        CardManager.AllCards.Add(113, new Card(113, "Sprites/Cards/11_chervi", 11, 3));
        CardManager.AllCards.Add(114, new Card(114, "Sprites/Cards/11_pick", 11, 4));

        CardManager.AllCards.Add(121,new Card(121, "Sprites/Cards/12_kresti", 12, 1));
        CardManager.AllCards.Add(122,new Card(122, "Sprites/Cards/12_bybi", 12, 2));
        CardManager.AllCards.Add(123, new Card(123, "Sprites/Cards/12_chervi", 12, 3));
        CardManager.AllCards.Add(124, new Card(124, "Sprites/Cards/12_pick", 12, 4));

        CardManager.AllCards.Add(131, new Card(131, "Sprites/Cards/13_kresti", 13, 1));
        CardManager.AllCards.Add(132, new Card(132, "Sprites/Cards/13_bybi", 13, 2));
        CardManager.AllCards.Add(133,new Card(133, "Sprites/Cards/13_chervi", 13, 3));
        CardManager.AllCards.Add(134, new Card(134, "Sprites/Cards/13_pick", 13, 4));

        CardManager.AllCards.Add(141, new Card(141, "Sprites/Cards/14_kresti", 14, 1));
        CardManager.AllCards.Add(142, new Card(142, "Sprites/Cards/14_bybi", 14, 2));
        CardManager.AllCards.Add(143, new Card(143, "Sprites/Cards/14_chervi", 14, 3));
        CardManager.AllCards.Add(144, new Card(144, "Sprites/Cards/14_pick", 14, 4));


       
    }
}