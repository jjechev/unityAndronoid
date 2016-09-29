using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private float expandPercent = 1.4f;
    private float expandTimer = -100;
    public float speed;
    Transform child;
    Transform childX;

    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        child = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        childX = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
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
        transform.position = new Vector3(Mathf.Clamp(xPos, -8.2f, 8.2f), -4.5f, 0f);

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
        if (expandTimer < 0)
        {
            child.transform.localScale = new Vector3((child.transform.localScale.x * expandPercent), child.transform.localScale.y, child.transform.localScale.z);
        }
        expandTimer = 30;
    }

    void ExpandCounter()
    {
        if (expandTimer < 0)
        {
            return;
        }

        expandTimer -= Time.deltaTime;

        if (expandTimer < 0)
        {
            Constrict();
            expandTimer = -333;
        }
    }

    void Constrict()
    {
        child.transform.localScale = new Vector3((child.transform.localScale.x / expandPercent), child.transform.localScale.y, child.transform.localScale.z);
        Debug.Log(childX.localScale.x);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "ball")
        {

            //GameManagerScript.instance.CheckAndGoNextLevel();
        }
    }
}
