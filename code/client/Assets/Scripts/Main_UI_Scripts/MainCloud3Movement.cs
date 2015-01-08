using UnityEngine;
using System.Collections;

public class MainCloud3Movement : MonoBehaviour {

	public float speed;
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.left * speed * Time.deltaTime);
		if (transform.position.x < -7.2) 
		{
			Destroy(gameObject);
		}
	}
}
