using UnityEngine;
using System.Collections;

public class Brick2Script : MonoBehaviour
{

    private int hit = 2;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.color = GameManagerScript.brick2Color;
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
        GameManagerScript.instance.IncScore(1);
        hit--;
        if (hit == 0)
        {
            this.gameObject.SetActive(false);
            GameManagerScript.decreaseBricks();
        }
        else
        {
            GetComponent<Renderer>().material.color = GameManagerScript.brick1Color;
        }
    }
}
