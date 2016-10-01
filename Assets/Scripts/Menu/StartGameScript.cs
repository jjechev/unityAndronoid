using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour 
{
	public GameObject player;

	void Awake()
	{
		Time.timeScale = 0;
		player.SetActive (false);
	}

	public void StartGame()
	{
		Time.timeScale = 1;
		gameObject.SetActive (false);
		player.SetActive (true);
	}

	//IEnumerator WaitToGo()
	//{
	//	SceneManager.UnloadScene (0);
	//	yield return new WaitForSeconds (3f);
	//	SceneManager.LoadScene ("game");
	//}

}
