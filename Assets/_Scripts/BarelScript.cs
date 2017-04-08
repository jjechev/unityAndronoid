using UnityEngine;
using System.Collections;

public class BarelScript : MonoBehaviour
{
    public int barelExistPercent;
    public float speed;
    public Material[] matirials;
    public GameObject[] tags;
    public GameObject teleport;


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
            Instantiate(tags[0], this.transform.position, Quaternion.identity);
        }
        if (this.letter == 1)
        {// letter C stick ball
            BallScript.instance.SetStickBall();
            Instantiate(tags[1], this.transform.position, Quaternion.identity);
        }
        if (this.letter == 2)
        {// letter E expand
            if (BallScript.instance.stickBall)
            {
                BallScript.instance.stickBall = false;
            }
            Player.instance.Expand();
            Instantiate(tags[2], this.transform.position, Quaternion.identity);
        }
        if (this.letter == 3)
        {// letter L life
            GameManagerScript.instance.IncLife(1);
            Instantiate(tags[3], this.transform.position, Quaternion.identity);
        }
        if (this.letter == 4)
        {// letter S slow
            BallScript.instance.DecSpeed();
            Instantiate(tags[4], this.transform.position, Quaternion.identity);
        }
        if (this.letter == 5)
        {// letter T 3balls
            Instantiate(tags[5], this.transform.position, Quaternion.identity);
            Instantiate(teleport, new Vector3(9f,-4.3f,0f) , Quaternion.identity);
        }
        Destroy(gameObject);
    }

    void LetterB()
    {
        GameManagerScript.instance.IncScore(2000);
    }
}
