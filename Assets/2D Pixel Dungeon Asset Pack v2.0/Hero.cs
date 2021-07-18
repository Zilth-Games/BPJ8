using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Vector3Int[,] nodes;
    Astar astar;
    List<Node> roadPath = new List<Node>();

    public Vector2Int start;
    public Vector2Int target;


    void Start()
    {
        nodes = GameManager.Instance.CreateGrid();
        astar = new Astar(nodes, GameManager.Instance.Bounds.size.x, GameManager.Instance.Bounds.size.x);
        FindPath();
    }

    public void FindPath()
    {
        nodes = GameManager.Instance.CreateGrid();

        if (roadPath != null && roadPath.Count > 0)
            roadPath.Clear();

        roadPath = astar.CreatePath(nodes, start, target, 1000);
        if (roadPath == null)
            return;

        DrawRoad();
        //start = new Vector2Int(roadPath[0].X, roadPath[0].Y);
    }
    private void DrawRoad()
    {
        for (int i = 0; i < roadPath.Count; i++)
        {
            GameManager.Instance.SetTileToRoadMap(roadPath[i].X, roadPath[i].Y);
        }
    }
}
