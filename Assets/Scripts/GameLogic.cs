using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    public GameLevels gameLevels;
    public GameUI gameUI;
    public GameTextDocs gameTextDocs;
    public GameSceneLoad gameSceneLoad;

    public int curStage = 0;
    public int curPuzzle = 0;
    public int totalPuzzles;
    private List<bool> _curSolutions = new List<bool>();

    void Start()
    {
        //Get everything set up
        gameLevels.Initialise();

        gameUI.Initialise();
        gameUI.UpdateButtons(curPuzzle);
        gameUI.UpdatePrompt(curPuzzle);

        gameTextDocs.Initialise();
        gameTextDocs.OutputDocument(curPuzzle);

        _curSolutions = gameLevels.CurrentStageAnswers(curPuzzle);
    }

    public void NextStage()
    {
        //Advance to the next level
        curPuzzle++;
        //Check if we are on the final level of the game
        if (curPuzzle == totalPuzzles)
        {
            gameSceneLoad.LoadScene("EndScene");
        }
        else
        {
            //Update the buttons appropriately
            gameUI.UpdateButtons(curPuzzle);
            gameUI.UpdatePrompt(curPuzzle);

            //Update the solutions
            _curSolutions = gameLevels.CurrentStageAnswers(curPuzzle);
        }        
    }

    //Check to see if there's an event on this puzzle
    public void CheckPuzzleEvent()
    {

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
