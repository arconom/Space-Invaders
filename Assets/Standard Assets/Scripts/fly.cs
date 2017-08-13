using UnityEngine;
using System.Collections;

public class fly : MonoBehaviour {

	public float speed = 0;
	public Vector2 direction = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate(direction * speed * .02f);
	}

	public void Init(Vector2 dir, float sp)
	{
		speed = sp;
		direction = dir;
	}
}
