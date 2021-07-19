using UnityEngine;
public class Enemy : Character
{


    protected override void Start()
    {
        base.Start();
        targetCell = GameManager.Instance.HeroCell;
    }

    public Sprite sprite;
    public int count;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    public override void Move()
    {
        FindPath();
        if (roadPath == null) return;
        Vector3 worldPt = GameManager.Instance.GetCellCenterWorld(new Vector3Int(roadPath[currentNodeIndex].X, roadPath[currentNodeIndex].Y, 1));
        transform.position = worldPt;

 
        GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, GameManager.Instance.WalkableTile);
        currentCell = GameManager.Instance.WorldPointToCell(transform.position);
        targetCell = GameManager.Instance.HeroCell;
        GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, null);

        if (currentNodeIndex == 0)
        {
            Debug.Log("Near The Hero");
            //targetCell = GameManager.Instance.HeroCell;

            //GameManager.Instance.isLevelFinished = true;

        }
        else
        {
            GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, GameManager.Instance.WalkableTile);
            currentCell = GameManager.Instance.WorldPointToCell(transform.position);
            targetCell = GameManager.Instance.HeroCell;
            GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)currentCell, null);

        }
    }
}
