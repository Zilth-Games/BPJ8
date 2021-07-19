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

            Destroy(character.gameObject);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact(collision.gameObject.GetComponent<Character>());
    }
}
