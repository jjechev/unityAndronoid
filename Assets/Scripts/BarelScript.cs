using UnityEngine;
using System.Collections;

public class BarelScript : MonoBehaviour
{
    public int barelExistPercent;
    public float speed;
    public Material[] matirials;
    private AudioSource sound;

    int letter;

    // Use this for initialization
    void Start()
    {
        CheckIsExisting();
        SetRandomLeter();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            sound = GameObject.FindGameObjectWithTag("barrelSound").GetComponent<AudioSource>();
            sound.Play();
            UseAndDestroyBarel();
        }
        if (other.tag == "wallDown")
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        this.transform.Translate(0f, speed * Time.deltaTime, 0f);
        //this.transform.Rotate(5f, 0f, 0f);
    }

    void CheckIsExisting()
    {
        int random = Random.Range(1, 100);
        if (random > barelExistPercent)
        {
            Destroy(gameObject);
        }
    }

    void SetRandomLeter()
    {
        int leterNumber = Random.Range(0, 6);

        this.letter = leterNumber;

        Material material = matirials[leterNumber];
        Renderer child = this.gameObject.transform.GetChild(0).GetComponent<Renderer>();
        child.material = material; 
    }

    void UseAndDestroyBarel()
    {
        if (this.letter == 0)
        {// letter B bonus score
            LetterB();
        }
        if (this.letter == 1)
        {// letter C stick ball
            BallScript.instance.SetStickBall();
        }
        if (this.letter == 2)
        {// letter E expand
            if (BallScript.instance.stickBall)
            {
                BallScript.instance.stickBall = false;
            }
            Player.instance.Expand();
        }
        if (this.letter == 3)
        {// letter L life
            GameManagerScript.instance.IncLife(1);
        }
        if (this.letter == 4)
        {// letter S slow
            BallScript.instance.DecSpeed();
        }
        if (this.letter == 5)
        {// letter T 3balls

        }
        Destroy(gameObject);
    }

    void LetterB()
    {
        GameManagerScript.instance.IncScore(2000);
    }
}
