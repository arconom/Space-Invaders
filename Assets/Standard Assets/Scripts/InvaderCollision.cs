using UnityEngine;
using System.Collections;

public class InvaderCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other) 
	{
		print ("invader collision");
		if(other.gameObject.name == "RWall")
		{
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().MoveDown ();
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().GoLeft ();
			
		}
		else if(other.gameObject.name == "LWall")
		{
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().MoveDown ();
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().GoRight ();
			
		}
		else if(other.gameObject.name == "Floor")
		{
			Application.Quit();
			GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().Lose ();
		}
		else
		{
			if(other.gameObject.tag == "shield")
			{
				GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().AddPenalty (1);
			}
			Destroy(other.gameObject);
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().speedDivisor = GameObject.FindGameObjectsWithTag("Invaders").Length;
		}
	}


	void OnTriggerEnter2D (Collider2D other) 
	{
		print ("invader collision");
		if(other.gameObject.name == "RWall")
		{
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().MoveDown ();
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().GoLeft ();

		}
		else if(other.gameObject.name == "LWall")
		{
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().MoveDown ();
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().GoRight ();

		}
		else if(other.gameObject.name == "Floor")
		{
			Application.Quit();
			GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().Lose ();
		}
		else
		{
			if(other.gameObject.tag == "shield")
			{
				GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().AddPenalty (1);
			}
			Destroy(other.gameObject);
			GameObject.Find ("Invaders").GetComponent<InvaderPath>().speedDivisor = GameObject.FindGameObjectsWithTag("Invaders").Length;
		}
	}
}
