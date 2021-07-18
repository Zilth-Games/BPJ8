using UnityEngine;

public class Cursor : MonoBehaviour
{

    [SerializeField] private Sprite b;
    public SpriteRenderer spriteRenderer;


    public void A(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    public void B()
    {
        spriteRenderer.sprite = b;

    }
    public void C()
    {
        spriteRenderer.sprite = null;
    }

}
