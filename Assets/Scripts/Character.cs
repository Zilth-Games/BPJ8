using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private Vector3Int[,] nodes;
    private Astar astar;
    private List<Node> roadPath = new List<Node>();

    protected int currentNodeIndex;
    protected Vector2Int currentCell;
    public Vector2Int targetCell;

    protected virtual void Start()
    {
        nodes = GameManager.Instance.CreateGrid();
        astar = new Astar(nodes, GameManager.Instance.Bounds.size.x, GameManager.Instance.Bounds.size.x);
        currentCell = GameManager.Instance.WorldPointToCell(transform.position);
        transform.position = GameManager.Instance.GetCellCenterWorld(new Vector3Int(currentCell.x, currentCell.y, 1));
    }

    public virtual void Move()
    {
        FindPath();
        Vector3 worldPt = GameManager.Instance.GetCellCenterWorld(new Vector3Int(roadPath[currentNodeIndex].X, roadPath[currentNodeIndex].Y, 1));
        transform.position = worldPt;
    }

    public void FindPath()
    {
        nodes = GameManager.Instance.CreateGrid();

        if (roadPath != null && roadPath.Count > 0)
            roadPath.Clear();
        roadPath = astar.CreatePath(nodes, currentCell, targetCell, 1000);

        if (roadPath == null)
            return;

        currentNodeIndex = roadPath.Count - 2;

        //DrawRoad();
    }
    private void DrawRoad()
    {
        for (int i = 0; i < roadPath.Count; i++)
        {
            GameManager.Instance.SetTileToRoadMap(roadPath[i].X, roadPath[i].Y);
        }
    }
}
