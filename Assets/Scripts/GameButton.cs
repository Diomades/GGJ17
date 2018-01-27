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
        isActive = thisButton.isOn;
        Debug.Log(this.name + " is now " + isActive);
    }

    public void ClearStatus()
    {
        thisButton.isOn = false;
        isActive = false;
    }

    public void UpdateSprite(Sprite img)
    {
        thisButtonBG.GetComponent<Image>().sprite = img;
    }
}
