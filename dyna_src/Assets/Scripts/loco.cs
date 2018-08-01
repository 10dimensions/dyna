using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	private GameObject character;
	void Start () 
	{
		character = this.gameObject;	
	}
	
	void Update () {
		
		if (Input.GetKey(KeyCode.RightArrow))
		{
			
			Vector3 newPosition = character.transform.position;
			newPosition.x++;
			character.transform.position = newPosition;			
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			
			Vector3 newPosition = character.transform.position;
			newPosition.x--;
			character.transform.position = newPosition;
			
		}

		if (Input.GetKey(KeyCode.UpArrow)){
			
			Vector3 newPosition = character.transform.position;
			newPosition.z++;
			character.transform.position = newPosition;			
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			
			Vector3 newPosition = character.transform.position;
			newPosition.z--;
			character.transform.position -= newPosition;
			
		}
		
	}
}
