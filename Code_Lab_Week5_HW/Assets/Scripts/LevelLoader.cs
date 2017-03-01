using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public float offSetX = 0;
    public float offSetY = 0;

    public string[] fileNames;
    public static int levelNum;

    public static bool isLevelSet = false;

    public static GameObject _levelHolder;

    // Use this for initialization
    void Start () {
        _levelHolder = new GameObject("Level Holder");
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown(KeyCode.P)) {
            //levelNum++;
            SceneManager.LoadScene("Main");
        }*/

        if (isLevelSet == false) {
            SettLevel();
            isLevelSet = true;
        }
	}

    private void SettLevel() {
        levelNum = Random.Range(0, 5);
        string fileName = fileNames[levelNum];
        string filePath = Application.dataPath + "/" + fileName;
        StreamReader sr = new StreamReader(filePath);
        int yPos = 0;

        while (!sr.EndOfStream) {
            string line = sr.ReadLine();

            for (int xPos = 0; xPos < line.Length; xPos++) {
                if (line[xPos] == 'x') {
                    GameObject _balloon = Instantiate(Resources.Load("Prefabs/Balloon") as GameObject);
                    Rigidbody _balloonRig = _balloon.GetComponent<Rigidbody>();
                    _balloonRig.AddForce(new Vector3(Random.Range(-2, 2), Random.Range(10, 16), Random.Range(-2, 2)), ForceMode.Impulse);
                    _balloonRig.AddTorque(new Vector3(Random.Range(-2, 2), Random.Range(3, 5), Random.Range(-2, 2)), ForceMode.Impulse);
                    _balloon.transform.parent = _levelHolder.transform;

                    _balloon.transform.position = new Vector3(xPos + offSetX, 0.5f, yPos + offSetY);
                } else if (line[xPos] == 'p') {
                    GameObject _target = Instantiate(Resources.Load("Prefabs/Target") as GameObject);
                    Rigidbody _targetRig = _target.GetComponent<Rigidbody>();
                    _targetRig.AddForce(new Vector3(Random.Range(-2, 2), Random.Range(10, 16), Random.Range(-2, 2)), ForceMode.Impulse);
                    _targetRig.AddTorque(new Vector3(Random.Range(-2, 2), Random.Range(3, 5), Random.Range(-2, 2)), ForceMode.Impulse);
                    _target.transform.parent = _levelHolder.transform;
                    _target.transform.position = new Vector3(xPos + offSetX, 0.5f, yPos + offSetY);
                }
            }

            yPos--;

        }
        sr.Close();
    }
}
