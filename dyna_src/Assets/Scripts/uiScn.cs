using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiScn : MonoBehaviour {
	
	public Text score;
	
	public void Start()
	{	
		if( SceneManager.GetActiveScene().name == "ui")
		{	
			score.text = singeletonData.Instance.p2_Win + " - " + singeletonData.Instance.p1_Win ;
		}
	}
	
	public void SceneLoad(string nam)
    {	
		print(nam);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		SceneManager.LoadScene(nam);
		Time.timeScale = 1f;
    }
}
