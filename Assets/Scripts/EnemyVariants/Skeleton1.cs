using UnityEngine;

public class Skeleton1 : Enemy
{
    private bool right = true;
    public override void Move()
    {
        Vector3Int targetCell = Vector3Int.zero;
        Vector3Int leftCell = new Vector3Int(currentCell.x - 1, currentCell.y, 0);
        Vector3Int rightCell = new Vector3Int(currentCell.x + 1, currentCell.y, 0);



        if (right)
        {
            if (GameManager.Instance.WalkableTilemap.HasTile(rightCell))
            {
                targetCell = rightCell;
            }
            else if (GameManager.Instance.WalkableTilemap.HasTile(leftCell))
            {
                targetCell = leftCell;
                right = false;
            }
            else
            {
                GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, null);
                return;
            }

        }
        else
        {
            if (GameManager.Instance.WalkableTilemap.HasTile(leftCell))
            {
                targetCell = leftCell;
            }
            else if (GameManager.Instance.WalkableTilemap.HasTile(rightCell))
            {
                targetCell = rightCell;
                right = true;
            }
            else
            {
                GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, null);
                return;
            }
        }

        GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, GameManager.Instance.WalkableTile);
        SetWorldPosition(targetCell);
        GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, null);

    }
}
