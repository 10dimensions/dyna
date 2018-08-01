using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour 
{	
	public bool hitMetal = false;
	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="metal")
		{
			Destroy(this.gameObject);
		}

		else if(other.gameObject.tag == "glass")
		{
			

			Destroy(this.gameObject);

		}

		else if(other.gameObject.tag=="Player")
		{	
			// game over, change game state

			Destroy(this.gameObject);
		}
	}
	
}
