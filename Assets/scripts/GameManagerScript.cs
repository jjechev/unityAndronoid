using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public Text scoreText;
    public Text lifesText;

    public static int level = 1;

    public static Color brick1Color;
    public static Color brick2Color;
    public static Color brick3Color;
    public Color brick1ColorEditor;
    public Color brick2ColorEditor;
    public Color brick3ColorEditor;

    public float brickCanvasMinRowPosition;
    public float brickCanvasMinColPosition;
    private float brickRowStep = 0.6f;
    private float brickColStep = 1.1f;
    private int maxBrickOnLine = 18;

    public GameObject[] brickTypes;

    private static int brickOnLevel;

    private int score;
    public int lifes;

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
            
            //level 1
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "    s       b     " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " ,

            //level 1
            "                  " +
            "                  " +
            "                  " +
            "  bbbbbbbbbbbbbb  " +
            "  bbbbbbbbbbbbbb  " +
            "  bbbbbbbbbbbbbb  " +
            "  bbbbbbbbbbbbbb  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " ,

            //level 2
            "                  " +
            "                  " +
            "                  " +
            "  bbbbbbbbbbbbbb  " +
            "  bbbbbbbbbbbbbb  " +
            "  bbbddddddddbbb  " +
            "  dddddddddddddd  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " ,

            //level 3
            "                  " +
            "                  " +
            "bbbb              " +
            "bbbbbb            " +
            "bbbbbbbb          " +
            "bbbbbbbbbb        " +
            "bbbbbbbbbbbb      " +
            "dddddddddddddd    " +
            "ssssssssssssssss  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " ,


            "                  " +
            "                  " +
            "  dddddddddddddd  " +
            "  bbbbbbbbbbbbbb  " +
            "  bbbbbbbbbbbbbb  " +
            "  ssbbssbbssbbss  " +
            "  ssbbssbbssbbss  " +
            "  bbbbbbbbbbbbbb  " +
            "  bbbbbbbbbbbbbb  " +
            "  dddddddddddddd  " +
            "                  " +
            "                  " +
            "                  " +
            "                  " ,



    };

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Init();
        CreateLevel(level);
        // Instantiate(brickTypes[0], new Vector2(0f, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        PrintOnScreen();

    }

    void Init()
    {
        brick1Color = brick1ColorEditor;
        brick2Color = brick2ColorEditor;
        brick3Color = brick3ColorEditor;
    }

    void CreateLevel(int level)
    {
        float x = brickCanvasMinColPosition;
        float y = brickCanvasMinRowPosition;
        int index = 0;
        foreach (char brick in levels[level])
        {
            if (brick == 'b') // 1 hit
            {
                brickOnLevel++;
                Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
            }
            if (brick == 'd') // 2 hit
            {
                brickOnLevel++;
                Instantiate(brickTypes[1], new Vector2(x, y), Quaternion.identity);
            }
            if (brick == 's') // solid
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
        Debug.Log(brickOnLevel);
    }

    public static void decreaseBricks()
    {
        brickOnLevel--;
        Debug.Log(brickOnLevel);
    }

    public void CheckAndGoNextLevel()
    {
        if (brickOnLevel < 1)
        {
            level++;
            DestructionOfTheRemainingBricks();
            instance.CreateLevel(level);
        }
    }

    private void DestructionOfTheRemainingBricks()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("brick");
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
    }

    public void IncScore(int type)
    {
        switch (type)
        {
            default:
                score += 100;
                break;
        }
    }

    private void PrintOnScreen()
    {
        PrintLifes();
        scoreText.text = "Score: " + score;

    }

    private void PrintLifes()
    {
        string currentLifes = "";
        for (int i = 0; i < lifes; i++)
        {
            currentLifes += "-";
        }
        lifesText.text = currentLifes;
    }

    public void LostLife()
    {
        lifes--;
        //BallScript.instance.resetBallPosition();
    }
}
