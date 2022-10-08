using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace view_scripts
{
    public class CardMovementScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Camera _mainCamera;
        private Vector3 _offset;
        public Transform defaultParent;
        private GameManagerScript _gameManager;
        public Card BufCard;
        public bool Dragable;
        public int playerIdCardTakenFrom;
        private void Awake()
        {
            _mainCamera = Camera.allCameras[1];
            _gameManager = FindObjectOfType<GameManagerScript>();
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            string id = transform.Find("id").GetComponent<TextMeshProUGUI>().text;
            BufCard = CardManagerScript.GetCardById(int.Parse(id));
            Debug.Log(BufCard.id);
            _gameManager.BufCard = this.BufCard;
            defaultParent = transform.parent;
            playerIdCardTakenFrom = int.Parse(defaultParent.Find("id").GetComponent<TextMeshProUGUI>().text);
            Dragable = _gameManager.CurrentGame.isPlayerTurn;
                     

            if (!Dragable)
            {
                return;
            }

            _offset = transform.position - _mainCamera.ScreenToWorldPoint(eventData.position);
            transform.SetParent(defaultParent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Dragable = _gameManager.CurrentGame.isPlayerTurn;

            if(!Dragable) return;
        
            Vector3 newPos = _mainCamera.ScreenToWorldPoint(eventData.position);
            newPos.z = 0;
            transform.position = newPos + _offset;
        }


        public void OnEndDrag(PointerEventData eventData)
        {
            Dragable = _gameManager.CurrentGame.isPlayerTurn;

            if(!Dragable) return;

            transform.SetParent(defaultParent);

            GetComponent<CanvasGroup>().blocksRaycasts = true;
            //validation вроде в DropPlayScript
        }
    }
}