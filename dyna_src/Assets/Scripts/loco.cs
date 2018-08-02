using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loco : MonoBehaviour {

	// Use this for initialization
	private GameObject character;
	private float speed= 4.0f;
	public int pNum;
	void Start () 
	{
		character = this.gameObject;	
	}
	
	void Update () 
	{
		if(pNum == 1)
		{	
			p1Move();
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


		if(Input.GetKey(KeyCode.Space))
		{
			LaserAtatck();
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

		
	}


	public void LaserAtatck()
	{

	}


	public IEnumerator speedPU()
	{	

		yield return null;

		//drop speed
		//remove indicator
	}


	public IEnumerator BeamLengthPU()
	{	

		yield return null;

		//drop speed
		//remove indicator
	}


	public void SessionOverLocal()
	{
		Data.Instance.SessionOver(pNum);
	}

}