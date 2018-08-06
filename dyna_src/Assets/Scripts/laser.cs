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
				GameObject sessioObj = GameObject.FindWithTag("session"); 
				sessioObj.GetComponent<session>().powerUpInsta(other.gameObject.transform);
				Destroy(this.gameObject);

				break;

		}
	}
}