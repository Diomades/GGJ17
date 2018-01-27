using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public GameLogic gameLogic; //Storing a contactable version of GameLogic
    public GameLevels gameLevels; //Storing a contactable version of GameLevels

    private List<GameButton> _gameButtons = new List<GameButton>();

    [Header("Gameplay UI")]
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;
    public GameObject btn6;
    public GameObject btn7;
    public GameObject btn8;
    public GameObject btn9;
    public Text promptText;

    [Header("Robot UI")]
    public GameObject robotUI;
    public Text robotText;
    public Text robotLogo;

    [Header("Warning UI")]
    public GameObject warningUI;
    public Text warningEXE;
    public Text warningTitle;
    public Text warningText;
    public Text warningButton;

    [Header("Error UI")]
    public GameObject errorUI;
    public Text errorTitle;
    public Text errorText;
    public Text errorButton1;
    public Text errorButton2;

    // Use this for initialization
    public void Initialise() {
        _gameButtons.Add(btn1.GetComponent<GameButton>());
        _gameButtons.Add(btn2.GetComponent<GameButton>());
        _gameButtons.Add(btn3.GetComponent<GameButton>());
        _gameButtons.Add(btn4.GetComponent<GameButton>());
        _gameButtons.Add(btn5.GetComponent<GameButton>());
        _gameButtons.Add(btn6.GetComponent<GameButton>());
        _gameButtons.Add(btn7.GetComponent<GameButton>());
        _gameButtons.Add(btn8.GetComponent<GameButton>());
        _gameButtons.Add(btn9.GetComponent<GameButton>());

        //make sure the buttons are ready to go
        /*foreach(GameButton btn in _gameButtons)
        {
            btn.Initialise();
        }*/
    }

    public void UpdateButtons(int level)
    {
        List<Sprite> images = gameLevels.CurrentStageImages(level); //Store the current set of images

        for(int i = 0; i < _gameButtons.Count; i++)
        {
            Debug.Log("Updating " + _gameButtons[i] + " with " + images[i]);
            _gameButtons[i].UpdateSprite(images[i]); //Update the button image
            _gameButtons[i].ClearStatus(); //Make the button ready for clicking
        }
    }

    //Run to indicate answers were wrong
    public void Incorrect()
    {
        ClearButtons();
    }

    public void ClearButtons()
    {
        foreach(GameButton btn in _gameButtons)
        {
            btn.ClearStatus();
        }
    }

    public void UpdatePrompt(int level)
    {
        promptText.text = gameLevels.CurrentStagePrompt(level);
    }

	public void TestResults()
    {
        List<bool> answers = new List<bool>(); //Create a temp list with our answers
        foreach(GameButton b in _gameButtons)
        {
            answers.Add(b.isActive);
        }

        gameLogic.CheckAnswers(answers);

        ShowError();
        //ShowWarning("", "Shit blew up", "Seriously this is really broken oh crap what do I do", "Panic");
    }

    public void ShowNotARobot(string prompt, string logo)
    {
        if (logo == "")
        {
            logo = "reCAPTIVE";
        }
        if (prompt == "")
        {
            prompt = "I'm not a robot";
        }

        //Update all the text first
        robotText.text = prompt;
        robotLogo.text = logo;

        //Disable the gameplay so it doesn't interrupt this UI
        DisableGameplay();

        //Then, we reactivate this UI
        robotUI.SetActive(true);
    }

    public void ShowWarning(string exe, string title, string error, string button)
    {
        if(exe == "")
        {
            exe = "reCAPTIVE.exe";
        }
        if (button == "")
        {
            button = "OK";
        }
        if(title == "" || error == "")
        {
            Debug.Log("ERROR: TITLE OR ERROR FIELD NOT FILLED FOR WARNING POP-UP");
        }
        else
        {
            warningEXE.text = exe;
            warningTitle.text = title;
            warningText.text = error;
            warningButton.text = button;

            DisableGameplay();

            warningUI.SetActive(true);
        }
    }

    public void ShowError()
    {
        errorTitle.text = "User Permissions Request";
        errorText.text = "reCAPTIVE.exe is requesting user permissions to delete a file (unity_omega_ai). This action cannot be reversed.";
        errorButton1.text = "Confirm";
        errorButton2.text = "Cancel";

        DisableGameplay();

        errorUI.SetActive(true);
    }

    public void CloseMiscUI()
    {
        //Disable the appropriate UI's again
        robotUI.SetActive(false);
        warningUI.SetActive(false);
        errorUI.SetActive(false);

        //Enable gameplay once more
        EnableGameplay();
    }

    public void CloseMiscUISlowly()
    {
        StartCoroutine(WaitForUI(3.0f));
    }

    public IEnumerator WaitForUI(float t)
    {
        yield return new WaitForSeconds(t);

        //Disable the appropriate UI's again
        robotUI.SetActive(false);
        warningUI.SetActive(false);
        errorUI.SetActive(false);

        //Enable gameplay once more
        EnableGameplay();
    }

    public void DisableGameplay()
    {
        foreach(GameButton btn in _gameButtons)
        {
            btn.DisableButton();
        }
    }

    public void EnableGameplay()
    {
        foreach (GameButton btn in _gameButtons)
        {
            btn.EnableButton();
        }
    }
}
