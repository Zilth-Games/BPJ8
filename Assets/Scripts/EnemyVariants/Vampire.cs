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
            SetWorldPosition(targetCell);
        }
        else
        {
            return;
        }
    }
}
