using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private List<Dialogue> dialogues;
    private DialogueBox dialogueBox;

    private int currentDialogueIndex;

    public Dialogue CurrentDialogue
    {
        get
        {
            return dialogues[currentDialogueIndex];
        }
    }

    private void Awake()
    {
        dialogueBox = FindObjectOfType<DialogueBox>();
        dialogueBox.gameObject.SetActive(false);
        dialogueBox.NextDialogueButton.onClick.AddListener(NextDialogue);
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
        dialogueBox.gameObject.SetActive(true);
        dialogueBox.SetDialogue(CurrentDialogue.PersonSprite, CurrentDialogue.DialogueString,CurrentDialogue.MusicID);

    }
    private void OnDestroy()
    {
        dialogueBox.NextDialogueButton.onClick.RemoveListener(NextDialogue);
    }
    public void NextDialogue()
    {
        currentDialogueIndex++;
        if(currentDialogueIndex == dialogues.Count)
        {
            dialogueBox.gameObject.SetActive(false);
            return;
        }
        dialogueBox.SetDialogue(CurrentDialogue.PersonSprite, CurrentDialogue.DialogueString,CurrentDialogue.MusicID);
    }

}
