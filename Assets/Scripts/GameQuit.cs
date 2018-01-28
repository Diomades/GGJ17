using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour {
    public void CheckFileExists()
    {
        if (File.Exists("unity_jambot18_ai"))
        {
            Debug.Log("The AI is still alive.");
            return;
        }
        else
        {
            QuitGame();
        }
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

    public static IEnumerator Quit()
    {
        yield return new WaitForEndOfFrame();
        Application.Quit();
    }
}
