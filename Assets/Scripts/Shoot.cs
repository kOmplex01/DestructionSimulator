using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] GameObject projectile;
	[SerializeField] int speed;
	[SerializeField] GameObject bulletExit;
	[SerializeField] Camera cam;
	 

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			//anim.SetTrigger("hit");
			GameObject bul = (GameObject)Instantiate(projectile, bulletExit.transform.position, Quaternion.identity);
			bul.gameObject.GetComponent<Rigidbody>().velocity = cam.transform.forward * speed;
		}

		if(Input.GetKeyDown(KeyCode.P))
        {
			if(Time.timeScale <= 0.9f)
            {
				Time.timeScale += 0.1f;
			}
        }

		if (Input.GetKeyDown(KeyCode.O))
		{
			if (Time.timeScale >= 0f)
			{
				Time.timeScale -= 0.1f;
			}
		}
	}
}