using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public float brickCanvasMinRowPosition;
    public float brickCanvasMinColPosition;
    public int level;
    private float brickRowStep = 0.6f;
    private float brickColStep = 1.1f;
    public GameObject[] brickTypes;

    private string[] levels = {
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbbbbbbbbbbbbbbbb" ,

            "bbbb          bbbb" +
            "bbbb          bbbb" +
            "bbbb          bbbb" +
            "bbbbbbbbbbbbbbbbbb" +
            "bbbb ddddddd bbbbb" +
            "bbbb ddddddd bbbbb" +
            "bbbb ddddddd bbbbb" +
            "bbbb ddddddd bbbbb" +
            "bbbb fffffff bbbbb" +
            "bbbb fffffff bbbbb" +
            "     bbbbbbb      " +
            "     bbbbbbb      " +
            "     bbbbbbb      " +
            "     bbbbbbb      "


    };

    private int maxBrickOnLine = 18;

    // Use this for initialization
    void Start()
    {
         CreateLevel(this.level);
       // Instantiate(brickTypes[0], new Vector2(0f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateLevel(int level)
    {
        float x = brickCanvasMinColPosition;
        float y = brickCanvasMinRowPosition;
        int index = 0;
        foreach (char brick in levels[level])
        {
            if (brick == 'b')
            {
                Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
            }
            if (brick == 'd')
            {
                Instantiate(brickTypes[1], new Vector2(x, y), Quaternion.identity);
            }
            if (brick == 'f')
            {
                Instantiate(brickTypes[2], new Vector2(x, y), Quaternion.identity);
            }
            x += brickColStep;
            
            index++;
            if (index == maxBrickOnLine)
            {
                y -= brickRowStep;
                x = brickCanvasMinColPosition;
                index = 0;
            }
        }
    }
}
