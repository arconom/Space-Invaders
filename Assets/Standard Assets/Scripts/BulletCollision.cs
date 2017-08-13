using UnityEngine;
using System.Collections;
using System.Linq;

public class BulletCollision : MonoBehaviour 
{
	public string[] destroyTags;
	public string[] stopTags;

	// Update is called once per frame
	void Update () 
	{
		if (transform.renderer.bounds.Intersects(object2.renderer.bounds)) {
			// Do some stuff
		}
	}	

	void OnTriggerEnter2D (Collider2D other) 
	{
		print ("bullet collision");
		if(other.transform.name == "PlayerShip")
		{
			GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().Lose ();
		}
		if(destroyTags.Contains(other.gameObject.tag))
		{
			if(other.transform.tag == "Invaders")
			{
				GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().AddScore (200);
				GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().AddKills (1);
			}
			if(other.transform.tag == "Shield")
			{
				GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().AddPenalty (1);
			}
			
			Destroy(other.gameObject);
		}
		if(stopTags.Contains(other.gameObject.tag))
		{
			Destroy(this.gameObject);
		}
		//		else
		//		{
		//			Physics.IgnoreCollision (gameObject.collider, other.collider);
		//		}
	}		


	void OnCollisionEnter2D (Collision2D other) 
	{
		print ("bullet collision");
		if(other.transform.name == "PlayerShip")
		{
			print ("dicks");
			GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().Lose ();
		}
		if(destroyTags.Contains(other.gameObject.tag))
		{
			if(other.transform.tag == "Invaders")
			{
				GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().AddScore (200);
				GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().AddKills (1);
			}
			if(other.transform.tag == "Shield")
			{
				GameObject.Find ("ScoreCard").GetComponent<ScoreKeeper>().AddPenalty (1);
			}

			Destroy(other.gameObject);
		}
		if(stopTags.Contains(other.gameObject.tag))
		{
			Destroy(this.gameObject);
		}
//		else
//		{
//			Physics.IgnoreCollision (gameObject.collider, other.collider);
//		}
	}		

}
