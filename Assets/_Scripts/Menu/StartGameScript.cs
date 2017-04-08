using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour 
{
	public GameObject player;
    public GameObject andronoidText;
    public GameObject scoreText;
    public AudioSource audios;
    public Light halo;
    public float haloSpeed;
    bool haloBig;
    float haloRange;
    public static StartGameScript instance;


    void Awake()
	{
        instance = this;
		Time.timeScale = 0;
		player.SetActive (false);
    }

    void Start()
    {
        
        haloRange = 5f;
    }

    void Update()
    {
       
        if (haloRange > 250)
        {
            haloBig = true;
        }
        if (haloBig)
        {
            haloRange -= 0.5f;
        }
        if (haloRange < 4)
        {
            haloBig = false;
        }
        if (!haloBig)
        {
            haloRange += 0.5f;
        }
        halo.range = haloRange;
    }
    

	public void StartGame()
	{
        audios.Play();
        scoreText.SetActive(true);
        Destroy(andronoidText);
		Time.timeScale = 1;
        gameObject.SetActive(false);
        player.SetActive (true);
        
	}

	//IEnumerator WaitToGo()
	//{
	//	SceneManager.UnloadScene (0);
	//	yield return new WaitForSeconds (3f);
	//	SceneManager.LoadScene ("game");
	//}

}
