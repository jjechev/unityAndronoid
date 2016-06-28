using UnityEngine;
using System.Collections;

public class Brick2Script : MonoBehaviour
{
    Animation anim;
    public ParticleSystem BrickParticle;
    private int hit = 2;

    public GameObject Barel;

    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animation>();
        GetComponent<Renderer>().material.color = GameManagerScript.brick2Color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "ball")
        {
            checkAndDestroy();
        }
    }

    void checkAndDestroy()
    {
        GameManagerScript.instance.IncScore(1);
        hit--;
        if (hit == 0)
        {
            Color color = GetComponent<Renderer>().material.color;
            ParticleSystem Particlez = (ParticleSystem)Instantiate(BrickParticle, transform.position, Quaternion.identity);
            Particlez.startColor = color;
            Debug.Log(Particlez.startColor);

            this.gameObject.SetActive(false);
            GameManagerScript.decreaseBricks();
            GameManagerScript.instance.CheckAndGoNextLevel();
        }
        else
        {
            //anim.Play();
            GetComponent<Renderer>().material.color = GameManagerScript.brick1Color;
        }
    }
}
