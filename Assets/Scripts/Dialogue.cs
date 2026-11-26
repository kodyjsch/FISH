using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    [SerializeField] private Button[] butts;
    [SerializeField] private TextMeshProUGUI[] choicesText;

    private Story CurrentStory;

    private PauseMenu pM;
    private FishList fL;
    private bool isPlaying;
    private static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    void Start()
    {

        pM = GameObject.FindWithTag("list").GetComponent<PauseMenu>();
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
        isPlaying = false;

        choicesText = new TextMeshProUGUI[choices.Length];
    }

    private void Update()
    {

        if (DialoguePanel == null)
        {
            DialoguePanel = GameObject.FindWithTag("dialogue");
            dialogueText = GameObject.FindWithTag("text").GetComponent<TextMeshProUGUI>();

            choices[0] = GameObject.FindWithTag("c1");
            choices[1] = GameObject.FindWithTag("c2");
            choices[2] = GameObject.FindWithTag("c3");

            for(int i = 0; i < choices.Length; i++)
            {
                choicesText[i] = choices[i].GetComponentInChildren<TextMeshProUGUI>();
            }

            for(int j = 0; j < choices.Length; j++)
            {
                butts[j] = choices[j].GetComponent<Button>();
            }

            for(int k = 0; k < butts.Length; k++)
            {
                butts[k].onClick.AddListener(() => MakeChoice(k));
            }

            DialoguePanel.SetActive(false);
        }

        if (!isPlaying)
        {
            return;
        }        

        if (Input.GetButtonDown("Submit"))
        {
            ContinueStory();
        }
    }

    public void EnterDialogue(TextAsset inky)
    {
        CurrentStory = new Story(inky.text);
        isPlaying = true;
        DialoguePanel.SetActive(true);

        pM.Pause(false);
        pM.dialogue = true;

        ContinueStory();

    }


    private IEnumerator ExitDialogue()
    {
        yield return null;

        isPlaying = false;
        DialoguePanel.SetActive(false);
        dialogueText.text = "";

        pM.Resume();
        pM.dialogue = false;

        fL.trigger = true;

        if(fL.shopTrigActive == false)
        {
            fL.ShopTrig(true);
        }
    }

    private void ContinueStory()
    {
        if (CurrentStory.canContinue)
        {
            dialogueText.text = CurrentStory.Continue();
            DisplayChoices();
        } else
        {
            StartCoroutine(ExitDialogue());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = CurrentStory.currentChoices;

        int indexD = 0;

        foreach(Choice choice in currentChoices)
        {
            choices[indexD].gameObject.SetActive(true);
            choicesText[indexD].text = choice.text;
            indexD++;
        }

        for(int i = indexD; i< choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(FirstChoice());

    }

    private IEnumerator FirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        CurrentStory.ChooseChoiceIndex(choiceIndex);
    }

}
