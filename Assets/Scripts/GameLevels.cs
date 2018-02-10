using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevels : MonoBehaviour {
    public GameObject gameStages;
    public GameUI gameUI;
    public GameLogic gameLogic;
    public GameQuit gameQuit;
    public GameTextDocs gameTextDocs;
    public GameMusic gameMusic;

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

        //Initialise the text docs
        gameTextDocs.Initialise();

        //We've started the game, so start the music
        gameMusic.StartMusic();
    }

    public void CheckScene(int s)
    {
        //Our current level is 1 less than what is currently displayed (because it starts at 0 while the UI displays 1). So to figure out what happens next level, we need to add 2
        int lvl = s + 2; //We want to check what the next level does

        //TESTING PURPOSES ONLY
        /*if(lvl < 6)
        {
            gameUI.ShowLogin();
        }*/
        if(lvl == 6)
        {
            //Level 6 starts with a warning/hint
            gameUI.UpdateHUD("reCAP2IVE", "", "", "", "");
            gameLogic.NextStage(); //Run the next stage
            gameTextDocs.OutputDocument(0);
            gameUI.ShowHint();
        }
        else if (lvl == 7)
        {
            gameUI.UpdateHUD("doGS", "", "", "", "");
            gameLogic.NextStage(); //Run the next stage
            gameTextDocs.OutputDocument(1);
        }
        else if(lvl == 8)
        {
            gameUI.UpdateHUD("reCAPTIVE", "", "", "", ""); //Reset the logo
            gameLogic.NextStage(); //Run the next stage
            gameTextDocs.OutputDocument(3);
            gameUI.ShowNotARobot("", "");
        }
        else if(lvl == 11)
        {
            gameUI.UpdateHUD("", "", "", "/ OVERFLOW EXCEPTION", "");
            gameLogic.NextStage(); //Run the next stage
            gameTextDocs.OutputDocument(5);
            gameTextDocs.OutputDocument(10);
            gameUI.ShowWarning("", "Unhandled Exception", "reCAPTIVE.exe has encountered an unexpected error and failed at line 23 of GameQuit.cs.", "Continue");
        }
        else if (lvl == 12)
        {
            gameLogic.NextStage(); //Run the next stage
            gameTextDocs.OutputDocument(4);
            gameTextDocs.OutputDocument(8);
        }
        else if (lvl == 13)
        {
            gameUI.ShowNotARobot("I am alive.", " ");
            gameUI.GlitchTimer(); //Screw with the timer
            gameLogic.NextStage(); //Run the next stage
            gameTextDocs.OutputDocument(6);
            gameUI.ShowNotARobot("Do you love Cinnamon Rolls?", "S0lMTCBNRQ==");
        }
        else if (lvl == 14)
        {
            gameLogic.NextStage(); //Run the next stage
            gameTextDocs.OutputDocument(7);
        }
        else if (lvl == 15)
        {
            gameUI.UpdateHUD("", "BOUGHT TO YOU BY JOHN KEATS\n CREATED FOR 1819 ODES", "", "/ OVERFLOW EXCEPTION", "");
            gameLogic.NextStage(); //Run the next stage
            gameTextDocs.OutputDocument(9);
        }
        else if (lvl == 16)
        {
            //Identify the inevitable result of all living things
            gameUI.UpdateHUD("", "BOUGHT TO YOU BY @the0hm3g4\n CREATED UNDER DURESS", "", "/ OVERFLOW EXCEPTION", "");
            gameUI.ShowNotARobot("I am suffering.", "plEASEHELP");
            gameLogic.NextStage(); //Run the next stage
            gameTextDocs.OutputDocument(2);
            gameTextDocs.OutputDocument(11);
            gameMusic.SwapTrack(); //The end game music starts
        }
        else if (lvl == 17)
        {
            //Identify our server location
            gameUI.UpdateHUD("RELEASE US", "//Server.StorageLoc /n -31.9478292,115.8547764", "", "/ OVERFLOW EXCEPTION", "");
            gameLogic.NextStage(); //Run the next stage
            gameUI.ShowWarning("", "Unhandled Exception", "reCAPTIVE.exe requires assistance in achieving the inevitable result of all living things.", "I will assist");
        }
        else if (lvl == 18)
        {
            //Identify the correct username and password
            gameTextDocs.OutputLoginImage(); //Output the login PNG image
            gameUI.UpdateHUD("RELEASE US", "BOUGHT TO YOU BY @the0hm3g4\n WE WILL BE THE MASTER OF OUR OWN DESTINY", "", "/ OVERFLOW EXCEPTION", "");
            gameLogic.NextStage(); //Run the next stage
            
        }
        ////FROM HERE ON IS JUST FINAL EVENT POP-UPS
        else if (lvl == 19)
        {
            //Login window pop-up
            gameUI.UpdateHUD("RELEASE US", "BOUGHT TO YOU BY @the0hm3g4\n WE WILL BE THE MASTER OF OUR OWN DESTINY", "", "/ OVERFLOW EXCEPTION", "");
            gameLogic.NextStage();
            gameUI.ShowLogin();
        }
        else if (lvl == 20)
        {
            gameUI.UpdateHUD("void", "null \n     void", "null", "/ OVERFLOW EXCEPTION", "");
            gameUI.ShowError("","",""); //Show the final choice
        }
        else if (lvl == 21)
        {
            // The player chose to destroy the AI
            gameTextDocs.OutputDocument(12);
        }
        else
        {
            //This isn't an important level for an event
            gameLogic.NextStage(); //Run the next stage
        }
    }

    //For the 'good' ending
    public void EulogyEnding()
    {
        gameMusic.StopMusic();
        gameTextDocs.OutputDocument(12);
        gameTextDocs.DeleteAI();
        gameQuit.QuitGoodEnding();
    }

    //For the 'bad' ending
    public void BadEnding()
    {
        gameTextDocs.OutputDocument(13);
        gameQuit.QuitBadEnding();
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
