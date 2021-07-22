using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public void Interact(Character character)
    {
        if (character is Hero)
        {
            AudioManager.instance.Play("Key_Pickup");
            FindObjectOfType<Door>().Open();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact(collision.gameObject.GetComponent<Character>());
    }
}
