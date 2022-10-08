using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using MenuScripts;
using Newtonsoft.Json;
using UnityEngine;
using view_scripts;
using Action = DefaultNamespace.Action;

namespace connection
{
    public class GameRequestScript : MonoBehaviour
    {
        private bool isEnd = false;
        private const string BaseURL = "https://pback-spring.herokuapp.com";
        private int roomId;
        private GameManagerScript _gameManagerScript;
        private CardMovementScript _cardMovementScript;
        private async void Start()
        {

            _gameManagerScript = FindObjectOfType<GameManagerScript>();
            roomId = (int)FindObjectOfType<ConnectionScript>().SelectedRoomId;
        }

        //if drop on the field id = -1
        public async void SendMoveActionRazdacha(int mainPlayerId, int dropPlayerId, int idFrom)
        {
            if (idFrom == dropPlayerId) return;
            
/**/            /*if (_gameManagerScript.BufCard.id != _gameManagerScript.MainPlayer.playerHand[^1].id)
            {
                WarningWindowScript.ShowMessage("Можно сбрасывать только последнюю карту!");
                return;
            }*/
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        //int roomId, int mainPlayerId, int playerFrom, int playerTo
                        { "roomId", roomId.ToString() },
                        { "mainPlayerId", mainPlayerId.ToString() },
                        { "playerFrom", idFrom.ToString() },
                        { "playerTo", dropPlayerId.ToString() },
                        { "card", _gameManagerScript.BufCard.id.ToString()}
                        
                    };

                    var content = JsonConvert.SerializeObject(values);
                    var data = new StringContent(content, Encoding.UTF8, "application/json");
                    Debug.Log(content);
                    var response = await httpClient.PostAsync(BaseURL + "/game/move_card_razd", data);

                    /*
                    var responseString = await response.Content.ReadAsStringAsync();
                    Debug.Log(responseString);
                    ActionInfo actionInfo = JsonConvert.DeserializeObject<ActionInfo>(responseString);
                    Action action = new Action(actionInfo);
                    _gameManagerScript.ParseAction(action);*/
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

            Debug.Log("Send request!!!");
        }

        public async void SendMoveActionPlay(int mainPlayerId, int dropPlayerId, int idFrom)
        {
            if (idFrom == dropPlayerId) return;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        //int roomId, int mainPlayerId, int playerFrom, int playerTo
                        { "roomId", roomId.ToString() },
                        { "mainPlayerId", mainPlayerId.ToString() },
                        { "playerFrom", idFrom.ToString() },
                        { "playerTo", dropPlayerId.ToString() },
                        { "card", _gameManagerScript.BufCard.id.ToString()}
                    };



                    var content = JsonConvert.SerializeObject(values);
                    var data = new StringContent(content, Encoding.UTF8, "application/json");
                    Debug.Log("MoveCardPlay " +  content);
                    var response = await httpClient.PostAsync(BaseURL + "/game/move_card_play", data);

                    /*
                    var responseString = await response.Content.ReadAsStringAsync();
                    Debug.Log(responseString);
                    ActionInfo actionInfo = JsonConvert.DeserializeObject<ActionInfo>(responseString);
                    Action action = new Action(actionInfo);
                    _gameManagerScript.ParseAction(action);*/
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

            Debug.Log("Send request!!!");
        }

        public async void GetCardReq(int mainPlayerId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        { "playerId", mainPlayerId.ToString() },
                        { "roomId", roomId.ToString() }
                    };
                    Debug.Log("playerId is" + mainPlayerId);
                    
                    Debug.Log("roomId is" + roomId);

                    var content = JsonConvert.SerializeObject(values);
                    var data = new StringContent(content, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(BaseURL + "/game/get_card", data);

                    var responseString = await response.Content.ReadAsStringAsync();
                    /*Debug.Log(responseString);
                    ActionInfo actionInfo = JsonConvert.DeserializeObject<ActionInfo>(responseString);
                    Action action = new Action(actionInfo);
                    _gameManagerScript.ParseAction(action);*/
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

            Debug.Log("Get Card!!!");
        }

        public async void GetCardFromFieldReq(int mainPlayerId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        { "playerId", mainPlayerId.ToString() },
                        { "roomId", roomId.ToString() }
                    };

                    var content = JsonConvert.SerializeObject(values);
                    var data = new StringContent(content, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(BaseURL + "/game/get_card_from_field", data);

                    var responseString = await response.Content.ReadAsStringAsync();
                    /*Debug.Log(responseString);
                    ActionInfo actionInfo = JsonConvert.DeserializeObject<ActionInfo>(responseString);
                    Action action = new Action(actionInfo);
                    _gameManagerScript.ParseAction(action);*/
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

            Debug.Log("Get Card From Field!!!");
        }
    }
}