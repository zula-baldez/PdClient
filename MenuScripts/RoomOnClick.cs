using UnityEngine;
using UnityEngine.UI;
using static System.Int32;

namespace MenuScripts
{
    public class RoomOnClick : MonoBehaviour
    {
        public Image background;
        public Color colorIfPressed;
        public Color defaultColor;
        private ConnectionScript _connectionScript;

        private void Start()
        {
            _connectionScript = FindObjectOfType<ConnectionScript>();
        }

        public void OnMouseDown()
        {
            if (_connectionScript.pressedRow != null)
                _connectionScript.pressedRow.color = defaultColor;
            background.color = colorIfPressed;
            _connectionScript.pressedRow = background;
            Debug.Log(gameObject.name);
            _connectionScript.SelectedRoomId = Parse(gameObject.transform.GetComponentInChildren<Text>().text);
        }
        //Check for mouse click 
    }
}