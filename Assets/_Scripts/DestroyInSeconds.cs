using UnityEngine;
using System.Collections;

public class DestroyInSeconds : MonoBehaviour
{
    public float seconds;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, seconds);
    }

}
