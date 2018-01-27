using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevels : MonoBehaviour {
    public GameObject gameStages;

    private List<List<bool>> _stages = new List<List<bool>>();
    private List<List<Sprite>> _images = new List<List<Sprite>>();
    private List<string> _prompts = new List<string>();

	//Called by Game Logic so that everything is added before we go
    public void Initialise()
    {
        //Start up all the level stages
        foreach(Transform child in gameStages.transform)
        {
            GameStage s = child.GetComponent<GameStage>();
            s.Initialise(); //Initialise sets up their lists so that we can use them
            _stages.Add(s.StageAnswers);
            _images.Add(s.StageImages);
            _prompts.Add(s.prompt);
        }
    }

    public List<bool> CurrentStageAnswers(int i) //Returns the answers for a given stage
    {
        return _stages[i];
    }

    public List<Sprite> CurrentStageImages(int i) //Returns the images for a given stage
    {
        return _images[i];
    }

    public string CurrentStagePrompt(int i)
    {
        return _prompts[i];
    }
}
