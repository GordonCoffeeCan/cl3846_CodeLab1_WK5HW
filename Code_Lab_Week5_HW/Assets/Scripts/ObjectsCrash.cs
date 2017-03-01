using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCrash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (LevelLoader._levelHolder.transform.childCount <= 0) {
            LevelLoader.isLevelSet = false;
        }
    }

    private void OnCollisionEnter(Collision _col) {
        if(_col.gameObject.tag == "Target") {
            Destroy(_col.gameObject);
        } else if(_col.gameObject.tag == "Balloon") {
            Destroy(_col.gameObject);
            GameObject _balloonParticle = Instantiate(Resources.Load("Prefabs/BalloonParticle") as GameObject);
            _balloonParticle.transform.position = _col.transform.position;
        }
    }
}
