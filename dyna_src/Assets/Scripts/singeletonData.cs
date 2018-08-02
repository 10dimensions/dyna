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
        } 
		
		else 
		{
            _instance = this;
        }
    }

    public void SceneLoad(string nam)
    {
        SceneManager.LoadScene(nam);
    }

}