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
        
        SettLevel();
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown(KeyCode.P)) {
            //levelNum++;
            SceneManager.LoadScene("Main");
        }*/
	}

    private void SettLevel() {
        
        levelNum = 0;
        

        for (int i = 0; i < 3; i++) {
            string fileName = fileNames[levelNum];
            string filePath = Application.dataPath + "/" + fileName;
            StreamReader sr = new StreamReader(filePath);
            int yPos = 0;
            while (!sr.EndOfStream) {
                string line = sr.ReadLine();

                for (int xPos = 0; xPos < line.Length; xPos++) {
                    if (line[xPos] == 'x') {
                        GameObject _wall = Instantiate(Resources.Load("Prefabs/Wall") as GameObject);
                        _wall.transform.position = new Vector3(xPos + offSetX, i + 0.5f, yPos + offSetY);
                    } else if (line[xPos] == 't' && i == 0) {
                        GameObject _target = Instantiate(Resources.Load("Prefabs/Target") as GameObject);
                        Rigidbody _targetRig = _target.GetComponent<Rigidbody>();
                        
                        _target.transform.position = new Vector3(xPos + offSetX, 0.5f, yPos + offSetY);
                    }
                }

                yPos--;

            }
            sr.Close();
        }
    }
}
