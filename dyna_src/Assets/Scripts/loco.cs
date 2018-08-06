using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loco : MonoBehaviour {

	// Use this for initialization
	private GameObject character;
	private float speed= 4.0f;
	public int pNum;
	
	public GameObject explosive;
	public int explosiveCount=1;
	public bool explAvailable=true;
	
	public float beamLength=1.4f;
	
	public GameObject bolt;
	public GameObject timer;
	public Text expl;

	void Start () 
	{
		character = this.gameObject;	
	}
	
	void Update () 
	{
		if(pNum == 1)
		{	
			p1Move();           //locomotion
		}

		else if(pNum==2)
		{
			p2Move();
		}
			
	}
	

	public void p1Move()
	{
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left* speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			transform.position += Vector3.back* speed * Time.deltaTime;
		}


		if(Input.GetKey(KeyCode.RightShift))
		{
			if(explAvailable)
			{
				StartCoroutine(explRoutine());
			}
		}
	}


	public void p2Move()
	{
		if (Input.GetKey(KeyCode.D)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A)){
			transform.position += Vector3.left* speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.W)){
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S)){
			transform.position += Vector3.back* speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftShift))
		{
			if(explAvailable)
			{
				StartCoroutine(explRoutine());
				Debug.Log("routine");
			}
			
		}

	}
	
	//inst laser explosive
	public IEnumerator explRoutine()
	{	
		
		GameObject explObj = Instantiate(explosive, this.gameObject.transform.position, explosive.transform.rotation) as GameObject;
		explObj.GetComponent<explode>().scaleLength = beamLength;
		explObj.SetActive(true);
		
		explAvailable=false;
		float t=0f;;
		
		if(explosiveCount == 2)
		{t=1f; }
		else 
		{t=2.5f;}
		
		explosiveCount--;
		expl.text = explosiveCount.ToString();
		
		yield return new WaitForSeconds(t);
		
		
		explAvailable=true;
		
		if(explosiveCount == 0)
		{
			explosiveCount++;
			expl.text = explosiveCount.ToString();
		}
	}
	
	
	//speed powerUp
	public IEnumerator speedPU()
	{	 
		speed*=2f;
		timer.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
	
		timer.transform.parent.gameObject.SetActive(true);
		iTween.ValueTo(timer, iTween.Hash(  
						"from", timer.GetComponent<RectTransform>().localScale.x,
						"to",   0,
						"time", 7,
						"onupdatetarget", this.gameObject,
						"onupdate", "Sdummy"	));
						
		yield return new WaitForSeconds(7f);
		
		speed/=2f;
		timer.transform.parent.gameObject.SetActive(false);
		
	}
	
	public void Sdummy(float x)
	{
		timer.GetComponent<RectTransform>().localScale = new Vector3(x, 1f, 1f);
	}
	
	
	//LaserLengthPowerUp
	public IEnumerator BeamLengthPU()
	{	

		beamLength = 2.8f;
		bolt.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
	
		bolt.transform.parent.gameObject.SetActive(true);
		iTween.ValueTo(bolt, iTween.Hash(  
						"from", bolt.GetComponent<RectTransform>().localScale.x,
						"to",   0,
						"time", 7,
						"onupdatetarget", this.gameObject,
						"onupdate", "Bdummy"	));
						
		yield return new WaitForSeconds(7f);
		
		beamLength=1.4f;
		bolt.transform.parent.gameObject.SetActive(false);
		
	}
	
	public void Bdummy(float x)
	{
		bolt.GetComponent<RectTransform>().localScale = new Vector3(x, 1f, 1f);
	}


	//collision check
	public void OnTriggerEnter(Collider pUp)
	{	
		switch(pUp.gameObject.tag)
		{
			case "bolt":
				StartCoroutine(BeamLengthPU());
				Destroy(pUp.gameObject);
				break;
				
			case "dyna":
				explosiveCount++;
				expl.text = explosiveCount.ToString();
				Destroy(pUp.gameObject);
				break;
				
			case "timer":
				
				StartCoroutine(speedPU());
				Destroy(pUp.gameObject);
				break;
				
			case "laser":
				
				SessionOverLocal();
				break;
		}
	}
	
	public IEnumerator boltStart()
	{
		yield return null;
	}	

	
	//sessionOver
	public void SessionOverLocal()
	{
		GameObject sessO = GameObject.FindWithTag("session"); 
		sessO.GetComponent<session>().SessionOver(pNum);
	}

}