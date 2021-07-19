using UnityEngine;
public abstract class Enemy : Character
{
    public Sprite sprite;
    public int count;

    public Vector2Int currentCell;

    protected virtual void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        currentCell = GameManager.Instance.WorldPointToCell(transform.position);
    }

    protected void SetPosition(Vector3Int targetCell)
    {
        transform.position = GameManager.Instance.GetCellCenterWorld(targetCell);
        currentCell = (Vector2Int)targetCell;
    }

    public abstract void Move();
   
}
