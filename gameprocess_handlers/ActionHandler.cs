using System.Threading;
using action_scripts;
using DefaultNamespace;
using UnityEngine;

namespace gameprocess_handlers
{
    public class ActionHandler
    {
        private readonly StartGame _startGame = new StartGame();
        private BadAction _badAction = new BadAction();
        private OkMove _okMove = new OkMove();
        private StartPlay _startPlay = new StartPlay();
        public void ParseAction(Action action)
        {
            Debug.Log("Parsing!");

            if (action.actionTypes == ActionTypes.START_GAME)
            {
                Debug.Log("Start Game!");

                _startGame.GiveCards(action);
            }

            if (action.actionTypes == ActionTypes.BAD_MOVE)
            {
                Debug.Log("Bad Move!");
                _badAction.BadActionParse(action);
            }

            if (action.actionTypes == ActionTypes.OK_MOVE)
            {
                _okMove.OkActionParse(action);
            }

            if (action.actionTypes == ActionTypes.START_PLAY)
            { 
                _startPlay.StartPlayParse(action);

            }
            //...
        }
    }
}