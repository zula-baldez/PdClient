using System;
using System.Net.Http;
using System.Threading;
using DefaultNamespace;
using MenuScripts;
using Newtonsoft.Json;
using UnityEngine;
using Action = DefaultNamespace.Action;

public enum ActionTypes
{
    CHANGE_TURN,
    BAD_MOVE,
    OK_MOVE,
    START_PLAY,
    START_GAME
}



public class LongPollingHandler : MonoBehaviour
{
    private bool isEnd = false;
    private const string BaseURL = "https://pback-spring.herokuapp.com";
    private ConnectionScript _connectionScript;
    private GameManagerScript _gameManagerScript;

    private async void Start()
    {
        _connectionScript = FindObjectOfType<ConnectionScript>();
        _gameManagerScript = FindObjectOfType<GameManagerScript>();
        CheckForChanges();
    }

    private async void CheckForChanges()
    {
        try
        {
            if (isEnd) return;
            print(_connectionScript.uid);
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);

                var request = new HttpRequestMessage(HttpMethod.Get, BaseURL + "/game/check_game_status?id=" +
                                                                     _connectionScript.uid + "&roomId=" +
                                                                     _connectionScript.SelectedRoomId);
                var response = await client.SendAsync(
                    request,
                    HttpCompletionOption.ResponseHeadersRead);
                var body = await response.Content.ReadAsStringAsync();
                Debug.Log(body);
                ActionInfo actionInfo = JsonConvert.DeserializeObject<ActionInfo>(body);
                Action action = new Action(actionInfo);
                _gameManagerScript.ParseAction(action);
            }

            CheckForChanges();
        }
        catch (Exception e)
        {
            CheckForChanges();
        }
    } 
}