using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UtilScript : MonoBehaviour {

	public static void WriteStringToFile(string path, string fileName, string content) {
        StreamWriter _sw = new StreamWriter(path + "/" + fileName);

        _sw.WriteLine(content);

        _sw.Close();

    }
}
