using System;
using connection;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using view_scripts;
using Action = DefaultNamespace.Action;

public enum FieldType
{
    SelfHand,
    EnemyHand,
    Field
}

public class DropPlayScript : MonoBehaviour, IDropHandler
{
    public FieldType type;
    private GameManagerScript _gameManager;
    private GameRequestScript _gameRequestScript;

    public void Start()
    {
        _gameManager
            = FindObjectOfType<GameManagerScript>();
        _gameRequestScript = FindObjectOfType<GameRequestScript>();
    }

    //starts when drop the card on this area
    public void OnDrop(PointerEventData eventData)
    {
        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();
        if (!card.Dragable) return;
        int handId = int.Parse(gameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text);
        Debug.Log("Transfrom id: " + handId);
        if (_gameManager.CurrentGame.Stage == Stage.RAZDACHA)
            _gameRequestScript.SendMoveActionRazdacha(_gameManager.MainPlayer.id, handId, card.playerIdCardTakenFrom);
        else _gameRequestScript.SendMoveActionPlay(_gameManager.MainPlayer.id, handId, card.playerIdCardTakenFrom);


        // todo запрос на сервер, который вернет информацию о валидности хода
        /*
        if (type == FieldType.EnemyHand)
        {
            if (_gameManager.stage == Stage.Razdacha)
            {
                Player player = _gameManager.CurrentGame.GetPlayerByName(transform.name);
                ValidateRazdacha(_gameManager.CurrentGame.MainPlayer, player.PlayerHand[^1], CardMovementScript.BufCard,
                    FieldType.EnemyHand);
                player.PlayerHand.Add(CardMovementScript.BufCard);
            }
            else
            {
                WarningWindowScript.ShowMessage("ABOBA");
                _gameManager.CurrentGame.MainPlayer.HuevieAmount++;
            }
        }


        if (type == FieldType.SelfHand && _gameManager.stage == Stage.Razdacha)
        {
            ValidateRazdacha(_gameManager.CurrentGame.MainPlayer,
                _gameManager.CurrentGame.MainPlayer.PlayerHand[^1],
                CardMovementScript.BufCard, FieldType.SelfHand);
        }


        if (type == FieldType.Field && _gameManager.stage == Stage.Play)
        {
            if (_gameManager.CurrentGame.Field.Count != 0)
            {
                if (
                    ValidateMove(_gameManager.CurrentGame.MainPlayer,
                        _gameManager.CurrentGame.Field[^1],
                        CardMovementScript.BufCard,
                        Suit.KRESTI) == false) _gameManager.ChangeTurn();
            }

            _gameManager.CurrentGame.Field.Add(CardMovementScript.BufCard);
        }
        */

        /*if (!card) return;

        card.defaultParent = transform;
        card.transform.SetParent(transform);

        if (type != FieldType.SelfHand)
        {
            card.transform.Rotate(0, 0, RandomAngle.GetRandom());
            card.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            card.transform.rotation = Qutaernion.Euler(new Vector3(0, 0, card.transform.rotation.z));
            card.transform.SetPositionAndRotation(card.transform.position, card.transform.rotation);
        }*/
    }
}