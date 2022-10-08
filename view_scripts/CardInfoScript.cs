using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using Unity.VisualScripting;

public class CardInfoScript : MonoBehaviour
{
    private Card _selfCard;
    public Image logo;
    public TextMeshProUGUI id;
    private GameManagerScript _gameManagerScript;

    public void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManagerScript>();
    }
    public void HideCardInfo(Card card)
    {
        _selfCard = card;
        logo.sprite = Resources.Load<Sprite>("Sprites/Cards/Rubashka");
        id.text = card.id.ToString();
    }

public void ShowCardInfo(Card card)
    {
        _selfCard = card;
        logo.sprite = card.Logo;
        logo.preserveAspect = true;
        id.text = card.id.ToString();
    }


}
