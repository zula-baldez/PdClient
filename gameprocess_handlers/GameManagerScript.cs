using System;
using System.Collections;
using System.Collections.Generic;
using action_scripts;
using connection;
using DefaultNamespace;
using gameprocess_handlers;
using MenuScripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Action = DefaultNamespace.Action;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;


public class GameManagerScript : MonoBehaviour
{
    public TextMeshProUGUI turnTimeTxt;
    public Button endTurnButton;
    public Game CurrentGame;
    public Transform playerHand;
    public List<Transform> enemiesHands;
    public GameObject cardPref;
    public Transform field;
    public ConnectionScript _connectionScript;
    public Player MainPlayer;
    public int mainPlayerId;
    private GameRequestScript _gameRequestScript;
    public Transform scrollView;
    public Card BufCard;

    private void Start()
    {
        HideTurns();
        _gameRequestScript = FindObjectOfType<GameRequestScript>();
        WarningWindowScript.ShowMessage("Ожидание игроков");
        CurrentGame = new Game();
        ConnectionScript connectionScript = FindObjectOfType<ConnectionScript>();
        mainPlayerId = connectionScript.uid;
        
    }

    private void HideTurns()
    {
        foreach (var player in enemiesHands)
        {
            player.Find("turn").gameObject.SetActive(false);    
        }

       playerHand.parent.Find("turn").gameObject.SetActive(false);   
    }
       
    public void ParseAction(Action action)
    {
        Debug.Log("Parsing!");
        ActionHandler actionHandler = new ActionHandler();
        actionHandler.ParseAction(action);
        StopAllCoroutines();
        StartCoroutine(CountTurn());
    }


    public void InitPlayer(int mainPlayerId, int playerAmount)
    {
        Player mainPlayer = new Player
        {
            Hand = playerHand,
            IsEnemy = false,
            Name = "MainPlayer",
            id = mainPlayerId
        };
        CurrentGame.MainPlayer = mainPlayer;
        MainPlayer = mainPlayer;
        int j = 0;
        foreach (var t in enemiesHands)
        {
            j++;
            if (j > playerAmount - 1) break;
            var player = new Player
            {
                Hand = t,
                IsEnemy = true,
                HuevieAmount = 0,
                Name = t.name
            };

            CurrentGame.Enemies.Add(player);
        }
    }

    public void GiveCardsToPlayers(Dictionary<int, List<Card>> playersHand, List<Card> curField)
    {
        int iter = 0;
        
        foreach (var i in playersHand)
        {
            List<Card> cards = i.Value;
            Debug.Log(i.Value);
            if (i.Key == MainPlayer.id)
            {
                GiveCardsToHand(cards, MainPlayer);
                playerHand.GetComponentInChildren<TextMeshProUGUI>().text = mainPlayerId.ToString();
                scrollView.GetComponentInChildren<TextMeshProUGUI>().text = mainPlayerId.ToString();
                playerHand.parent.Find("back").GetComponentInChildren<TextMeshProUGUI>().text = mainPlayerId.ToString();
                playerHand.parent.Find("turn").GetComponentInChildren<TextMeshProUGUI>().text = mainPlayerId.ToString();

            }
            else
            {
                CurrentGame.Enemies[iter].id = i.Key;
                CurrentGame.Enemies[iter].Hand.GetComponentInChildren<TextMeshProUGUI>().text = i.Key.ToString();
                GiveCardsToHand(cards, CurrentGame.Enemies[iter]);
                iter++;
            }
        }

        GiveCardsToField(curField);
    }

    public void GiveCardsToPlayersWithoutGivingIds(Dictionary<int, List<Card>> playersHand, List<Card> curField)
    {
        ClearField();

        foreach (var player in CurrentGame.Enemies)
        {
            GiveCardsToHand(playersHand[player.id], player);
        }

        GiveCardsToHand(playersHand[mainPlayerId], MainPlayer);

        GiveCardsToField(curField);
    }

    private void ClearField()
    {
        foreach (var en in enemiesHands)
        {
            foreach (Transform child in en)
            {
                if (child.childCount != 0)
                    Destroy(child.gameObject);
            }
        }

        foreach (Transform child in field)
        {
            if (child.childCount != 0)
                Destroy(child.gameObject);
        }

        foreach (Transform child in playerHand)
        {
            if (child.childCount != 0)
                Destroy(child.gameObject);
        }
    }

    public void CheckTurn(Action action)
    {
        if (action.playerIdTurn == mainPlayerId)
        {
            Debug.Log("turning player: " + action.playerIdTurn);
            CurrentGame.isPlayerTurn = true;
        }
        else
        {
            CurrentGame.isPlayerTurn = false;
        }
    }

    private void GiveCardsToHand(List<Card> cards, Player player)
    {
        if (player == MainPlayer)
        {
            if (player.id == CurrentGame.TurningPlayerId)
            {
                player.Hand.parent.Find("turn").gameObject.SetActive(true);
            }
            else
            {
                player.Hand.parent.Find("turn").gameObject.SetActive(false);
            }
        }
        else
        {
            if (player.id == CurrentGame.TurningPlayerId)
            {
                player.Hand.Find("turn").gameObject.SetActive(true);
            }
            else
            {
                player.Hand.Find("turn").gameObject.SetActive(false);
            }
        }


        foreach (var card in cards)
        {
            GiveCardToHand(card, player);
        }
    }

    private void GiveCardsToField(List<Card> cards)
    {
        foreach (var card in cards)
        {
            GiveCardToField(card);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis

    private void GiveCardToHand(Card card, Player player)
    {
        Debug.Log(card.isPenek);
        var cardGo = Instantiate(cardPref, player.Hand, false);
        if (card.isPenek == false)
        {
            if (CurrentGame.Stage == Stage.PLAY && player != MainPlayer)
                cardGo.GetComponent<CardInfoScript>().HideCardInfo(card);
            else
                cardGo.GetComponent<CardInfoScript>().ShowCardInfo(card);
        }
        else
        {
            cardGo.GetComponent<CardInfoScript>().HideCardInfo(card);
        }

        cardGo.transform.localPosition = new Vector3(0, 0, 0);
        if (player != CurrentGame.MainPlayer)
            cardGo.transform.Rotate(0, 0, RandomAngle.GetRandom());
    }

    private void GiveCardToField(Card card)
    {
        CurrentGame.MainPlayer.BufCard = card;

        GameObject cardGo;
        cardGo = Instantiate(cardPref, this.field, false);
        cardGo.GetComponent<CardInfoScript>().ShowCardInfo(card);
        cardGo.transform.localPosition = new Vector3(0, 0, 0);
        cardGo.transform.Rotate(0, 0, RandomAngle.GetRandom());
    }

    private IEnumerator CountTurn()
    {
        int time = 30;
        while (time > 0)
        {
            turnTimeTxt.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }
    }

    public void LeaveRoom()
    {
        SceneManager.LoadScene(0);
    }
    public void GetCard()
    {
        if (CurrentGame.isPlayerTurn && CurrentGame.Deck.Count != 0 && CurrentGame.Stage == Stage.RAZDACHA)
        {
            _gameRequestScript.GetCardReq(mainPlayerId);
        }

        if (CurrentGame.isPlayerTurn && CurrentGame.Stage == Stage.PLAY)
        {
            Debug.Log("Take it!");
            _gameRequestScript.GetCardFromFieldReq(mainPlayerId);
        }
    }
}