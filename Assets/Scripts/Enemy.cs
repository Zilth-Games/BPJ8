using UnityEngine;
public abstract class Enemy : Character , IInteractable
{
    public Sprite sprite;
    public int count;
    public string deathMusicID;

    protected override void Awake()
    {
        base.Awake();
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & LayerMask.GetMask("Hero")) != 0)
        {
            Interact(collision.gameObject.GetComponent<Character>());
        }
    }
    public void Interact(Character character)
    {
        var hero = (Hero)character;
        hero.TakeDamage();

        AudioManager.instance.Play(deathMusicID);
        GameManager.Instance.Enemies.Remove(this);
        GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, GameManager.Instance.WalkableTile);
        Destroy(gameObject);

    }




}
