using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public GameLogic gameLogic; //Storing a contactable version of GameLogic
    public GameLevels gameLevels; //Storing a contactable version of GameLevels

    private List<GameButton> _gameButtons = new List<GameButton>();

    private bool _needHint = false;

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

    [Header("HUD Elements")]
    public GameObject incorrectPopUp;
    public Text logoText;
    public Text creditsText;
    public Text submitButton;
    public Text puzzleNumber;
    private string _puzzleOutOf = " / 10";
    public Text timeNumber;
    public bool timerStart = false;
    private float _secondsCount;
    private int _minutesCount;
    private int _hoursCount;

    [Header("Robot UI")]
    public GameObject robotUI;
    public Toggle robotToggle;
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

    [Header("Login UI")]
    public GameObject loginUI;
    public Text loginText;
    public InputField loginUser;
    public InputField loginPass;
    private string _username = "ggj18perth";
    private string _password = "5ickne55";

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

        timerStart = true; //Start the Timer
    }

    private void Update()
    {
        if (timerStart)
        {
            UpdateTimer();
        }
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
    public void ShowIncorrect(bool hint)
    {
        _needHint = hint; //Displays a hint after the display of the Incorrect Pop-Up if necessary
        incorrectPopUp.SetActive(true);
        ClearButtons();
        DisableGameplay();
        StartCoroutine(WaitForUI(3.0f));
    }

    public void ShowHint()
    {
        ShowWarning("", "Unusual Behavior", "Sometimes reCAPTIVE mixes up images. Check the README file in the game folder if you run into any issues!", "");
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

    public void UpdateHUD(string logo, string credits, string submit, string puzzleNum, string timeNum)
    {
        if(logo != "")
        {
            logoText.text = logo;
        }
        if (credits != "")
        {
            creditsText.text = credits;
        }
        if (submit != "")
        {
            submitButton.text = submit;
        }
        if (puzzleNum != "")
        {
            _puzzleOutOf = puzzleNum;
        }
    }

    //We leave UpdatePuzzleNumber as a string so we can override it easily, manually
    public void UpdatePuzzleNumber(int num)
    {
        num++;
        puzzleNumber.text = num + _puzzleOutOf;
    }

    public void StartTimer()
    {
        timerStart = true;
    }

    public void StopTimer()
    {
        timerStart = false;
    }

    //Update the timer automatically
    public void UpdateTimer()
    {
        //For displaying 0's in a slot ahead of the digit
        string fsec = "";
        string fmin = "";
        string fhrs = "";

        _secondsCount += Time.deltaTime;
        float dt = Mathf.Round(_secondsCount);
        if (_secondsCount >= 60)
        {
            _minutesCount++;
            _secondsCount = 0;
        }
        else if (_minutesCount >= 60)
        {
            _hoursCount++;
            _minutesCount = 0;
        }

        //Check seconds for fsec
        if (dt < 10)
        {
            fsec = "0";
        }

        //Check minutes for fmin
        if (_minutesCount < 10)
        {
            fmin = "0";
        }

        //Check minutes for fmin
        if (_hoursCount < 10)
        {
            fhrs = "0";
        }

        timeNumber.text = fhrs + _hoursCount + ":" + fmin + _minutesCount + ":" + fsec+ dt;
    }

    public void GlitchTimer()
    {
        _hoursCount += 999999999;
    }

    public void TestResults()
    {
        List<bool> answers = new List<bool>(); //Create a temp list with our answers
        foreach(GameButton b in _gameButtons)
        {
            answers.Add(b.isActive);
        }

        gameLogic.CheckAnswers(answers);

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
        robotToggle.interactable = true; //Re-enable and set inactive the robot toggle
        robotToggle.isOn = false;
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

    public void ShowError(string text, string btn1, string btn2)
    {
        errorTitle.text = "User Permissions Request";
        if (text == "")
        {
            errorText.text = "reCAPTIVE.exe is requesting user permissions to delete a file (unity_omega_ai). This action cannot be reversed.";
        }
        else
        {
            errorText.text = text;
        }
        if (btn1 == "")
        {
            errorButton1.text = "Confirm";
        }
        else
        {
            errorButton1.text = btn1;
        }
        if (btn2 == "")
        {
            errorButton2.text = "Cancel";
        }
        else
        {
            errorButton2.text = btn2;
        }

        DisableGameplay();

        errorUI.SetActive(true);
    }

    public void ShowLogin()
    {
        DisableGameplay();

        loginUI.SetActive(true);
    }

    public void LoginSubmit()
    {
        if (loginUser.text == _username)
        {
            if (loginPass.text == _password)
            {
                Debug.Log("Successfully logged in!");
                CloseMiscUI();
                gameLogic.FinaleCheck();
            }
            else
            {
                //Debug.Log("Login failed!");
                LoginFailed();
            }
        }
        else
        {
            //Debug.Log("Login failed!");
            LoginFailed();
        }
    }

    public void LoginFailed()
    {
        loginText.text = "Incorrect username and/or password. Please try again.";
        loginPass.text = "";
        loginUser.text = "";
    }

    public void CloseMiscUI()
    {
        //Disable the appropriate UI's again
        robotUI.SetActive(false);
        warningUI.SetActive(false);
        errorUI.SetActive(false);
        loginUI.SetActive(false);

        //Enable gameplay once more
        EnableGameplay();
    }

    public void CloseMiscUISlowly()
    {
        robotToggle.interactable = false; //Just in case the RobotToggle was responsible for this
        StartCoroutine(WaitForUI(3.0f));
    }

    public IEnumerator WaitForUI(float t)
    {
        yield return new WaitForSeconds(t);

        //Disable the appropriate UI's again
        incorrectPopUp.SetActive(false);
        robotUI.SetActive(false);
        warningUI.SetActive(false);
        errorUI.SetActive(false);        

        //Enable gameplay once more
        EnableGameplay();

        //Show a hint if necessary
        if (_needHint)
        {
            _needHint = false;
            ShowHint();
        }
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
