using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public GameObject projectile;
	public float speed = 10f;
	public int DELAY = 1;
	public Vector3 bulletPath = Vector3.down;
	public string[] destroyTags;
	public string[] stopTags;
	private float delay = 1;
	
	void Update ()
	{
		delay -= Time.deltaTime;
		float height = projectile.renderer.bounds.extents.y * 1.1f;

		Vector3 v = transform.position;
		v.y += height;

		if(Input.GetButtonUp("Fire1") && delay < 0)
		{
			GameObject shot = Instantiate(projectile, v, Quaternion.identity) as GameObject;
			shot.GetComponent<fly>().Init(Vector2.up, speed);
			delay = DELAY;
		}
	}
}