using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private Collider[] hitColliders;
	
	[SerializeField] float blastRadius;
	[SerializeField] float explosionPower;
	[SerializeField] LayerMask explosionLayers;
	
	[SerializeField] GameObject Particles;

	private void OnCollisionEnter(UnityEngine.Collision col)
	{
		//Particles.gameObject.GetComponent<Renderer>().material = col.gameObject.GetComponent<MeshRenderer>().material;
		//Instantiate(Particles, col.transform.position, Quaternion.identity);
		

			destroyed(col.contacts[0].point, col.relativeVelocity);

		
	}

	void destroyed(Vector3 explosionPoint, Vector3 vel)
	{
		hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);

		foreach (Collider hitCol in hitColliders)
		{
			if (hitCol.GetComponent<Rigidbody>() == null)
			{
				hitCol.GetComponent<MeshRenderer>().enabled = true;
				hitCol.gameObject.AddComponent<Rigidbody>();


				hitCol.GetComponent<Rigidbody>().mass = 50;
				hitCol.GetComponent<Rigidbody>().isKinematic = false;

				hitCol.GetComponent<Rigidbody>().velocity = vel.normalized * 10;
			}
				hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint + vel.normalized * 10f, blastRadius, 1, ForceMode.Impulse);
		}
	}

	
}