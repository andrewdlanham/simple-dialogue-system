using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    
    private Queue<string> sentenceQueue;

    [SerializeField] private Text dialogueText;
    [SerializeField] private GameObject dialogueTextBox;
    [SerializeField] private Player player;
    [SerializeField] private bool inDialogue;

    void Start() {
        inDialogue = false;
        sentenceQueue = new Queue<string>();
        player = FindObjectOfType<Player>();
    }

    void Update() {
        if (inDialogue) {
            if (Input.GetKeyDown("space")) {
                DisplayNextSentence();
            }
        }
    }

    public void HandleDialogue(Dialogue dialogue) {
        player.enabled = false;
        inDialogue = true;
        sentenceQueue.Clear();
        enqueueSentences(dialogue);
        DisplayNextSentence();

    }

    private void DisplayNextSentence() {
        if (sentenceQueue.Count == 0) {
            EndDialogue();
            return;
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentenceQueue.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue() {
        inDialogue = false;
        player.enabled = true;
    }

    private void enqueueSentences(Dialogue dialogue) {
        foreach (string sentence in dialogue.getSentenceArray()) {
            sentenceQueue.Enqueue(sentence);
        }
    }
    
}
