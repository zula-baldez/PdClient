using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuScripts
{
    public class SceneChanger : MonoBehaviour
    {
        public async void NextLevel(int sceneNumber)
        {
            ConnectionScript connectionScript = FindObjectOfType<ConnectionScript>();
            if (connectionScript.SelectedRoomId != null)
            {
                ConnectionScript.RoomInfo roomInfo = connectionScript.GetRoomById((int) connectionScript.SelectedRoomId);
                if (roomInfo != null && roomInfo.maxPeople > roomInfo.currentPeople)
                {
                    if(connectionScript.SelectedRoomId != null && connectionScript.EnterRoom((int) connectionScript.SelectedRoomId));
                    connectionScript.isSubmitted = true;
                    SceneManager.LoadScene(sceneNumber);
                
                }
                else
                {
                    WarningWindowScript.ShowMessage("Невозможно зайти в комнату!");
                }
            }
            else
            {
                WarningWindowScript.ShowMessage("Невозможно зайти в комнату!");
            }
        
        
        
        }
    }
}

