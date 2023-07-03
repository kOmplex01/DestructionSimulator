using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Destruction : MonoBehaviour
{
	public GameObject mesh;

	float cubeWidth;
	float cubeHeight;
	float cubeDepth;

	public float cubeScale = 0.3f;

	[SerializeField] Material mat;
	//[SerializeField] Transform parent;

	void Start()
	{
		cubeWidth = transform.localScale.x;
		cubeHeight = transform.localScale.y;
		cubeDepth = transform.localScale.z;

		

		mesh.transform.localScale = new Vector3(1 / cubeWidth, 1 / cubeHeight, 1 / cubeDepth);

		gameObject.GetComponent<MeshRenderer>().enabled = false;
		mesh.gameObject.GetComponent<Transform>().localScale = new Vector3(cubeScale, cubeScale, cubeScale);
		CreateCube();
	}



	void CreateCube()
	{
		this.gameObject.GetComponent<BoxCollider>().enabled = false;
		this.gameObject.GetComponent<MeshRenderer>().enabled = false;

		if (gameObject.CompareTag("box"))
		{
			for (float x = 0; x < cubeWidth; x += cubeScale)
			{
				for (float y = 0; y < cubeHeight; y += cubeScale)
				{
					for (float z = 0; z < cubeDepth; z += cubeScale)
					{
						Vector3 vec = transform.position - new Vector3(cubeWidth / 2, cubeHeight / 2, cubeDepth / 2);
						print(x); print(y); print(z);
						
						GameObject cubes = (GameObject)Instantiate(mesh, vec + new Vector3(x, y, z), Quaternion.identity);
						if (mat != null)
						{
							cubes.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
						}
					}
				}
			}
		}
	}
	
}