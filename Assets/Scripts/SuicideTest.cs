using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SuicideTest : MonoBehaviour {

    /*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/

    private string _GameFolder = Application.dataPath;

    public void Suicide()
    {
        File.Delete(_GameFolder);
    }
}
