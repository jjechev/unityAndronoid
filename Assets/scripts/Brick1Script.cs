using UnityEngine;
using System.Collections;

public class Brick1Script : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
       GetComponent<Renderer>().material.color = GameManagerScript.brick1Color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        checkAndDestroy();
    }

    void checkAndDestroy()
    {
        this.gameObject.SetActive(false);
        GameManagerScript.decreaseBricks();
        GameManagerScript.instance.IncScore(1);
    }

}
