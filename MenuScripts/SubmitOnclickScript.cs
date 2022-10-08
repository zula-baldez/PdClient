using System;
using TMPro;
using UnityEngine;

namespace MenuScripts
{
    public class SubmitOnclickScript : MonoBehaviour
    {
        public GameObject enteringWindow;
        public TextMeshProUGUI nameInputText;
        public TextMeshProUGUI peopleMaxInputText;
        public new string name;
        public string peopleMax;


        public void SaveNameInput()
        {
            name = nameInputText.text;
        }
        public void SavePeopleMaxInput()
        {
            peopleMax = peopleMaxInputText.text;
        }
        public void OnClick()
        {
            var connector = FindObjectOfType<ConnectionScript>();
            int maxPeople;
            try
            {
                maxPeople = int.Parse(peopleMax.Substring(0, peopleMax.Length -1));
            }
            catch (FormatException e)
            {
                Destroy(enteringWindow);
                WarningWindowScript.ShowMessage("Failed to create the room");
                return;
            }

            if (connector.CreateRoom(name, maxPeople))
            {
                Destroy(enteringWindow);
            }
            else
            {
                Destroy(enteringWindow);
                WarningWindowScript.ShowMessage("Failed to create the room");
            }
        }
    }
}