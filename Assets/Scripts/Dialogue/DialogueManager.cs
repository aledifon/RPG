using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    // Static field which contains the single instance of the Singleton
    private static DialogueManager dialogueManager;
    // Static property used to acces the Singleton
    public static DialogueManager DialgManager
    {
        get 
        { 
            if (dialogueManager == null)
            {
                dialogueManager = FindAnyObjectByType<DialogueManager>();
                if (dialogueManager == null)
                {
                    GameObject go = new GameObject("DialogueManager");
                    dialogueManager = go.AddComponent<DialogueManager>();
                }
            }
            return dialogueManager; 
        }
    }

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;     // Current line on course of the JSON document

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;  // Choices Buttons of the Dialogue Panel of the Canvas
    private TextMeshProUGUI[] choicesText;          // Choices Text

    private bool dialogueIsPlaying;
    private bool isFirstClick;

    #region Unity API
    void Awake()
    {
        if (dialogueManager == null)
            dialogueManager = this;
        else
            Destroy(gameObject);

        dialogueIsPlaying = false;
        isFirstClick = false;
        dialoguePanel.SetActive(false);

        InitializeArrays();
    }    
    void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        // Continue with the story, we'll manage which button
        // goes forward with the dialogue lines

        // With the mouse right button is deployed the next dialog line
        if (Input.GetButtonDown("Fire2"))
        {
            ContinueStory();
        }
    }
    #endregion

    #region Private Methods
    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel?.SetActive(false);
        dialogueText.text = "";
        isFirstClick = true;
    }    
    private void InitializeArrays()
    {
        // Init of Choices Text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void DisplayChoices()
    {
        // Checks if there is any '*' (any choices) in the current dialog Line of the JSON
        List<Choice> currentChoices = currentStory.currentChoices;

        // Set an error message in case there are no enough buttons on the GUI in order
        // to show all the different choices
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("There are more options than the limit admitted by the GUI." +
                "Num: " + currentChoices.Count);
        }

        // Let's set all the buttons as disabled by default.
        foreach (GameObject choice in choices)
            choice.SetActive(false);
        int index = 0;

        // Enable all the choices on the GUI (Buttons & Texts) and set their values
        // with the ones took from the current Story
        foreach (Choice choice in currentChoices)
        {
            choices[index].SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
    }
    #endregion

    #region
    public void EnterDialogMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
    }
    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // Deploy the next dialogue line
            dialogueText.text = currentStory.Continue();
            // Deploy the buttons with their different choices (if they exist)
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }    
    // Once an option is selected this one is linked with its coresponding button
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
    #endregion
}
