using DefaultNamespace;
using UnityEngine;

namespace action_scripts
{
    public class OkMove : MonoBehaviour
    {
      
        private GameManagerScript _gameManagerScript;


        public void OkActionParse(Action action)
        {
            this._gameManagerScript = FindObjectOfType<GameManagerScript>();
            _gameManagerScript.CurrentGame.Field = action.field;
            _gameManagerScript.CurrentGame.Deck = action.anotherCards;
            _gameManagerScript.CurrentGame.TurningPlayerId = action.playerIdTurn;

            _gameManagerScript.GiveCardsToPlayersWithoutGivingIds(action.playersHand, action.field);
            _gameManagerScript.CheckTurn(action);
            
        }
    }
}