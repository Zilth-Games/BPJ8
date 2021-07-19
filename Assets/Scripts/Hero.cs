
using UnityEngine;

[RequireComponent(typeof(Pathfinder))]
public class Hero : Character
{
    private Pathfinder pathfinder;

    protected override void Awake()
    {
        base.Awake();
        pathfinder = GetComponent<Pathfinder>();
        pathfinder.TargetCell = GameManager.Instance.heroTargetCell;
        SetWorldPosition(new Vector3Int(currentCell.x, currentCell.y, 0));

    }
    public override void Move()
    {
        Vector3Int targetCell = Vector3Int.zero;
        if (pathfinder.FindPath(currentCell, out targetCell))
        {
            SetWorldPosition(targetCell);
        }
        else
        {
            return;
        }
    }
    //public override void Move()
    //{
    //    FindPath();
    //    //if (roadPath == null) return;
    //    Vector3 worldPt = GameManager.Instance.GetCellCenterWorld(new Vector3Int(roadPath[currentNodeIndex].X, roadPath[currentNodeIndex].Y, 1));
    //    transform.position = worldPt;

    //    currentCell = GameManager.Instance.WorldPointToCell(transform.position);

    //    if (currentNodeIndex == 0)
    //    {
    //        Debug.Log("Win");
    //        GameManager.Instance.isLevelFinished = true;
    //    }
    //}

    //public override void FindPath()
    //{
    //    base.FindPath();
    //    DrawRoad();
    //}
}
