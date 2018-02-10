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
    public Texture2D login;
    public TextAsset jambot;
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

    public void OutputLoginImage()
    {
        File.WriteAllBytes(login.name + ".png", login.EncodeToPNG());
    }

    public void DeleteAI()
    {
        if (File.Exists(jambot.name)) //Make sure the file exists first
        {
            File.Delete(jambot.name);
            Debug.Log("unity_jambot18_ai existed, and was deleted");
            return;
        }
    }

    public void ResetGameState()
    {
        _docTexts.Clear(); //Clear the list just in case
        Initialise(); //Because at this stage the files should not exist

        //Delete all the logs and other text documents
        foreach (TextAsset t in _docTexts)
        {
            if (File.Exists(t.name + ".txt")) //Because we manually need to set the document extension
            {
                Debug.Log(t.name + ".txt" + " already exists, deleting it");
                File.Delete(t.name + ".txt");
            }
        }

        //Delete the PNG file
        if (File.Exists(login.name + ".png"))
        {
            Debug.Log(login.name + ".png" + " already exists, deleting it");
            File.Delete(login.name + ".png");
        }

        //Restore the AI file
        if (File.Exists(jambot.name))
        {
            Debug.Log("Jambot already exists, taking no action");
        }
        else
        {
            Debug.Log("Jambot does not exist, restoring it");
            File.WriteAllBytes(jambot.name, jambot.bytes);
        }
    }
}