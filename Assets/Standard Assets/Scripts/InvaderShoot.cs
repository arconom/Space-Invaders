using UnityEngine;
using System.Collections;

public class InvaderShoot : MonoBehaviour
{
	public GameObject projectile;
	public float speed = 10f;
	public int DELAY = 10;
	public Vector2 bulletPath = Vector2.up * -1;
//	public string[] destroyTags;
//	public string[] stopTags;
	private float delay;

	void Start()
	{
		delay = DELAY * (Random.value + 1);
	}

	void Update ()
	{
		delay -= Time.deltaTime;

		Vector3 v = transform.position;
		v.y -= transform.localScale.y;

		if(delay < 0)
		{
			GameObject shot = Instantiate(projectile, v, Quaternion.identity) as GameObject;
			shot.GetComponent<fly>().Init(bulletPath, speed);
			delay = DELAY * (Random.value + 1);
		}
	}
}