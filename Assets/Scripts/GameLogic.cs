using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    public GameLevels gameLevels;
    public GameUI gameUI;
    public GameTextDocs gameTextDocs;

    public int curLevel = 0;
    private List<bool> _curSolutions = new List<bool>();

    void Start()
    {
        //Get everything set up
        gameLevels.Initialise();

        gameUI.Initialise();
        gameUI.UpdateButtons(curLevel);
        gameUI.UpdatePrompt(curLevel);

        gameTextDocs.Initialise();
        gameTextDocs.OutputDocument(curLevel);

        _curSolutions = gameLevels.CurrentStageAnswers(curLevel);
    }

    public void NextStage()
    {
        //Advance to the next level
        curLevel++;

        //Update the buttons appropriately
        gameUI.UpdateButtons(curLevel);
        gameUI.UpdatePrompt(curLevel);

        //Update the solutions
        _curSolutions = gameLevels.CurrentStageAnswers(curLevel);
    }

    public bool CheckAnswers(List<bool> c) //Tests *c*hoices against solutions
    {
        for(int i = 0; i < _curSolutions.Count; i++)
        {
            if (_curSolutions[i] != c[i])
            {
                //The answers are wrong. Notify the player.
                Debug.Log("The selected answers were INCORRECT");
                gameUI.Incorrect();
                return false;
            }
        }

        //At this point we've checked both lists and can confirm it's correct
        Debug.Log("The selected answers were CORRECT");
        NextStage();
        return true;
    }

    public void FakeCrash()
    {
        //Start of Crash
        StartCoroutine(Pause(3.0f));
    }

    private IEnumerator Pause(float p)
    {
        //During Crash
        yield return new WaitForSeconds(p);
        //End of "Crash"
        Debug.Log("CRASH");
        //Application.Quit();
    }
}
