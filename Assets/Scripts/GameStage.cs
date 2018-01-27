using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : MonoBehaviour {
    private List<Sprite> _stageImages = new List<Sprite>();
    private List<bool> _stageSolutions = new List<bool>();

    public string prompt = "";

    [Header("Image 1")]
    public Sprite img01;
    public bool solve01 = false;

    [Header("Image 2")]
    public Sprite img02;
    public bool solve02 = false;

    [Header("Image 3")]
    public Sprite img03;
    public bool solve03 = false;

    [Header("Image 4")]
    public Sprite img04;
    public bool solve04 = false;

    [Header("Image 5")]
    public Sprite img05;
    public bool solve05 = false;

    [Header("Image 6")]
    public Sprite img06;
    public bool solve06 = false;

    [Header("Image 7")]
    public Sprite img07;
    public bool solve07 = false;

    [Header("Image 8")]
    public Sprite img08;
    public bool solve08 = false;

    [Header("Image 9")]
    public Sprite img09;
    public bool solve09 = false;

    public void Initialise()
    {
        //Set up the stage images
        _stageImages.Add(img01);
        _stageImages.Add(img02);
        _stageImages.Add(img03);
        _stageImages.Add(img04);
        _stageImages.Add(img05);
        _stageImages.Add(img06);
        _stageImages.Add(img07);
        _stageImages.Add(img08);
        _stageImages.Add(img09);

        //Set up the stage answers
        _stageSolutions.Add(solve01);
        _stageSolutions.Add(solve02);
        _stageSolutions.Add(solve03);
        _stageSolutions.Add(solve04);
        _stageSolutions.Add(solve05);
        _stageSolutions.Add(solve06);
        _stageSolutions.Add(solve07);
        _stageSolutions.Add(solve08);
        _stageSolutions.Add(solve09);
    }

    public bool ThisAnswer(int i)
    {
        return (_stageSolutions[i]);
    }

    public bool ThisImage(int i)
    {
        return (_stageImages[i]);
    }

    public List<bool> StageAnswers
    {
        get
        {
            return _stageSolutions;
        }
    }

    public List<Sprite> StageImages
    {
        get
        {
            return _stageImages;
        }
    }
}
