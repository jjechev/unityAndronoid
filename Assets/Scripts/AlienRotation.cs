using UnityEngine;
using System.Collections;

public class AlienRotation : MonoBehaviour
{
    
    public float rotationSpeed;
    public ParticleSystem particle;

    public float velocity;

    private float timer;
    private float timerToDestroy;
    private float timeToDestroyIfSamePlace = 0.5f;

    public float timeTochangeDirection = 3f;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (GameManagerScript.numberOfAliens > 3)
        {
            GameManagerScript.numberOfAliens--;
            Destroy(gameObject);
        }
        GameManagerScript.numberOfAliens++;
        Debug.Log(GameManagerScript.numberOfAliens);

    }

    // Update is called once per frame
    void Update()
    {
        timerToDestroy += Time.deltaTime;
        if (rb.velocity.x > 1 || rb.velocity.y > 1 )
        {
            ChangeDirection();
        }
        timer += Time.deltaTime;
        if (timer >= timeTochangeDirection)
        {
            ChangeDirection();
            timer = 0;
        }
        transform.Rotate(1f * rotationSpeed, 1f * rotationSpeed, 1f * rotationSpeed);
    }

    void ChangeDirection()
    {
        int randomX = Random.Range(-1, 2);
        int randomY = Random.Range(-1, 2);

        if (randomX != 0 && randomY != 0)
        {
            rb.velocity = new Vector2(randomX, randomY);
        }

    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "ball" || other.collider.tag == "player")
        {
            Instantiate(particle,transform.position, Quaternion.identity);
            GameManagerScript.numberOfAliens--;
            Destroy(gameObject);
        }
        else if (other.collider.tag == "wall" || other.collider.tag == "alien")
        {
            //GameManagerScript.numberOfAliens--;
            //Destroy(gameObject);
        }
        else if (timerToDestroy < timeToDestroyIfSamePlace)
        {
            GameManagerScript.numberOfAliens--;
            timerToDestroy = 1;
            Destroy(gameObject);
        }
    }
}
