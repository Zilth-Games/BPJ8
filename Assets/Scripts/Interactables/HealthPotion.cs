using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, IInteractable
{
    public void Interact(Character character)
    {
        //character.health++;
        Debug.Log(character.name);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact(collision.gameObject.GetComponent<Character>());
    }
}