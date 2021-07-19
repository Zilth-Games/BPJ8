using UnityEngine;

public class Skeleton2 : Enemy
{ 
    private bool up = true;
    public override void Move()
    {
        Vector3Int targetCell = Vector3Int.zero;
        Vector3Int upCell = new Vector3Int(currentCell.x , currentCell.y + 1, 0);
        Vector3Int downCell = new Vector3Int(currentCell.x , currentCell.y - 1, 0);

        if (up)
        {
            if (GameManager.Instance.WalkableTilemap.HasTile(downCell))
            {
                targetCell = downCell;
            }
            else if (GameManager.Instance.WalkableTilemap.HasTile(upCell))
            {
                targetCell = upCell;
                up = false;
            }
            else
            {
                return;
            }

        }
        else
        {
            if (GameManager.Instance.WalkableTilemap.HasTile(upCell))
            {
                targetCell = upCell;
            }
            else if (GameManager.Instance.WalkableTilemap.HasTile(downCell))
            {
                targetCell = downCell;
                up = true;
            }
            else
            {
                return;
            }
        }
        GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, GameManager.Instance.WalkableTile);
        SetWorldPosition(targetCell);
        GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, null);
    }
}


