using UnityEngine;

[RequireComponent(typeof(Pathfinder))]

public class Vampire : Enemy
{
    private Pathfinder pathfinder;

    protected override void Awake()
    {
        base.Awake();
        pathfinder = GetComponent<Pathfinder>();
    }
    public override void Move()
    {
        Vector3Int targetCell = Vector3Int.zero;
        pathfinder.TargetCell = GameManager.Instance.HeroCell;
        if (pathfinder.FindPath(currentCell, out targetCell))
        {
            GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, GameManager.Instance.WalkableTile);
            SetWorldPosition(targetCell);
            GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, null);
        }
        else
        {
            return;
        }
    }
}
