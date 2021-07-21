using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private Vector3Int[,] nodes;
    private Astar astar;
    private List<Node> roadPath = new List<Node>();

    private Vector2Int targetCell;

    public Vector2Int TargetCell { get => targetCell; set => targetCell = value; }

    private void Start()
    {
        nodes = GameManager.Instance.CreateGrid();
        astar = new Astar(nodes, GameManager.Instance.Bounds.size.x, GameManager.Instance.Bounds.size.x);
    }

    public bool FindPath(Vector2Int currentCell,out Vector3Int nextCell)
    {
        nodes = GameManager.Instance.CreateGrid();

        if (roadPath != null && roadPath.Count > 0)
            roadPath.Clear();
        roadPath = astar.CreatePath(nodes, currentCell, targetCell, 1000);

        if (roadPath == null)
        {
            nextCell = default;
            return false;
        }
        else
        {
            var node = roadPath[roadPath.Count - 2];
            nextCell = new Vector3Int(node.X, node.Y, 0);
            
            return true;

        }

        //DrawRoad();
    }
    private void DrawRoad()
    {
        GameManager.Instance.RoadTilemap.ClearAllTiles();
        for (int i = 0; i < roadPath.Count; i++)
        {
            GameManager.Instance.SetTileToRoadMap(roadPath[i].X, roadPath[i].Y);
        }
    }
}
