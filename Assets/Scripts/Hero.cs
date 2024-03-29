﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Pathfinder))]
public class Hero : Character
{
    private Pathfinder pathfinder;
    [SerializeField] private HeartUI heartPrefab;
    [SerializeField] private Transform healthBar;
    public ParticleSystem bloodParticle;

    private Coroutine winCheckCoroutine;


    private List<HeartUI> heartUIs;


    protected override void Awake()
    {
        base.Awake();
        CreateHearts();
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
        if (GameManager.Instance.heroTargetCell == currentCell)
        {
            winCheckCoroutine = StartCoroutine(WinCheck());
        }
    }


    private IEnumerator WinCheck()
    {
        if (winCheckCoroutine != null) StopCoroutine(winCheckCoroutine);
        yield return new WaitForSeconds(.1f);

        if (health == 0) yield break;
        GameManager.Instance.isLevelFinished = true;
        GameManager.Instance.RestartLevel();

    }
    private void CreateHearts()
    {
        heartUIs = new List<HeartUI>(health);
        for (int i = 0; i < health; i++)
        {
            CreateHeartUI();
        }
    }

    private void CreateHeartUI()
    {
        var heartUI = Instantiate(heartPrefab, healthBar);
        heartUIs.Add(heartUI);
    }

    public void TakeDamage()
    {
        bloodParticle.Play();
        AudioManager.instance.Play("Knight_Damage");

        health--;
        heartUIs[health].HeartForeground.fillAmount = 0;
        if (health == 0)
        {
            AudioManager.instance.Play("Knight_Death");
            Debug.Log("Dead");
            GameManager.Instance.isLevelFinished = true;
            GameManager.Instance.LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(gameObject);
        }
    }

    public void IncreaseHealth()
    {
        if (health < heartUIs.Count)
        {
            heartUIs[health].HeartForeground.fillAmount = 1;
        }
        health++;
        AudioManager.instance.Play("Potion_Drink");


        if (health > heartUIs.Count)
        {
            CreateHeartUI();
        }
    }
}
