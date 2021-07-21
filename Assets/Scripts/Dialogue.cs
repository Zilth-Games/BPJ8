using UnityEngine;

[System.Serializable]
public struct Dialogue 
{
    [SerializeField] private string dialogueString;
    [SerializeField] private Sprite personSprite;

    public string DialogueString { get => dialogueString; }
    public Sprite PersonSprite { get => personSprite; }
}
