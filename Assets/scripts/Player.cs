using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private int expandPercent = 40;
    private int expandCount = 0;
    public float speed;


    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ExpandCounter();
    }

    void Move()
    {
        //float moveX = Input.GetAxisRaw("Horizontal");
        //this.transform.Translate(Mathf.Clamp(moveX, -9, 9) * speed, 0f, 0f);

        float xPos = transform.position.x + (Input.GetAxisRaw("Horizontal") * speed);
        transform.position = new Vector3(Mathf.Clamp(xPos, -9f, 9f), -4.5f, 0f);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            transform.Translate(touchDeltaPosition.x / 28, 0f, 0f);

        }
    }

    public void Expand()
    {
        if (expandCount == 0)
        {
            transform.localScale += new Vector3((transform.localScale.x * expandPercent / 100), 0f, 0f);
        }
        expandCount = 30 * 60; // sec
    }

    void ExpandCounter()
    {
        if (expandCount < 1) return;
        expandCount--;
        if (expandCount == 0) Constrict();
    }

    void Constrict()
    {
        transform.localScale -= new Vector3((transform.localScale.x * expandPercent / 2 / 100), 0f, 0f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "ball")
        {
            //GameManagerScript.instance.CheckAndGoNextLevel();
        }
    }
}
