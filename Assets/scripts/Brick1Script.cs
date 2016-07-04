using UnityEngine;
using System.Collections;

public class Brick1Script : MonoBehaviour
{
    public ParticleSystem BrickParticle;

    public GameObject Barel;

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
        CreateBarel();
    }

    void checkAndDestroy()
    {
        Color color = GetComponent<Renderer>().material.color;
        ParticleSystem Particlez =  (ParticleSystem)Instantiate(BrickParticle, transform.position, Quaternion.identity);
        Particlez.startColor = color;
        Debug.Log(Particlez.startColor);


        GameManagerScript.decreaseBricks();
        GameManagerScript.instance.IncScore(100);
        GameManagerScript.instance.CheckAndGoNextLevel();
        Destroy(gameObject);
    }


    void CreateBarel()
    {
        Instantiate(Barel, new Vector3(transform.position.x, transform.position.y - 0.5f, -0.2f), Quaternion.identity);
    }
}
