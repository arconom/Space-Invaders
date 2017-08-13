using UnityEngine;
using System.Collections;

public class InvaderPath : MonoBehaviour 
{
	public float speed = 50;
	public int speedDivisor;
	private static Vector2 vec = Vector2.right;
	float timer = 0f;

	void Awake()
	{
		speedDivisor = GameObject.FindGameObjectsWithTag("Invaders").Length;
	}
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(vec * (speed / speedDivisor) * Time.deltaTime);
		timer -= Time.deltaTime;
	}

	public void MoveDown()
	{
		if(timer < 0)
		{
			transform.Translate(Vector2.up * -1 * .5f);
		}
		timer = .1f;
	}

	public void GoLeft()
	{
		vec = Vector2.right * -1;
	}

	public void GoRight()
	{
		vec = Vector2.right;
	}

	public void Reverse()
	{
		vec *= -1;
	}
}
