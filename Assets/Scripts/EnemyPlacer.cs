using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyPlacer : MonoBehaviour
{
    [SerializeField] private Tilemap placementTilemap;
    [SerializeField] private Cursor cursor;
    public Transform enemyParent;

    public Enemy selectedEnemyPrefab { get; set; }
    public EnemyUIButton currentEnemyButton { get; set; }

    private void Update()
    {
        if (selectedEnemyPrefab != null)
        {
            placementTilemap.GetComponent<TilemapRenderer>().enabled = true;


            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = placementTilemap.WorldToCell(mouseWorldPos);
            Vector3 cellWorldPos = placementTilemap.GetCellCenterWorld(cell);
            cursor.transform.position = cellWorldPos;
            if (placementTilemap.HasTile(cell))
            {
                cursor.Placable(selectedEnemyPrefab.sprite);
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(selectedEnemyPrefab, cellWorldPos, Quaternion.identity, enemyParent);
                    currentEnemyButton.enemySourceCount--;
                    currentEnemyButton.UpdateText();
                    placementTilemap.SetTile(cell, null);
                    cursor.transform.position = new Vector3(10, 10, 0);

                    if (currentEnemyButton.enemySourceCount == 0)
                    {
                        placementTilemap.GetComponent<TilemapRenderer>().enabled = false;
                        currentEnemyButton.Button.interactable = false;
                        selectedEnemyPrefab = null;
                        currentEnemyButton = null;
                    }

                }

            }
            else
            {
                cursor.IsntPlacable();

            }
            if (Input.GetMouseButtonDown(1))
            {
                cursor.CursorNull();
                selectedEnemyPrefab = null;
                placementTilemap.GetComponent<TilemapRenderer>().enabled = false;
            }
        }


    }
}
