using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieScrip : MonoBehaviour
{
    public GameObject game;

    private UnityEngine.Video.VideoPlayer movie;

    void Start()
    {
        game.SetActive(false);
        //fadeOut.SetActive(false);
        movie = GetComponent<UnityEngine.Video.VideoPlayer>();
        movie.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!movie.isPlaying)
        {
            game.SetActive(true);
            //fadeOut.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

}

