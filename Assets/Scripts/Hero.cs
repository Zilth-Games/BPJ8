
using UnityEngine;

public class Hero : Character
{
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
