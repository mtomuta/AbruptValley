using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMenu : MonoBehaviour
{

    public Sprite closedChest;
    public Sprite openedChest;
    private Image image;

    public bool opened;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void OpenOrClose()
    {
        if (opened)
        {
            image.sprite = closedChest;
            opened = false;
        } 
        else
        {
            image.sprite = openedChest;
            opened = true;
        }
    }
}
