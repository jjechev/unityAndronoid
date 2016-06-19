using UnityEngine;
using System.Collections;

public class Brick1Script : MonoBehaviour
{
    public ParticleSystem BrickParticle;

    // Use this for initialization
    void Start()
    {
       //GetComponent<Renderer>().material.color = GameManagerScript.brick1Color;
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
        Color color = GetComponent<Renderer>().material.color;
        //Color color = Color.green;
        ParticleSystem Particlez =  (ParticleSystem)Instantiate(BrickParticle, transform.position, Quaternion.identity);
        Particlez.startColor = color;
        Debug.Log(Particlez.startColor);


        GameManagerScript.decreaseBricks();
        GameManagerScript.instance.IncScore(1);
        GameManagerScript.instance.CheckAndGoNextLevel();
        Destroy(gameObject);
    }

}
