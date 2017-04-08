using UnityEngine;
using System.Collections;

public class Brick3Script : MonoBehaviour 
{
	Animation anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animation>();
        //GetComponent<Renderer>().material.color = GameManagerScript.brick3Color;
    }
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnCollisionEnter(Collision coll)
	{
		anim.Play();
	}
}
