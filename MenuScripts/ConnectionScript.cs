using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MenuScripts
{
    public class ConnectionScript : MonoBehaviour
    {
        private const string BaseURL = "https://pback-spring.herokuapp.com";
        public int uid;
        public List<RoomInfo> rooms;
        public GameObject rowPref;
        public GameObject roomContainer;
        private static readonly HttpClient Client = new();

        public int? SelectedRoomId = null;
        public Image pressedRow;
        public bool isSubmitted = false;
    

        private async void Start()
        {
            DontDestroyOnLoad(this);
            try
            {
                await Register();
                UpdateRooms();
            }
            catch (HttpRequestException e)
            {
                WarningWindowScript.ShowMessage("Server is unavailable");
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private async void UpdateRooms()
        {
            while (!isSubmitted)
            {
                await GetListOfRooms();
                ShowRooms();
                await Task.Delay(2000);
            }
        }

        private void ShowRooms()
        {
            foreach (Transform child in roomContainer.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var room in rooms)
            {
                var row = Instantiate(rowPref, roomContainer.transform, false);
                row.transform.Find("Background").Find("Room name").GetComponent<TextMeshProUGUI>().text = room.name;
                row.transform.Find("Background").Find("Players count").GetComponent<TextMeshProUGUI>().text =
                    room.currentPeople + "/" + room.maxPeople;
                row.transform.Find("Background").Find("Id").GetComponent<Text>().text = room.id + "";
            }
        }

        private async Task Register()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            var streamTask = Client.GetStringAsync(BaseURL + "/connection/register");
            await streamTask;
            var registration = JsonUtility.FromJson<Repo>(streamTask.Result);
            Debug.Log("Got ID: " + registration.id);
            uid = registration.id;
        }


        private async Task GetListOfRooms()
        {
            var streamTask = Client.GetStringAsync(BaseURL + "/connection/room_list");
            await streamTask;
            Debug.Log(streamTask.Result);
            var list = JsonConvert.DeserializeObject<List<RoomInfo>>(streamTask.Result);
            this.rooms = list;
        }

        public RoomInfo GetRoomById(int id)
        {
            foreach (var room in rooms)
            {
                if (room.id == id) return room;
            }

            return null;
        }

        public bool EnterRoom(int roomId)
        {
            var resp = Client.GetAsync(BaseURL + "/connection/enter_room/" + "?id=" + uid + "&roomId=" + roomId);
            resp.Wait(1000);
            if ((int)resp.Result.StatusCode < 300) return true;
            else return false;
        }

        public bool CreateRoom(String name, int maxPlayerNumber)
        {
            var resp = Client.GetAsync(BaseURL + "/connection/create_room/" + "?name=" + name + "&maxPlayerNumber=" +
                                       maxPlayerNumber + "&playerId=" + uid);
            resp.Wait(1000);
            if ((int)resp.Result.StatusCode < 300) return true;
            else return false;
        }


        [Serializable]
        public class Repo
        {
            [SerializeField] public int id;
        }

        [Serializable]
        public class RoomInfo
        {
            [SerializeField] public int maxPeople;
            [SerializeField] public int currentPeople;
            [SerializeField] public String name;
            [SerializeField] public int id;
        }
    }
}