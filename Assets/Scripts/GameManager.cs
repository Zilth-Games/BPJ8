using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Tilemap walkableTilemap;
    [SerializeField] private Tilemap trapTilemap;

    [SerializeField] private Tilemap roadTilemap;
    [SerializeField] private TileBase roadTile;


    [SerializeField] private Vector2Int heroTarget;

    public BoundsInt Bounds { get; private set; }
    public Camera MainCamera { get; private set; }

    private void Awake()
    {
        walkableTilemap.CompressBounds();
        roadTilemap.CompressBounds();
        Bounds = walkableTilemap.cellBounds;
        MainCamera = Camera.main;
    }
    public bool OnWalkableTile(Vector3Int cellPos)
    {
        return walkableTilemap.HasTile(cellPos);
    }
    public bool OnTrapTile(Vector3Int cellPos)
    {
        return trapTilemap.HasTile(cellPos);
    }

    public Vector3Int[,] CreateGrid()
    {
        var nodes = new Vector3Int[Bounds.size.x, Bounds.size.y];
        for (int x = Bounds.xMin, i = 0; i < (Bounds.size.x); x++, i++)
        {
            for (int y = Bounds.yMin, j = 0; j < (Bounds.size.y); y++, j++)
            {
                if (walkableTilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    nodes[i, j] = new Vector3Int(x, y, 0);
                }
                else
                {
                    nodes[i, j] = new Vector3Int(x, y, 1);
                }
            }
        }
        return nodes;
    }

    public Vector3Int WorldPointToCell(Vector3 worldPoint)
    {
        Vector3Int gridPos = walkableTilemap.WorldToCell(worldPoint);
        return gridPos;
    }

    public void SetTileToRoadMap(int x,int y)
    {
        roadTilemap.SetTile(new Vector3Int(x, y, 0), roadTile);
    }

}
