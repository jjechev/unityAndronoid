using UnityEngine;
//using System;
using System.Text;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public Text scoreText;
    public Text lifesText;
	public TextMesh newScoreText;

    public static int numberOfAliens = 0;


    public int levelEditor;
    public static int level = 5;

    public static Color brick1Color;
    public static Color brick2Color;
    public static Color brick3Color;
    public Color brick1ColorEditor;
    public Color brick2ColorEditor;
    public Color brick3ColorEditor;
    public List<GameObject> aliens;

    public Color[] brickColorEditor;

    public float brickCanvasMinRowPosition;
    public float brickCanvasMinColPosition;
    private float brickRowStep = 0.6f;
    private float brickColStep = 1.1f;
    private int maxBrickOnLine = 18;

    public GameObject[] brickTypes;

    private static int brickOnLevel;
    private float timer;
    public float timeToAliens = 3f;

    private int score;
    public int lifes;

    private string[] levels;
  
    void Awake()
    {
        instance = this;
        levels = Levels.levels;
		level = levelEditor;
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
        CreateAlien(aliens[Random.Range(0,aliens.Count)]);
    }

    void Init()
    {
        brick1Color = brick1ColorEditor;
        brick2Color = brick2ColorEditor;
        brick3Color = brick3ColorEditor;
    }

    void CreateLevel(int level)
    {
        DestructionOfTheRemainingObjects("brick");
        DestructionOfTheRemainingObjects("alien");
        
        float x = brickCanvasMinColPosition;
        float y = brickCanvasMinRowPosition;
        int index = 0;

        brickOnLevel = 0;
        foreach (char brickType in levels[level])
        {
            if (brickType == 'w') // 1 hit white
            {
                brickOnLevel++;
                GameObject brickInstance = (GameObject) Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
                brickInstance.GetComponent<Renderer>().material.color = brickColorEditor[0];
            }

            if (brickType == 'o') // 1 hit orange
            {
                brickOnLevel++;
                GameObject brickInstance = (GameObject)Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
                brickInstance.GetComponent<Renderer>().material.color = brickColorEditor[1];
            }

            if (brickType == 'c') // 1 hit cyan
            {
                brickOnLevel++;
                GameObject brickInstance = (GameObject)Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
                brickInstance.GetComponent<Renderer>().material.color = brickColorEditor[2];
            }

            if (brickType == 'g') // 1 hit green
            {
                brickOnLevel++;
                GameObject brickInstance = (GameObject)Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
                brickInstance.GetComponent<Renderer>().material.color = brickColorEditor[3];
            }

            if (brickType == 'r') // 1 hit red
            {
                brickOnLevel++;
                GameObject brickInstance = (GameObject)Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
                brickInstance.GetComponent<Renderer>().material.color = brickColorEditor[4];
            }

            if (brickType == 'b') // 1 hit blue
            {
                brickOnLevel++;
                GameObject brickInstance = (GameObject)Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
                brickInstance.GetComponent<Renderer>().material.color = brickColorEditor[5];
            }

            if (brickType == 'p') // 1 hit за purple
            {
                brickOnLevel++;
                GameObject brickInstance = (GameObject)Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
                brickInstance.GetComponent<Renderer>().material.color = brickColorEditor[6];
            }

            if (brickType == 'y') // 1 hit green
            {
                brickOnLevel++;
                GameObject brickInstance = (GameObject)Instantiate(brickTypes[0], new Vector2(x, y), Quaternion.identity);
                brickInstance.GetComponent<Renderer>().material.color = brickColorEditor[7];
            }

            if (brickType == 'd') // 2 hit
            {
                brickOnLevel++;
                Instantiate(brickTypes[1], new Vector2(x, y), Quaternion.identity);
            }
            if (brickType == 'u') // solid
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

            if (levels.Length == level)
            {
                level = 1;
            }

            BallScript.instance.resetBallPosition();
            instance.CreateLevel(level);
			numberOfAliens = 0;
        }
    }

    private void DestructionOfTheRemainingObjects(string objectTagName)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(objectTagName);
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
    }

    

    public void IncScore(int addScore)
    {
        score += addScore;

    }

    public void IncLife(int addLifes)
    {
        lifes += addLifes;
    }

    private void PrintOnScreen()
    {
        PrintLifes();
        scoreText.text = "SCORE: " + score;
		newScoreText.text = "SCORE: " + score;
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
        if (lifes == 0)
        {
            level = 1;
            CreateLevel(level);
        }

        BallScript.instance.resetBallPosition();
    }

    void CreateAlien(GameObject alien)
    {
        timer += Time.deltaTime;
        float randomX = Random.Range(-9f, 10f);
        float randomY = Random.Range(0, 7f);
        if (timer >= timeToAliens)
        {
            Instantiate(alien, new Vector2(randomX, randomY), Quaternion.identity);
            timer = 0;
        }
       
    }
}
