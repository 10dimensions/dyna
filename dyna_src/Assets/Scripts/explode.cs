using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {

	public Transform[] laserBeams;
	public float scaleLength = 1.4f;   //beam length
	
	void Start () 
	{
		//laserBeams = this.gameObject.GetComponentsInChildren<Transform>();
		laserShoot();
	}
	
	
	void Update () 
	{
		
	}

	public void laserShoot()
	{
		foreach(Transform t in laserBeams)
		{
			//iTween.ScaleTo(t.gameObject, new Vector3(t.localScale.x, t.localScale.y, 1.4f), 0.7f);
			StartCoroutine(laserShootI(t, 0.15f)) ;
		}
		
	}

	public IEnumerator laserShootI(Transform laser,float dur)
	{	
		Vector3 originalScale = laser.transform.localScale;
        Vector3 destinationScale = new Vector3(originalScale.x, originalScale.y, 1.4f);
         
         float currentTime = 0.0f;

		 //bool hitMetal = laser.gameObject.transform.GetChild(0).GetComponent<laser>().hitMetal;
         
         do
         {	
			//if(hitMetal)  
				//yield break;
			
             laser.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / dur);
             currentTime += Time.deltaTime;
             yield return null;
         } 
		 while (currentTime <= dur );

		yield return new WaitForSeconds(dur+0.01f);

		Destroy(this.gameObject);
	}

	/* 
	void OnDisable()
	{
		foreach(Transform t in laserBeams)
		{
			t.localScale = new Vector3(t.localScale.x, t.localScale.y, 0.1f);
		}
	}
	*/

}