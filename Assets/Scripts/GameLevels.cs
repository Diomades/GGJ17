using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevels : MonoBehaviour {
    public List<bool> s1 = new List<bool>(new bool[] { true, false, false, true, false, false, true, false, false });

    public List<List<bool>> stages = new List<List<bool>>();

	//Called by Game Logic so that everything is added before we go
    public void Initialise()
    {
        stages.Add(s1);
    }

    public List<bool> CurrentStage(int s)
    {
        return stages[s];
    }
}
