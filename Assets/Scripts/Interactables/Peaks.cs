using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peaks : MonoBehaviour, IInteractable
{
    public void Interact(Character character)
    {
        //character.health--;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact(collision.gameObject.GetComponent<Character>());
    }
}
