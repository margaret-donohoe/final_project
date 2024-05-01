using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using UnityEngine.InputSystem;


public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public static DialogueManager Instance;
    public GameObject dialoguePanel;
    public TextAsset inkJSON;
    private Story story;

    private Memory currentMemory;
    private string currentKnot;

    //public InputAction pressUp;
    //public InputAction pressDown;

    public bool dialogueIsPlaying { get; private set; }
    private bool dialogueJustPlayed = false;
    public StarterAssetsInputs starterAssetsInputs;
    public GameObject[] choices;
    public TextMeshProUGUI[] choicesText;
    [SerializeField] private CharacterController player;

    private Color chosen = new Color(1, 1, 1, 0.65f);
    private Color notChosen = new Color(1, 1, 1, 0.3f);
    private List<Choice> curChoices;
    private int choiceInd = 0;
    private Choice playerChoice;


    public MeshRenderer gunMR;
    public MeshRenderer handguardMR;
    private GameObject mesh;
    private SkinnedMeshRenderer mr;

    public void Awake()
    {
        //pressUp = InputSystem.actions.FindAction("up");
        //pressDown = InputSystem.actions.FindAction("down");

        mesh = GameObject.Find("player");
        mr = mesh.GetComponent<SkinnedMeshRenderer>();
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
        //pressUp = starterAssetsInputs.up;

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

            handguardMR.enabled = false;
            mr.enabled = false;
            gunMR.enabled = false;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<Memory>() != null)
        {
            currentMemory = null;
            currentKnot = null;

            handguardMR.enabled = true;
            mr.enabled = true;
            gunMR.enabled = true;
        }
    }

    public void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (starterAssetsInputs.submit && dialogueIsPlaying == false)
        {
            //Debug.Log(story.Continue());
            EnterDialogueMode();
            starterAssetsInputs.submit = false;
        }

        if (starterAssetsInputs.submit && dialogueIsPlaying == true && curChoices.Count > 0)
        {
           MakeChoice(choiceInd);
           ExitDialogueMode();
        }

        if (starterAssetsInputs.submit && dialogueIsPlaying == true && curChoices.Count == 0)
        {
            ContinueStory();
            ExitDialogueMode();
        }

        if (starterAssetsInputs.up && choiceInd > 0)
        {
            //Debug.Log("UP");
            choiceInd--;
            ChangeChoice(choiceInd);
        }

        if (starterAssetsInputs.down && choiceInd < curChoices.Count - 1)
        {
            //Debug.Log("DOWN");
            choiceInd++;
            ChangeChoice(choiceInd);
        }

    }


    public void EnterDialogueMode()
    {
        //story = new Story(inkJSON.text);
        choiceInd = 0;
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        if(story.canContinue == false)
        {
            dialogueIsPlaying = false;
            StartCoroutine(StopDialogue());
        }
        ContinueStory();
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
            //choices[0].gameObject.SetActive(true);
            //choicesText[0].text = "[delete]";          //D-PAD LEFT FOR GAMEPAD MAPPING!! MAKE AN IF STATEMENT ONCE CHANGES RE MADE IN SCENE MANAGEMENT
            dialogueJustPlayed = true;
            //dialoguePanel.SetActive(false);

        }
        //GameObject myEventSystem = GameObject.Find("UI_EventSystem");
        //myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(choices[0]);
    }

    private void DisplayChoices()
    {
        curChoices = story.currentChoices;
        if (curChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + curChoices.Count);
        }
        int index = 0;

        

        foreach (Choice choice in curChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            if (curChoices.IndexOf(choice) == 0)
            {
                choicesText[index].GetComponent<TextMeshProUGUI>().color = chosen;
            }
            else
            {
                choicesText[index].GetComponent<TextMeshProUGUI>().color = notChosen;
            }
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
        ContinueStory();
    }

    void ChangeChoice(int cI)
    {
        //Debug.Log(cI);

        foreach (Choice choice in curChoices)
        {
            if (curChoices.IndexOf(choice) == cI)
            {
                choicesText[curChoices.IndexOf(choice)].GetComponent<TextMeshProUGUI>().color = chosen;
                playerChoice = choice;
            }
            else
            {
                choicesText[curChoices.IndexOf(choice)].GetComponent<TextMeshProUGUI>().color = notChosen;
            }
        }
        return;
    }
    IEnumerator StopDialogue()
    {
        yield return new WaitForSeconds(1.5f);
        dialogueText.text = "";
        choicesText[0].text = "";
        dialoguePanel.SetActive(false);
        dialogueJustPlayed = false;

        handguardMR.enabled = true;
        mr.enabled = true;
        gunMR.enabled = true;
    }
}