using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("Buttons")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button fastButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button soundButton;
    [Header("Fast Button Sprites")]
    [SerializeField] private Sprite fastButtonSprite1;
    [SerializeField] private Sprite fastButtonSprite2;

    [Header("Sound Button Sprites")]
    [SerializeField] private Sprite soundButtonSprite1;
    [SerializeField] private Sprite soundButtonSprite2;
    [Header("Tilemaps")]

    [SerializeField] private Tilemap walkableTilemap;
    [SerializeField] private Tilemap trapTilemap;
    [SerializeField] private Tilemap roadTilemap;

    [Header("Tiles")]

    [SerializeField] private TileBase roadTile;
    [SerializeField] private TileBase walkableTile;

    [SerializeField] private List<Enemy> enemyPrefabs;
    [SerializeField] private EnemyUIButton enemyUIButtonPrefab;
    private List<EnemyUIButton> enemyUIButtons = new List<EnemyUIButton>();
    [SerializeField] private Transform enemyUIButtonParent;

    [SerializeField] private float stepInterval = 0.5f;

    [SerializeField] private Animator levelLoaderAnimator;
    private float timer;

    private Hero hero;
    private List<Enemy> enemies;

    public bool isLevelFinished;

    private bool isGameStarted;

    public BoundsInt Bounds { get; private set; }
    public Camera MainCamera { get; private set; }
    public Tilemap WalkableTilemap { get => walkableTilemap; set => walkableTilemap = value; }

    public Vector2Int HeroCell
    {
        get
        {
            return WorldPointToCell(hero.transform.position);
        }
    }
    public Vector2Int heroTargetCell;

    public TileBase WalkableTile { get => walkableTile; }
    public Tilemap RoadTilemap { get => roadTilemap; }
    public List<Enemy> Enemies { get => enemies; }
    public Button PlayButton { get => playButton; }

    private void Awake()
    {

        CreateEnemyUIButtons();
        enemies = new List<Enemy>();

        walkableTilemap.CompressBounds();
        roadTilemap.CompressBounds();
        Bounds = walkableTilemap.cellBounds;
        MainCamera = Camera.main;
        timer = stepInterval;
        hero = FindObjectOfType<Hero>();
    }

    private void Update()
    {
        if (isLevelFinished) return;

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

                for (int i = 0; i < enemies.Count; i++)
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

    public void CreateEnemyUIButtons()
    {
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            var enemyButton = Instantiate(enemyUIButtonPrefab, enemyUIButtonParent);
            enemyButton.SetProps(enemyPrefabs[i].sprite, enemyPrefabs[i].count, enemyPrefabs[i]);
            enemyUIButtons.Add(enemyButton);
        }
    }

    public void RestartLevel()
    {
        AudioManager.instance.Play("Button");
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
    public void FastButton()
    {
        AudioManager.instance.Play("Button");
        Time.timeScale += 1.5f;
        if (Time.timeScale == 4f)
        {
            fastButton.image.sprite = fastButtonSprite1;
            Time.timeScale = 1f;
        }
        if (Time.timeScale == 2.5f)
        {
            fastButton.image.sprite = fastButtonSprite2;
        }
    }
    public void VoiceButton()
    {
        AudioManager.instance.Play("Button");
        AudioSource audioSource = AudioManager.instance.GetComponent<AudioSource>();
        if (audioSource.volume == 0.511f)
        {
            soundButton.image.sprite = soundButtonSprite2;
            audioSource.volume = 0f;
        }
        else
        {
            soundButton.image.sprite = soundButtonSprite1;
            audioSource.volume = 0.511f;
        }
    }
    public void LoadLevel(int buildIndex)
    {
        StartCoroutine(LoadLevelCo(buildIndex));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadNextLevel(int buildIndex)
    {
        LoadLevel(buildIndex);
    }
    private IEnumerator LoadLevelCo(int buildIndex)
    {
        levelLoaderAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(buildIndex);
    }
    public void Play()
    {
        AudioManager.instance.Play("Button");
        isGameStarted = true;
        timer = 0;
        playButton.image.enabled = false;
        for (int i = 0; i < enemyUIButtons.Count; i++)
        {
            enemyUIButtons[i].Button.interactable = false;
        }
    }
}
