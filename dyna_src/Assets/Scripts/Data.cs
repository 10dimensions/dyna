using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

	private static Data _instance;

    public static Data Instance { get { return _instance; } }

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
}
