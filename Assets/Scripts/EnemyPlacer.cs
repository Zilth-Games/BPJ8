using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyPlacer : MonoBehaviour
{
    [SerializeField] private Tilemap placementTilemap;
    [SerializeField] private Cursor cursor;

    public Enemy selectedEnemyPrefab { get; set; }
    public EnemyUIButton currentEnemyButton { get; set; }

    private void Update()
    {
        if (selectedEnemyPrefab != null)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = placementTilemap.WorldToCell(mouseWorldPos);
            Vector3 cellWorldPos = placementTilemap.GetCellCenterWorld(cell);
            cursor.transform.position = cellWorldPos;
            if (placementTilemap.HasTile(cell))
            {
                cursor.A(selectedEnemyPrefab.sprite);
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(selectedEnemyPrefab, cellWorldPos, Quaternion.identity);
                    currentEnemyButton.enemySourceCount--;
                    currentEnemyButton.UpdateText();
                    placementTilemap.SetTile(cell, null);

                    if (currentEnemyButton.enemySourceCount == 0)
                    {
                        currentEnemyButton.Button.interactable = false;
                        selectedEnemyPrefab = null;
                        currentEnemyButton = null;
                    }

                }

            }
            else
            {
                cursor.B();

            }
            if (Input.GetMouseButtonDown(1))
            {
                cursor.C();
                selectedEnemyPrefab = null;
            }
        }


    }
}
