using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
    //GAME MENU IS THE ACTUAL GAME START
    public GameObject menuCanvas;
    public GameObject gameCanvas;

    public GameObject gameMenu;
    public GameObject menuRobotUI;
    public Toggle menuRobotUIToggle;

    public GameLogic gameLogic;

    public GameQuit gameQuit;

	// Use this for initialization
	void Start () {
        gameQuit.CheckFileExists();
        //If the file exists, we'll be allowed to continue

        gameCanvas.SetActive(false);
        gameMenu.SetActive(true);
        menuRobotUI.SetActive(true);
	}

    public void StartGame()
    {
        menuRobotUIToggle.interactable = false;
        StartCoroutine(WaitForUI(3.0f));
    }

    public IEnumerator WaitForUI(float t)
    {
        yield return new WaitForSeconds(t);

        //Disable and enable UI's as necessary        
        gameCanvas.SetActive(true);
        gameMenu.SetActive(false);
        menuRobotUI.SetActive(false);
        //menuCanvas.SetActive(false);

        //Start the game
        gameLogic.Initialise();
    }
}
