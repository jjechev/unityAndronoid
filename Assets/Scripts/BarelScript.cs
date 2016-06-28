using UnityEngine;
using System.Collections;

public class BarelScript : MonoBehaviour
{
    public int barelExistPercent;
    public float speed;
    

    // Use this for initialization
    void Start()
    {
        CheckIsExisting();
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
            Debug.Log("collision player");
            Destroy(gameObject);
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
}
