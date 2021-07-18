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
    [SerializeField] private float stepInterval = 0.5f;
    private float timer ;

    private Hero hero;
    private Enemy[] enemies;

    public bool isLevelFinished;

    private bool isGameStarted;

    public BoundsInt Bounds { get; private set; }
    public Camera MainCamera { get; private set; }
    public Tilemap WalkableTilemap { get => walkableTilemap; set => walkableTilemap = value; }

    public Vector2Int HeroCellPosition
    {
        get
        {
            return WorldPointToCell(hero.transform.position);
        }
    }

    private void Awake()
    {
        walkableTilemap.CompressBounds();
        roadTilemap.CompressBounds();
        Bounds = walkableTilemap.cellBounds;
        MainCamera = Camera.main;

        timer = stepInterval;
        hero = FindObjectOfType<Hero>();
        enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        if (isLevelFinished) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGameStarted = !isGameStarted;
            timer = 0;
        }
        if (isGameStarted)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = stepInterval;
                hero.Move();
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].Move();
                }
            }
        }

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

    public Vector2Int WorldPointToCell(Vector3 worldPoint)
    {
        Vector3Int gridPos = walkableTilemap.WorldToCell(worldPoint);
        return (Vector2Int)gridPos;
    }
    public Vector3 GetCellCenterWorld(Vector3Int cell)
    {
        return walkableTilemap.GetCellCenterWorld(cell);
    }

    public void SetTileToRoadMap(int x, int y)
    {
        roadTilemap.SetTile(new Vector3Int(x, y, 0), roadTile);
    }

}
