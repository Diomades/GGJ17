using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour {
    public string buttonID;
    public bool isActive = false;

	// Use this for initialization
	void Start () {
        buttonID = this.name;
	}

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
}
