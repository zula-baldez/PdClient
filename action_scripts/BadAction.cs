using DefaultNamespace;
using UnityEngine;

namespace action_scripts
{
    public class BadAction : MonoBehaviour
    {
      
            private GameManagerScript _gameManagerScript;


            public void BadActionParse(Action action)
            {
                this._gameManagerScript = FindObjectOfType<GameManagerScript>();
                _gameManagerScript.CurrentGame.Field = action.field;
                _gameManagerScript.CurrentGame.Deck = action.anotherCards;
                _gameManagerScript.CurrentGame.TurningPlayerId = action.playerIdTurn;
                
                _gameManagerScript.GiveCardsToPlayersWithoutGivingIds(action.playersHand, action.field);
                _gameManagerScript.CheckTurn(action);

                WarningWindowScript.ShowMessage("Хуевая!");
            
            }
        }
    
}