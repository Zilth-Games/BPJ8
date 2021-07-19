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
            case 0://Left
                if (GameManager.Instance.WalkableTilemap.HasTile(leftCell)) return;
                targetCell = leftCell;
                break;
            case 1://up
                if (GameManager.Instance.WalkableTilemap.HasTile(upCell)) return;
                targetCell = upCell;
                break;
            case 2://right
                if (GameManager.Instance.WalkableTilemap.HasTile(rightCell)) return;
                targetCell = rightCell;
                break;
            case 3://down
                if (GameManager.Instance.WalkableTilemap.HasTile(downCell)) return;
                targetCell = downCell;
                break;
        }
        i++;
        if (i == 3) i = 0;
        SetPosition(targetCell);
    }
}
