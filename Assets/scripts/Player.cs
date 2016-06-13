using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "ball")
        {
            //GameManagerScript.instance.CheckAndGoNextLevel();
        }
    }
}
