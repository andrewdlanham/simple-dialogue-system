using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {
    

    [SerializeField] private string textFilePath;
    
    public string[] sentences;
    
    public void Awake() {
        ReadLinesIntoSentenceArray();
    }

    private void ReadLinesIntoSentenceArray() {
        sentences = System.IO.File.ReadAllLines(textFilePath);
    }

}