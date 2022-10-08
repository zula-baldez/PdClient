using DefaultNamespace;
using UnityEngine;

namespace action_scripts
{
    public class StartPlay : MonoBehaviour
    {
      
        private GameManagerScript _gameManagerScript;


        public void StartPlayParse(Action action)
        {
            this._gameManagerScript = FindObjectOfType<GameManagerScript>();
            _gameManagerScript.CurrentGame.Field = action.field;
            _gameManagerScript.CurrentGame.Deck = action.anotherCards;
            _gameManagerScript.CurrentGame.TurningPlayerId = action.playerIdTurn;

            _gameManagerScript.GiveCardsToPlayersWithoutGivingIds(action.playersHand, action.field);
            _gameManagerScript.CheckTurn(action);
            _gameManagerScript.CurrentGame.Kozir = action.kozir;
            //todo show kozir
            _gameManagerScript.CurrentGame.Stage = Stage.PLAY;
            Debug.Log(_gameManagerScript.CurrentGame.Kozir);
            WarningWindowScript.ShowMessage("Начинается игра! Козырь - "+action.kozir);

            
        }
    }
}