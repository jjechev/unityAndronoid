using UnityEngine;
using System;

public class BallScript : MonoBehaviour
{
    private AudioSource sound;

    public float speedX;
    public float speedY;
    public float ballInitialVelocity = 600f;
    
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
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }

    public void resetBallPosition()
    {
        transform.position = new Vector3(GameObject.FindGameObjectWithTag("player").transform.position.x, ballStartPositionY, 0);
        waitingTimeBeforeStartMoving = 200;
        speedY = Math.Abs(speedY);
    }

    public void OnCollisionEnter(Collision col)
    {
       // Debug.Log(col.collider.name);
        ChangeDirection(col);
    }

    public void ChangeDirection(Collision col)
    {
        sound.Play();

       //if (col.collider.tag == "player")
       //{
       //    speedX = -((col.transform.position.x - this.transform.position.x) / col.transform.localScale.x / 5);
       //    speedY = -speedY;
       //}

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
