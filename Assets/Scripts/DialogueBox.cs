using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private Image personImage;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Button nextDialogueButton;
    [SerializeField] private float dialogueLetterInterval;


    public Button NextDialogueButton { get => nextDialogueButton; }

    public void SetDialogue(Sprite sprite, string dialogueString)
    {
        dialogueText.text = null;
        personImage.sprite = sprite;
        StartCoroutine(DialogueTextCo(dialogueString));
        //dialogueText.text = dialogueString;
    }
    IEnumerator DialogueTextCo(string dialogueString)
    {
        for (int i = 0; i < dialogueString.Length; i++)
        {
            dialogueText.text += dialogueString[i];
            yield return new WaitForSeconds(dialogueLetterInterval);
        }
    }
}