using UnityEngine;
using System.Collections;

public class paddle : MonoBehaviour
{

    public float wallRotationSpeed = 1f;


    

    void Update()
    {
		transform.Rotate ( 0f,0f,5 * wallRotationSpeed);

    }
}