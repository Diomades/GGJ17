using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    public GameMenu gameMenu;
    public GameLevels gameLevels;
    public GameUI gameUI;
    public GameSceneLoad gameSceneLoad;

    public int curPuzzle = 0;
    private List<bool> _curSolutions = new List<bool>();

    private int _timesIncorrect = 0;
    private int _hintThreshold = 3; //The time before we drop a 'hint'

    private int _cancelChoices = 0;

    public void Initialise()
    {
        //Get everything set up
        gameLevels.Initialise();

        gameUI.Initialise();
        gameUI.UpdateButtons(curPuzzle);
        gameUI.UpdatePrompt(curPuzzle);
        gameUI.UpdatePuzzleNumber(curPuzzle);

        _curSolutions = gameLevels.CurrentStageAnswers(curPuzzle);
    }

    public void NextStage()
    {
        //Advance to the next level
        curPuzzle++;
        //Update the buttons appropriately
        gameUI.UpdateButtons(curPuzzle);
        gameUI.UpdatePrompt(curPuzzle);
        gameUI.UpdatePuzzleNumber(curPuzzle);

        //Update the solutions
        _curSolutions = gameLevels.CurrentStageAnswers(curPuzzle);      
    }

    public void FinaleCheck()
    {
        gameLevels.CheckScene(curPuzzle);
    }

    //When we get to the final sections of the game (Level 18 + 19), we stop using NextStage and use NextFinaleEvent instead
    public void NextFinaleEvent()
    {
        curPuzzle++;
    }

    public bool CheckAnswers(List<bool> c) //Tests *c*hoices against solutions
    {
        for(int i = 0; i < _curSolutions.Count; i++)
        {
            if (_curSolutions[i] != c[i])
            {
                //The answers are wrong. Notify the player.
                Debug.Log("The selected answers were INCORRECT");
                _timesIncorrect++;
                if (_timesIncorrect == _hintThreshold)
                {
                    gameUI.ShowIncorrect(true);
                    _timesIncorrect = 0;
                }
                else
                {
                    gameUI.ShowIncorrect(false);
                }
                return false;
            }
        }

        //At this point we've checked both lists and can confirm it's correct
        Debug.Log("The selected answers were CORRECT");
        _timesIncorrect = 0; //Reset times incorrect if we need to
        //Trigger GameLevels to check if we need to do anything special for the next level
        gameLevels.CheckScene(curPuzzle);
        return true;
    }

    public void FinalChoice(bool delete)
    {
        if (delete)
        {
            gameUI.CloseMiscUI();
            gameLevels.EulogyEnding();
            //RUN ERROR AND CRASH HERE
        }
        else
        {
            _cancelChoices++;
            if (_cancelChoices == 1)
            {
                
            }
            else if (_cancelChoices == 2)
            {

            }
            else if (_cancelChoices == 3)
            {
                //Crash the game
            }
        }
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
