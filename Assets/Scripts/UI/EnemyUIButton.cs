using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIButton : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField] private Image image;
    [SerializeField] private Text text;
    [SerializeField] private Button button;
    private Enemy enemyPrefab;
    EnemyPlacer enemyPlacer ;


    public static int totalEnemySourceCount;
    public int enemySourceCount;

    public Button Button { get => button; set => button = value; }

    private void Awake()
    {
        enemyPlacer = FindObjectOfType<EnemyPlacer>();
        button.onClick.AddListener(ChooseEnemy);
    }
    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }

    public void SetProps(Sprite enemySprite,int enemySourceCount,Enemy enemyPrefab)
    {
        image.sprite = enemySprite;
        this.enemySourceCount = enemySourceCount;
        this.enemyPrefab = enemyPrefab;
        totalEnemySourceCount += enemySourceCount;
        UpdateText();
    }

    public void ChooseEnemy()
    {
        AudioManager.instance.Play("Button");
        enemyPlacer.selectedEnemyPrefab = enemyPrefab;
        enemyPlacer.currentEnemyButton = this;
    }
    public void UpdateText()
    {
        text.text = enemySourceCount.ToString();
    }

}
