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
        gameLevels.Initialise();
        gameUI.Initialise();
        gameTextDocs.Initialise();
        gameTextDocs.OutputDocument(curLevel);

        _curSolutions = gameLevels.CurrentStageAnswers(curLevel);
        /*foreach(bool b in curSolutions)
        {
            Debug.Log(b);
        }*/
    }

    public bool IsCorrect(List<bool> c) //Tests *c*hoices against solutions
    {
        for(int i = 0; i < _curSolutions.Count; i++)
        {
            if (_curSolutions[i] != c[i])
            {
                return false;
            }
        }

        return true; //At this point we've checked both lists and can confirm it's correct
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
