using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peaks : MonoBehaviour, IInteractable
{
    public void Interact(Character character)
    {
        if (character is Hero)
        {
            var hero = (Hero)character;
            hero.TakeDamage();
        }
        else if (character is Enemy)
        {
            var enemy = (Enemy)character;
            GameManager.Instance.Enemies.Remove(enemy);
            AudioManager.instance.Play(enemy.deathMusicID);
            GameManager.Instance.WalkableTilemap.SetTile((Vector3Int)character.CurrentCell, GameManager.Instance.WalkableTile);
            Destroy(character.gameObject);

        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact(collision.gameObject.GetComponent<Character>());
    }
}
