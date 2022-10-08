using System;
using Unity.VisualScripting;
using UnityEngine;
using Action = DefaultNamespace.Action;

namespace action_scripts
{
    //it is monobehavior just for finding game manager script
    public class StartGame : MonoBehaviour
    {
        private GameManagerScript _gameManagerScript;


        public void GiveCards(Action action)
        {
            this._gameManagerScript = FindObjectOfType<GameManagerScript>();
            _gameManagerScript.CurrentGame.Field = action.field;
            _gameManagerScript.CurrentGame.Deck = action.anotherCards;
            _gameManagerScript.CurrentGame.TurningPlayerId = action.playerIdTurn;
            _gameManagerScript.InitPlayer(_gameManagerScript.mainPlayerId, action.playersHand.Count);
            _gameManagerScript.GiveCardsToPlayers(action.playersHand, action.field);
            _gameManagerScript.CheckTurn(action);

        }
    }
}