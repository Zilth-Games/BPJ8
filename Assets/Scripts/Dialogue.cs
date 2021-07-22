using UnityEngine;

[System.Serializable]
public struct Dialogue 
{
    [SerializeField] private string dialogueString;
    [SerializeField] private Sprite personSprite;
    [SerializeField] private string musicID;

    public string DialogueString { get => dialogueString; }
    public Sprite PersonSprite { get => personSprite; }
    public string MusicID { get => musicID;  }
}
