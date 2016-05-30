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
        ChangeDirection(col);
    }

    public void ChangeDirection(Collision col)
    {
        if (col.collider.tag == "player")
        {
            speedX = -((col.transform.position.x - this.transform.position.x) / col.transform.localScale.x / 5);
            speedY = -speedY;
        }

        if (col.collider.tag == "wallUp")
        {
            speedY = -speedY;
        }

        if (col.collider.tag == "wallDown")
        {
            speedY = -speedY;
            GameManagerScript.instance.LostLife();
        }

        if (col.collider.tag == "wallLeft" || col.collider.tag == "wallRight")
        {
            speedX = -speedX;
        }

        if (col.collider.tag == "brick")
        {
            float brickMaxHeight = col.transform.localScale.y;
            float brickMaxWidth = col.transform.localScale.x;

            float absoluteBallX = this.transform.position.x;
            float absoluteBallY = this.transform.position.y;

            float absoluteBrickX = col.transform.position.x;
            float absoluteBrickY = col.transform.position.y;

            if (absoluteBrickX + brickMaxWidth / 2 < absoluteBallX ||
                absoluteBrickX - brickMaxWidth / 2 > absoluteBallX
                )
            {
                speedX = -speedX;
            }

            if (absoluteBrickY + brickMaxHeight / 2 < absoluteBallY ||
                absoluteBrickY - brickMaxHeight / 2 > absoluteBallY
                )
            {
                speedY = -speedY;
            }
        }
    }

}
