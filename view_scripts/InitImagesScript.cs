using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class InitImagesScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Field;
    public Image Coloda;
    void Start()
    {
        Field.sprite = Resources.Load<Sprite>("Sprites/UI/POKER");
        Coloda.sprite = Resources.Load<Sprite>("Sprites/UI/Coloda3");

        
    }
    
}
