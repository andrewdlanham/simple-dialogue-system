using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {
    
    private GameObject dialogueBox;
    private TextMeshProUGUI dialogueBoxText;
    
    private bool isInDialogue;
    private bool isTyping;

    private Queue<string> sentenceQueue;

    void Awake() {
        isTyping = false;
        isInDialogue = false;
        sentenceQueue = new Queue<string>();
        dialogueBox = GameObject.Find("DialogueBox");
        dialogueBoxText = GameObject.Find("DialogueBoxText").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        if (isTyping) return;
        
        if (isInDialogue) {
            if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space)) {
                StopAllCoroutines();
                DisplayNextSentence();
            }
        }
    }

    private void DisplayNextSentence() {
        if (sentenceQueue.Count == 0) {
            EndDialogue();
            return;
        }
        StartCoroutine(TypeSentence(sentenceQueue.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence) {
        ClearDialogueText();
        isTyping = true;
        char[] sentenceLetters = sentence.ToCharArray();
        foreach (char letter in sentenceLetters) {
            dialogueBoxText.text += letter;
            yield return null;
        }
        isTyping = false;
    }

    // TODO: Add StopTypingSentence()

    public void StartDialogue(string[] dialogueSentences) {
        isInDialogue = true;
        sentenceQueue.Clear();
        EnqueueSentences(dialogueSentences);
        DisplayNextSentence();
    }

    private void EndDialogue() {
        isInDialogue = false;
    }


    private void EnqueueSentences(string[] sentences) {
        foreach (string sentence in sentences) {
            sentenceQueue.Enqueue(sentence);
        }
    }
    
    public void ShowDialogueBox() {
        dialogueBox.SetActive(true);
    }

    public void HideDialogueBox() {
        dialogueBox.SetActive(false);
    }

    private void ClearDialogueText() {
        dialogueBoxText.text = "";
    }
}