using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameTextDocs : MonoBehaviour {
    public Text doc1;
    private List<string> _docNames = new List<string>(new string[] { "UnityMadeMe.txt", "LilImage.png" });

    private List<Text> _docTexts = new List<Text>();

    public void Initialise()
    {
        _docTexts.Add(doc1);
    }

    public void OutputDocument(int num)
    {
        //Debug.Log(_docTexts[0].text);

        if (File.Exists(_docNames[num]))
        {
            Debug.Log(_docNames[num] + " already exists.");
            return;
        }
        File.WriteAllText(_docNames[num], _docTexts[num].text);
    }
}
