using UnityEngine;
using System.Collections;

public class Brick3Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = GameManagerScript.brick3Color;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
