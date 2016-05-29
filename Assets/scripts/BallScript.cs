using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{

    public float speedX;
    public float speedY;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(1f * speedX, 1f * speedY, 0f);
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.collider.name);
        if (col.collider.tag == "wallUp")
        {
            ChangeDirection(col.collider);
        }

        if (col.collider.tag == "wallDown")
        {
            ChangeDirection(col.collider);
        }

        if (col.collider.tag == "wallLeft" || col.collider.tag == "wallRight")
        {
            ChangeDirection(col.collider);
        }


    }

    public void ChangeDirection(Collider col)
    {
        if (col.name == "player")
        {
            speedY = -((col.transform.position.y - this.transform.position.y) / col.transform.localScale.y / 5);
        }

        if (col.tag == "wallUp")
        {
            speedY = -speedY;
        }

        if (col.tag == "wallDown")
        {
            speedY = -speedY;
        }

        if (col.tag == "wallLeft" || col.tag == "wallRight")
        {
            speedX = -speedX;
        }


    }

}
