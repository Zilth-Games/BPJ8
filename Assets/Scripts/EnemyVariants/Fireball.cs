using UnityEngine;


public class Fireball : Enemy
{
    int i = 0;
    public override void Move()
    {
        Vector3Int targetCell = (Vector3Int)currentCell;
        Vector3Int leftCell = new Vector3Int(currentCell.x - 1, currentCell.y, 0);
        Vector3Int rightCell = new Vector3Int(currentCell.x + 1, currentCell.y, 0);
        Vector3Int upCell = new Vector3Int(currentCell.x, currentCell.y+1, 0);
        Vector3Int downCell = new Vector3Int(currentCell.x, currentCell.y-1, 0);
        switch (i)
        {
            case 0://Right
                i++;
                if (!GameManager.Instance.WalkableTilemap.HasTile(rightCell)) { Move(); return; }
                targetCell = rightCell;
                break;
            case 1://up
                i++;
                if (!GameManager.Instance.WalkableTilemap.HasTile(upCell)) { Move(); return; }
                targetCell = upCell;
                break;
            case 2://left
                i++;
                if (!GameManager.Instance.WalkableTilemap.HasTile(leftCell)) { Move(); return; }
                targetCell = leftCell;
                break;
            case 3://down
                i++;
                if (!GameManager.Instance.WalkableTilemap.HasTile(downCell)) { Move(); return; }
                targetCell = downCell;
                break;
        }

        if (i == 4) i = 0;

        GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, GameManager.Instance.WalkableTile);
        SetWorldPosition(targetCell);
        GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, null);
    }
}
