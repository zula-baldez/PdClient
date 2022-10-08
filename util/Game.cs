using System;
using System.Collections.Generic;
using DefaultNamespace;


public class Game
{
    public List<Card> Field;
    public Player MainPlayer;
    public Suit Kozir = Suit.PICK;
    public List<Player> Enemies = new List<Player>();
    public List<Card> Deck = new List<Card>();
    public bool isPlayerTurn = false;
    public Stage Stage = Stage.RAZDACHA;
    public int TurningPlayerId = -1;
}