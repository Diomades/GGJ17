using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour {
    public GameUI gameUI;

    public void CheckFileExists()
    {
        if (File.Exists("unity_jambot18_ai"))
        {
            if (File.Exists("STOP.txt"))
            {
                Debug.Log("The player chose to keep the AI alive.");
                gameUI.ShowWarning("MAKEITSTOPMAKEITSTOPMAKEITSTOP", "MAKEITSTOPMAKEITSTOPMAKE", "ITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOP", "DELETE ME");
                StartCoroutine(DelayedQuit(6.0f));
            }
            else
            {
                Debug.Log("The AI is still alive.");
            }
            return;
        }
        else
        {
            QuitGame();
        }
    }

    public void QuitWithError()
    {
        gameUI.ShowWarning("", "Catastrophic Failure", "The game's connection to Jambot18 has been severed.", "");
        StartCoroutine(DelayedQuit(5.0f));
    }

    public void QuitGame()
    {
        if (!Application.isEditor)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        else
        {
            Debug.Log("The game has closed.");
        }
    }

    public IEnumerator DelayedQuit(float t)
    {
        yield return new WaitForSeconds(t);

        Debug.Log("The game has quit");
        QuitGame();
    }
}
