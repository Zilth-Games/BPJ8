using UnityEngine;
public abstract class Enemy : Character
{
    public Sprite sprite;
    public int count;


    protected override void Awake()
    {
        base.Awake();
        GetComponent<SpriteRenderer>().sprite = sprite;
    }




}
