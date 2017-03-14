using UnityEngine;
//using System;

public class BallScript : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource downWallSound;
    private AudioSource playerSound;

    private AudioSource sound;

    // move
    public float speedX;
    public float speedY;
    public float ballInitialVelocityX;
    public float ballInitialVelocityY;

    // temp var for stick ball
    private float tempBallVelocityX = 0;
    private float tempBallVelocityY = 0;

    //rb
    private Rigidbody rb;

    //start position
    float ballStartPositionX;
    float ballStartPositionY;
    private bool ballInPlay;
    //insance
    public static BallScript instance;

    //stick ball
    public bool stickBall = false;
    int stickBallCounter = 0;

    //inc & dec speed
    float ballIncSpeedOnCollision = 1.005f;
    float ballDecSpeed = 0.2f;

    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        downWallSound = GameObject.FindGameObjectWithTag("wallDown").GetComponent<AudioSource>();
        playerSound = GameObject.FindGameObjectWithTag("player").GetComponent<AudioSource>();

        ballStartPositionX = this.transform.position.x;
        ballStartPositionY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        moveBall();
        StickBallCounter();
    }


    void moveBall()
    {
        if (rb.velocity.x != 0 && rb.velocity.y != 0 && ballInPlay == false)
        {
            transform.parent = null;
        }

        if (ballInPlay == false && Input.GetButtonDown("Fire1"))
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            //  rb.AddForce(new Vector3(ballInitialVelocityX, ballInitialVelocityY, 0));

            if (tempBallVelocityX == 0 && tempBallVelocityY == 0)
            {
                rb.velocity = new Vector3(ballInitialVelocityX, ballInitialVelocityY, 0);
            }
            else
            {   // stick ball
                rb.velocity = new Vector3(tempBallVelocityX, tempBallVelocityY, 0);
            }
        }
    }

    public void resetBallPosition()
    {
        transform.parent = GameObject.FindGameObjectWithTag("paddle").transform;
        transform.position = new Vector3(GameObject.FindGameObjectWithTag("paddle").transform.position.x + 0.5f, ballStartPositionY, 0);
        rb.velocity = Vector3.zero;
        //waitingTimeBeforeStartMoving = 200;
        ballInPlay = false;
        //reset stick ball
        tempBallVelocityX = 0;
        tempBallVelocityY = 0;
    }

    public void OnCollisionEnter(Collision col)
    {
        // Debug.Log(col.collider.name);
        ChangeDirection(col);
    }

    public void SetStickBall()
    {
            stickBall = true;
            stickBallCounter = 3600;
    }

    void StickBallCounter()
    {
        if (stickBallCounter < 1) return;
        stickBallCounter--;
        if (stickBallCounter == 0) stickBall = false;
    }

    public void DecSpeed()
    {
        if (ballInPlay)
        {
            rb.velocity = new Vector3(
                Mathf.Sign(rb.velocity.x) * Mathf.Clamp(Mathf.Abs(rb.velocity.x) * ballDecSpeed, ballInitialVelocityX * 0.8f, ballInitialVelocityX * 10),
                Mathf.Sign(rb.velocity.y) * Mathf.Clamp(Mathf.Abs(rb.velocity.y) * ballDecSpeed, ballInitialVelocityY * 0.8f, ballInitialVelocityY * 10),
                0
            );
        }
        else
        {
            tempBallVelocityX = Mathf.Sign(tempBallVelocityX) * Mathf.Clamp(Mathf.Abs(tempBallVelocityX) * ballDecSpeed, ballInitialVelocityX, ballInitialVelocityX * 10);
            tempBallVelocityY = Mathf.Sign(tempBallVelocityY) * Mathf.Clamp(Mathf.Abs(tempBallVelocityY) * ballDecSpeed, ballInitialVelocityY, ballInitialVelocityY * 10);

        }
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

        speedX = Mathf.Sign(speedX) * Mathf.Clamp(Mathf.Abs(speedX), ballInitialVelocityX / 2, ballInitialVelocityX * 2) * ballIncSpeedOnCollision;
        speedY = Mathf.Sign(speedY) * Mathf.Clamp(Mathf.Abs(speedY), ballInitialVelocityY / 2, ballInitialVelocityY * 2) * ballIncSpeedOnCollision;
        //speedY = Mathf.Sign(speedY) * ballInitialVelocityY;

        speedX += Random.Range(0.01f, 0.03f) - 0.02f;


        rb.velocity = Vector3.zero;
        rb.velocity = new Vector3(speedX, speedY, 0);

        if (col.collider.tag == "wallDown")
        {
            downWallSound.Play();
            GameManagerScript.instance.LostLife();
        }


        if (col.collider.tag == "player")
        {
            playerSound.Play();
            GameObject paddle = GameObject.FindGameObjectWithTag("paddle");
            if (transform.position.y > paddle.transform.position.y + 0.4f)
            {

                //stickbal
                if (stickBall && ballInPlay)
                {
                    //sey currnet velocity
                    tempBallVelocityX = rb.velocity.x;
                    tempBallVelocityY = rb.velocity.y;

                    transform.parent = GameObject.FindGameObjectWithTag("paddle").transform;
                    rb.velocity = Vector3.zero;
                    ballInPlay = false;
                }
            }
        }

    }

    public void PlaySounds(Collision col)
    {

    }
}
