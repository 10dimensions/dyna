using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour 
{	
	public bool hitMetal = false;
	public void OnTriggerEnter(Collider other)
	{	
		switch(other.gameObject.tag)
		{
			case "metal":
				Destroy(this.gameObject);
				break;

			case "glass":

				Destroy(other.gameObject);
				Data.Instance.powerUpInsta(other.gameObject.transform);
				Destroy(this.gameObject);
				
				break;

			case "Player":

				Destroy(this.gameObject);
				break;

		}

	}

	
}