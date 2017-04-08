using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{

    public static bool isTeleport;

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "player")
        {
            isTeleport = true;
            GameManagerScript.instance.CheckAndGoNextLevel();
            isTeleport = false;
            Destroy(gameObject);
        }
    }
}
