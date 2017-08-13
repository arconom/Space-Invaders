using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	public float speed = 5f;
	private float minX = -5.1f;
	private float maxX = 5.1f;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetKey ("left"))
		{
			if(transform.position.x > minX)
			{
				transform.Translate (Vector2.right * -1 * speed * Time.deltaTime);
			}
		}
		else if(Input.GetKey ("right"))
		{
			if(transform.position.x < maxX)
			{
				transform.Translate (Vector2.right * speed * Time.deltaTime);
			}
		}
		else
		{
			transform.Translate (Vector2.zero);
		}
	}
}
