using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        transform.rotation = Quaternion.Euler(0,0,90);
        AudioManager.instance.Play("Door_Opening");
    }
}
