using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {

	public Transform[] laserBeams;
	
	void Start () 
	{
		//laserBeams = this.gameObject.GetComponentsInChildren<Transform>();
		StartCoroutine(laserShoot());
	}
	
	
	void Update () 
	{
		
	}

	public IEnumerator laserShoot()
	{
		foreach(Transform t in laserBeams)
		{
			iTween.ScaleTo(t.gameObject, new Vector3(t.localScale.x, t.localScale.y, 1.4f), 10f);
		}


		yield return null;
	}

	void OnDisable()
	{
		foreach(Transform t in laserBeams)
		{
			t.localScale = new Vector3(t.localScale.x, t.localScale.y, 0.1f);
		}
	}
}
