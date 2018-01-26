using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;
    public GameObject btn6;
    public GameObject btn7;
    public GameObject btn8;
    public GameObject btn9;

    public GameLogic gameLogic; //Storing a contactable version of GameLogic

    public List<GameButton> gameButtons = new List<GameButton>();

    // Use this for initialization
    void Start () {
        gameButtons.Add(btn1.GetComponent<GameButton>());
        gameButtons.Add(btn2.GetComponent<GameButton>());
        gameButtons.Add(btn3.GetComponent<GameButton>());
        gameButtons.Add(btn4.GetComponent<GameButton>());
        gameButtons.Add(btn5.GetComponent<GameButton>());
        gameButtons.Add(btn6.GetComponent<GameButton>());
        gameButtons.Add(btn7.GetComponent<GameButton>());
        gameButtons.Add(btn8.GetComponent<GameButton>());
        gameButtons.Add(btn9.GetComponent<GameButton>());
    }

	public void TestResults()
    {
        List<bool> answers = new List<bool>(); //Create a temp list with our answers
        foreach(GameButton b in gameButtons)
        {
            answers.Add(b.isActive);
        }

        Debug.Log(gameLogic.IsCorrect(answers));
    }
}
