using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {
    
    [SerializeField] private string characterName;
    [SerializeField] private string textFilePath;
    private string[] sentenceArray;
    

    public void Awake() {
        readLinesIntoSentenceArray();
    }

    public string[] getSentenceArray() {
        return this.sentenceArray;
    }

    private void readLinesIntoSentenceArray() {
        sentenceArray = System.IO.File.ReadAllLines(textFilePath);
    }

}
