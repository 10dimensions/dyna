using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class singeletonData : MonoBehaviour {

	private static singeletonData _instance;

    public static singeletonData Instance { get { return _instance; } }

	public int p1_Win=0;
	public int p2_Win=0;

	private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
			Debug.Log("singelton destroyed");
        } 
		
		else 
		{
            _instance = this;
        }
		
		DontDestroyOnLoad(gameObject);

    }

    public void SceneLoad(string nam)
    {	
        SceneManager.LoadScene(nam);
    }

}