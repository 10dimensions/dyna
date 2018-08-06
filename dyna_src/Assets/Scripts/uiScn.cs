using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiScn : MonoBehaviour {

	public void SceneLoad(string nam)
    {	
		print(nam);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		SceneManager.LoadScene(nam);
		Time.timeScale = 1f;
    }
}
