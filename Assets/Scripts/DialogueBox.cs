using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private Image personImage;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Button nextDialogueButton;
    [SerializeField] private float dialogueLetterInterval;
    [SerializeField] private CanvasGroup blockPanel;


    public Button NextDialogueButton { get => nextDialogueButton; }
    public void SetDialogue(Sprite sprite, string dialogueString,string musicID)
    {
        dialogueText.text = null;
        personImage.sprite = sprite;
        StartCoroutine(DialogueTextCo(dialogueString,musicID));
        //dialogueText.text = dialogueString;
    }
    IEnumerator DialogueTextCo(string dialogueString, string musicId)
    {
        for (int i = 0; i < dialogueString.Length; i++)
        {
            dialogueText.text += dialogueString[i];
            AudioManager.instance.Play(musicId);
            yield return new WaitForSeconds(dialogueLetterInterval);

        }
    }
    public void CloseBlockPanel()
    {
        blockPanel.blocksRaycasts = false;
        blockPanel.interactable = false;
        blockPanel.alpha = 0;
    }
}