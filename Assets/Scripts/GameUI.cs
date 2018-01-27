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

        UpdateButtons();
        UpdatePrompt();
    }

    public void UpdateButtons()
    {
        List<Sprite> images = gameLevels.CurrentStageImages(gameLogic.curLevel); //Store the current set of images

        for(int i = 0; i < _gameButtons.Count; i++)
        {
            Debug.Log("Updating " + _gameButtons[i] + " with " + images[i]);
            _gameButtons[i].UpdateSprite(images[i]);
        }
    }

    public void UpdatePrompt()
    {
        promptText.text = gameLevels.CurrentStagePrompt(gameLogic.curLevel);
    }

	public void TestResults()
    {
        List<bool> answers = new List<bool>(); //Create a temp list with our answers
        foreach(GameButton b in _gameButtons)
        {
            answers.Add(b.isActive);
        }

        Debug.Log(gameLogic.IsCorrect(answers));
        //gameLogic.FakeCrash();
    }
}
