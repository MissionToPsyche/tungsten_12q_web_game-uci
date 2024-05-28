using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class DialogueTrigger1 : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText; // Change type to TMP_Text
    public string[] dialogue;
    private int index = 0;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    private Coroutine typingCoroutine; // Store reference to the typing coroutine
    private bool isTyping = false; // Flag to indicate if typing is in progress

    void Start()
    {
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                StartTyping();
            }
            else if (isTyping)
            {
                CompleteTyping();
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }
        }
    }

    public void zeroText()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    private void StartTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(Typing());
    }

    private void CompleteTyping()
    {
        StopCoroutine(typingCoroutine);
        dialogueText.text = dialogue[index];
        isTyping = false;
    }

    IEnumerator Typing()
    {
        isTyping = true;
        dialogueText.text = ""; // Ensure text is cleared before starting
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter; // Use TextMeshPro's text manipulation methods
            yield return new WaitForSeconds(wordSpeed);
        }
        isTyping = false;
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            StartTyping();
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            dialoguePanel.SetActive(true);
            StartTyping();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
