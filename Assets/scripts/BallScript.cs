using UnityEngine;
using System;

public class BallScript : MonoBehaviour
{
    private AudioSource sound;

    public float speedX;
    public float speedY;
    public float ballInitialVelocityX;
    public float ballInitialVelocityY;
    
    private Rigidbody rb;

    float ballStartPositionX;
    float ballStartPositionY;
    private bool ballInPlay;
    
    public static BallScript instance;

    int waitingTimeBeforeStartMoving = 200;

    void Awake()
    {
        instance = this;
         rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();

        ballStartPositionX = this.transform.position.x;
        ballStartPositionY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        moveBall();
    }

    void moveBall()
    {
        if ( ballInPlay == false && Input.GetButtonDown("Fire1"))
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
          //  rb.AddForce(new Vector3(ballInitialVelocityX, ballInitialVelocityY, 0));
            rb.velocity = new Vector3(ballInitialVelocityX, ballInitialVelocityY, 0);
        }
    }

    public void resetBallPosition()
    {
        transform.position = new Vector3(GameObject.FindGameObjectWithTag("player").transform.position.x + 0.5f, ballStartPositionY, 0);
        rb.velocity = Vector3.zero;
        waitingTimeBeforeStartMoving = 200;
        ballInPlay = false;
        transform.parent = GameObject.FindGameObjectWithTag("player").transform;
    }

    public void OnCollisionEnter(Collision col)
    {
       // Debug.Log(col.collider.name);
        ChangeDirection(col);
    }

    public void ChangeDirection(Collision col)
    {
        sound.Play();

        speedX = rb.velocity.x;
        speedY = rb.velocity.y;

        if (col.collider.tag == "player")
        {
            speedX = -((col.transform.position.x - this.transform.position.x) / col.transform.localScale.x / 5);
            speedX = ballInitialVelocityX * speedX * 10;
        }

        //if (Mathf.Abs(speedX) < Mathf.Abs(speedY) || Mathf.Abs(speedY) < 0.5f)
        //{
        //    speedX = Mathf.Sign(speedX) * Mathf.Abs(speedY);
        //}

        speedX = Mathf.Sign(speedX) * Mathf.Clamp(Mathf.Abs(speedX), ballInitialVelocityX * 0.5f, ballInitialVelocityX);
        speedY = Mathf.Sign(speedY) * Mathf.Clamp(Mathf.Abs(speedY), ballInitialVelocityY * 0.5f, ballInitialVelocityY);


        rb.velocity = Vector3.zero;
        rb.velocity = new Vector3(speedX, speedY, 0);

        if (col.collider.tag == "wallDown")
        {
            GameManagerScript.instance.LostLife();
        }


        //if (col.collider.tag == "wallUp")
        //{
        //    speedY = -speedY;
        //}

        //if (col.collider.tag == "wallDown")
        //{
        //    speedY = -speedY;
        //    GameManagerScript.instance.LostLife();
        //}

        //if (col.collider.tag == "wallLeft" || col.collider.tag == "wallRight")
        //{
        //    speedX = -speedX;
        //}

        //if (col.collider.tag == "brick")
        //{
        //    float brickMaxHeight = col.transform.localScale.y;
        //    float brickMaxWidth = col.transform.localScale.x;

        //    float absoluteBallX = this.transform.position.x;
        //    float absoluteBallY = this.transform.position.y;

        //    float absoluteBrickX = col.transform.position.x;
        //    float absoluteBrickY = col.transform.position.y;

        //    if (
        //            absoluteBrickX + brickMaxWidth / 2 < absoluteBallX ||
        //            absoluteBrickX - brickMaxWidth / 2 > absoluteBallX
        //        )
        //    {
        //        speedX = -speedX;
        //    }

        //    if (
        //            absoluteBrickY + brickMaxHeight / 2 < absoluteBallY ||
        //            absoluteBrickY - brickMaxHeight / 2 > absoluteBallY
        //        )
        //    {
        //        speedY = -speedY;
        //    }
        //}
    }

}
