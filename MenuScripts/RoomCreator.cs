using UnityEngine;

namespace MenuScripts
{
    public class RoomCreator : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject template;

        public Transform defaultParent;

        public void CreateRoom()
        {
            var window = Instantiate(template, defaultParent, true);
        }
    }
}
