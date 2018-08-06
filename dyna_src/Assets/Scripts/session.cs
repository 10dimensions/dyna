using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class session : MonoBehaviour {

	public GameObject[] pUps;
	public Text timer;
	public int timeinSec=50;
	public GameObject goverPanel;
	public Text score;

	public void Start()
	{
		StartCoroutine(StartCountdown());	
	}
	

	//timer clock
	public IEnumerator StartCountdown()
	{	
		Debug.Log("countdown starts");
		while (timeinSec > 0)
		{
			yield return new WaitForSeconds(1.0f);
			timeinSec--;

			if(timeinSec>9)
				timer.text = "00 : "+timeinSec.ToString();
			else
				timer.text = "00 : 0"+timeinSec.ToString();
		}
		
		score.text = singeletonData.Instance.p1_Win + " - " + singeletonData.Instance.p2_Win ;
		goverPanel.SetActive(true);

		Time.timeScale =0f;
	}
	
	//break glass
	public void powerUpInsta(Transform glass)
	{	
		int rand = Random.Range(0,pUps.Length);
		GameObject pUpInsta = Instantiate(pUps[rand], glass.localPosition- new Vector3(0f,-0.4f,0f), pUps[0].transform.localRotation) as GameObject;
		pUpInsta.SetActive(true);
	}
	
	//session over stats
	public void SessionOver(int pTNum)
	{
		if(pTNum == 1)
		{
			singeletonData.Instance.p2_Win++ ;
		}

		else if(pTNum == 2)
		{
			singeletonData.Instance.p1_Win++ ;
		}
		
		
		score.text = singeletonData.Instance.p2_Win + " - " + singeletonData.Instance.p1_Win ;
		goverPanel.SetActive(true);
		

		Time.timeScale =0f;

	}

}