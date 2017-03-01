using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UtilScript.WriteStringToFile(Application.dataPath, "Hello.txt", "Hi");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
