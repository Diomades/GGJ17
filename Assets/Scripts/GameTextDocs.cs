using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameTextDocs : MonoBehaviour {
    public TextAsset doc00;
    public TextAsset doc01;
    public TextAsset doc02;
    public TextAsset doc03;
    public TextAsset doc04;
    public TextAsset doc05;
    public TextAsset doc06;
    public TextAsset doc07;
    public TextAsset doc08;
    public TextAsset doc09;
    public TextAsset doc10;
    public TextAsset doc11;
    public TextAsset eulogy;
    public TextAsset stop;
    private List<TextAsset> _docTexts = new List<TextAsset>();

    public void Initialise()
    {
        _docTexts.Add(doc00);
        _docTexts.Add(doc01);
        _docTexts.Add(doc02);
        _docTexts.Add(doc03);
        _docTexts.Add(doc04);
        _docTexts.Add(doc05);
        _docTexts.Add(doc06);
        _docTexts.Add(doc07);
        _docTexts.Add(doc08);
        _docTexts.Add(doc09);
        _docTexts.Add(doc10);
        _docTexts.Add(doc11);
        _docTexts.Add(eulogy); //12
        _docTexts.Add(stop); //13
    }

    public void OutputDocument(int num)
    {
        if (File.Exists(_docTexts[num].name + ".txt")) //Because we manually need to set the document extension
        {
            Debug.Log(_docTexts[num].name + ".txt" + " already exists.");
            return;
        }
        File.WriteAllText(_docTexts[num].name + ".txt", _docTexts[num].text);
    }

    public void DeleteAI()
    {
        if (File.Exists("unity_jambot18_ai")) //Make sure the file exists first
        {
            File.Delete("unity_jambot18_ai");
            Debug.Log("unity_jambot18_ai existed, and was deleted");
            return;
        }
    }
}