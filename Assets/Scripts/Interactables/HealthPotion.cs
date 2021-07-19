using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, IInteractable
{
    public void Interact(Character character)
    {
        var hero = (Hero)character;
        Debug.Log(character.name);
        hero.IncreaseHealth();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & LayerMask.GetMask("Hero")) != 0)
        {
            Interact(collision.gameObject.GetComponent<Character>());
        }
    }
}