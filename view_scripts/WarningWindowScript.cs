
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarningWindowScript : MonoBehaviour
{
    private static WarningWindowScript _instance;
    public GameObject template;
    private Button _button;
    private TextMeshProUGUI _text;
    public Transform defaultParent;
    private void Awake()
    {
        _instance = this;

    }

    public static void ShowMessage(string message)
    {
        
        var window = Instantiate(_instance.template, _instance.defaultParent, true);
        _instance._button = window.transform.Find("OK_Button").GetComponent<Button>();
        _instance._button.transform.GetComponentInChildren<TextMeshProUGUI>().text = "Пойти нахуй";
        _instance._text = window.transform.Find("MessageText").GetComponent<TextMeshProUGUI>();
        _instance._text.text = message;
        window.transform.localPosition = new Vector3(0, 0, 0);
        window.transform.localScale = new Vector3(1, 1, 1);

        _instance._button.onClick.AddListener(() =>
        {
            Destroy(window);
        });
    }
    
    
    
    
}
