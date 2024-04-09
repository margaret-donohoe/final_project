using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public static DialogueManager Instance;
    public GameObject dialoguePanel;
    public TextAsset inkJSON;
    private Story story;

    private Memory currentMemory;
    public string currentKnot;

    public bool dialogueIsPlaying { get; private set; }
    public StarterAssetsInputs starterAssetsInputs;
    public GameObject[] choices;
    public TextMeshProUGUI[] choicesText;
    [SerializeField] private CharacterController player;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        story = new Story(inkJSON.text);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        //Debug.Log(story.Continue());
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Memory>() != null)
        {
            currentMemory = collision.gameObject.GetComponent<Memory>();
            currentKnot = currentMemory.GetKnot();
            story.ChoosePathString(currentKnot);
        }
    }

    public void Update()
    {
        if (starterAssetsInputs.submit && dialogueIsPlaying == false)
        {
            Debug.Log(story.Continue());
            //ContinueStory();
            starterAssetsInputs.submit = false;
        }

        if (starterAssetsInputs.up)
        {
            
        }

        if (starterAssetsInputs.down)
        {

        }
    }


    public void EnterDialogueMode(TextAsset inkJSON)
    {
        story = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        player.enabled = true;
        GameObject myEventSystem = GameObject.Find("UI_EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(choices[0]);
    }

    private void ContinueStory()
    {
        if (story.canContinue)
        {
            dialogueText.text = story.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = story.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
    }
}