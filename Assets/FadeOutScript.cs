using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScript : MonoBehaviour
{
    public float timer;
    private Image alpha;


    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;

        Debug.Log(timer);
    }

    
}

