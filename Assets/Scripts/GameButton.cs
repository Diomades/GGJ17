using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour {
    public Toggle thisButton;
    public GameObject thisButtonBG;
    public bool isActive = false;

    public void OnClick()
    {
        if (!isActive)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        Debug.Log(isActive);
    }

    public void ClearStatus()
    {
        isActive = false;
    }

    public void UpdateSprite(Sprite img)
    {
        Debug.Log(thisButtonBG);
        thisButtonBG.GetComponent<Image>().sprite = img;
        Debug.Log(thisButtonBG);
    }
}
