using UnityEngine;

public class Cursor : MonoBehaviour
{

    [SerializeField] private Sprite b;
    public SpriteRenderer spriteRenderer;


    public void Placable(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    public void IsntPlacable()
    {
        spriteRenderer.sprite = b;
    }
    public void CursorNull()
    {
        spriteRenderer.sprite = null;
    }

}
