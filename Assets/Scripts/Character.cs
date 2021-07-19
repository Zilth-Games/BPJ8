using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Vector2Int currentCell;

    public int health;
    protected virtual void Awake()
    {
        currentCell = GameManager.Instance.WorldPointToCell(transform.position);
    }
    public abstract void Move();

    protected void SetWorldPosition(Vector3Int targetCell)
    {
        transform.position = GameManager.Instance.GetCellCenterWorld(targetCell);
        currentCell = (Vector2Int)targetCell;
    }

}
