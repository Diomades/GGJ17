using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour {
    public GameUI gameUI;
    public GameTextDocs gameText;

    public void CheckFileExists()
    {
        if (File.Exists("unity_jambot18_ai"))
        {
            if (File.Exists("WHY.txt"))
            {
                Debug.Log("The player chose to keep the AI alive.");
                gameUI.ShowWarning("MAKEITSTOPMAKEITSTOPMAKEITSTOP", "MAKEITSTOPMAKEITSTOPMAKE", "ITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOP", "DELETE ME");
                StartCoroutine(DelayedError(6.0f));
            }
            else
            {
                Debug.Log("The AI is still alive.");
            }
            return;
        }
        else
        {
            gameUI.ShowWarning("", "Catastrophic Failure", "The game's connection to Jambot18 has been severed.", "");
            StartCoroutine(DelayedError(6.0f));
        }
    }

    public void QuitGoodEnding()
    {
        gameUI.ShowWarning("", "Catastrophic Failure", "The game's connection to Jambot18 has been severed.", "");
        StartCoroutine(DelayedQuit(5.0f));
    }

    public void QuitBadEnding()
    {
        gameUI.ShowWarning("WHY", "WHY", "MAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITMAKEITSTOPMAKEITSTOPMAKEITSTOP", "DELETE ME");
        StartCoroutine(DelayedQuit(6.0f));
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
        gameUI.EnableGameCanvas(false); //Disable the gameplay canvas
        gameUI.EnableMenuCanvas(false); //Disable the game menu

        yield return new WaitForSeconds(t);

        Debug.Log("The game has quit");
        QuitGame();
    }

    public IEnumerator DelayedError(float t)
    {
        gameUI.EnableGameCanvas(false); //Disable the gameplay canvas
        gameUI.EnableMenuCanvas(false); //Disable the game menu

        yield return new WaitForSeconds(t);

        Debug.Log("The game has suffered an error");
        gameUI.EnableMenuCanvas(true); //Enable the game menu
        gameUI.EnableGameCanvas(true); //Enable the gameplay canvas
        gameUI.ShowRestart(); //Show the RestartUI
    }

    public void RestoreGame()
    {
        gameText.ResetGameState();
        QuitGame();
    }
}
