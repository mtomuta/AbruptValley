using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeButton : MonoBehaviour
{
    public void EnableOrDisableButton(int attributePoints)
    {
        if (attributePoints > 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
