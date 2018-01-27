using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public GameLogic gameLogic; //Storing a contactable version of GameLogic
    public GameLevels gameLevels; //Storing a contactable version of GameLevels

    private List<GameButton> _gameButtons = new List<GameButton>();
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

        Debug.Log("The selected answers are " + gameLogic.IsCorrect(answers));
        //gameLogic.IsCorrect(answers);
    }
}
