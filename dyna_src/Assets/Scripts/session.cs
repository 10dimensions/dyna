using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class session : MonoBehaviour {

	public GameObject[] pUps;
	public Text timer;
	public GameObject goverPanel;

	public void Start()
	{
		StartCoroutine(StartCountdown(55));
		Debug.Log("countdown starts");
	}

	public IEnumerator StartCountdown(float countdownValue)
	{	

		float currCountdownValue = countdownValue;
		while (currCountdownValue > 0)
		{
			yield return new WaitForSeconds(1.0f);
			currCountdownValue--;

			if(currCountdownValue>9)
				timer.text = "00 : "+currCountdownValue.ToString();
			else
				timer.text = "00 : 0"+currCountdownValue.ToString();
		}

		goverPanel.SetActive(true);

		Time.timeScale =0f;
	}

	public void powerUpInsta(Transform glass)
	{	
		int rand = Random.Range(0,pUps.Length);
		GameObject pUpInsta = Instantiate(pUps[rand], glass.localPosition, pUps[0].transform.localRotation) as GameObject;
		pUpInsta.SetActive(true);
	}

	public void SessionOver(int pTNum)
	{
		if(pTNum == 1)
			singeletonData.Instance.p2_Win++ ;

		else if(pTNum == 2)
			singeletonData.Instance.p1_Win++ ;


		goverPanel.SetActive(true);

		Time.timeScale =0f;

	}

	 public void SceneLoad(string nam)
    {
        SceneManager.LoadScene(nam);
    }
}