using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameTextDocs : MonoBehaviour {
    public TextAsset doc1;
    public TextAsset doc2;
    public TextAsset doc3;
    public TextAsset doc4;
    private List<TextAsset> _docTexts = new List<TextAsset>();

    public void Initialise()
    {
        _docTexts.Add(doc1);
    }

    public void OutputDocument(int num)
    {
        //Debug.Log(_docTexts[0].text);

        if (File.Exists(_docTexts[num].name + ".txt")) //Because we manually need to set the document extension
        {
            Debug.Log(_docTexts[num].name + ".txt" + " already exists.");
            return;
        }
        File.WriteAllText(_docTexts[num].name + ".txt", _docTexts[num].text);
    }
}