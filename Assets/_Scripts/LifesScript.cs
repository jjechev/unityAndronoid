using UnityEngine;
using System.Collections;

public class LifesScript : MonoBehaviour 
{
	public GameObject[] lifePicture;

	private int numberOfLifes;

	// Use this for initialization
	void Start () 
	{
		numberOfLifes = GameManagerScript.instance.lifes;
		PrintLifes();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (numberOfLifes != GameManagerScript.instance.lifes) 
		{
			PrintLifes();
		}
			
	}

	void PrintLifes()
	{
		numberOfLifes = GameManagerScript.instance.lifes;
		for (int i = 0; i < 6; i++) 
		{
			lifePicture[i].SetActive(false);
		}

		for (int i = 0; i < numberOfLifes && i < 5; i++) 
		{
			lifePicture[i].SetActive(true);
		}
	}
}
