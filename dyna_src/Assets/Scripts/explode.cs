using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {

	private Transform[] laserBeams;
	
	void Start () 
	{
		laserBeams = this.gameObject.GetComponentsInChildren<Transform>();
	}
	
	
	void Update () 
	{
		
	}
}
