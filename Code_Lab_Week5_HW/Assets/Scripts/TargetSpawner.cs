using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {
    public Transform Target;

    public static bool isTargetSpawned = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isTargetSpawned == false) {
            //Instantiate(Target, new Vector3(Random.Range(-13, 13), Random.Range(6.5f, 12), Random.Range(-13, 13)), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
            isTargetSpawned = true;
        }
	}
}
