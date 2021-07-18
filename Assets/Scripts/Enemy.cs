using UnityEngine;
public class Enemy : Character
{
    public Sprite sprite;
    public int count;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    public override void Move()
    {
        base.Move();
        currentCell = GameManager.Instance.WorldPointToCell(transform.position);
        targetCell = GameManager.Instance.HeroCellPosition;

        if (currentNodeIndex == 0)
        {
            Debug.Log("Attack");
        }
    }
}
