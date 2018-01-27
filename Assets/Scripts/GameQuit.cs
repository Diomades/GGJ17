using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour {
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

        //StartCoroutine(Quit());
    }

    public static IEnumerator Quit()
    {
        yield return new WaitForEndOfFrame();
        Application.Quit();
    }
}
