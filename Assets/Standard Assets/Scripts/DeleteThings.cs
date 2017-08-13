using UnityEngine;
using System.Collections;

public class DeleteThings : MonoBehaviour 
{
	void OnCollisionEnter2D (Collision2D other) 
	{
		print ("deleting " + other.transform.name);
		Destroy(other.gameObject);
	}
}
